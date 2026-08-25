using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Configuration;

// ⚠️ Descomentar estos 'using' cuando tengas el Access Token de Mercado Pago
// using MercadoPago.Client.Preference;
// using MercadoPago.Config;
// using MercadoPago.Resource.Preference;

namespace Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketTypeRepository _ticketTypeRepository;
        private readonly IConfiguration _configuration;

        public OrderService(
            IOrderRepository orderRepository,
            ITicketTypeRepository ticketTypeRepository,
            IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _ticketTypeRepository = ticketTypeRepository;
            _configuration = configuration;

            // ⚠️ Comentado temporalmente para no configurar el token inexistente
            // var accessToken = _configuration["MercadoPago:AccessToken"];
            // MercadoPagoConfig.AccessToken = accessToken;
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TicketTypeName = oi.TicketType?.Name ?? "Entrada"
                }).ToList()
            };
        }

        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUser(userId);
            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TicketTypeName = oi.TicketType?.Name ?? "Entrada"
                }).ToList()
            }).ToList();
        }

        public async Task<PaymentPreferenceResponseDto> CreatePaymentPreferenceAsync(CreateOrderDto newOrderDto)
        {
            decimal totalAmount = 0;
            var order = new Order
            {
                UserId = newOrderDto.UserId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in newOrderDto.Items)
            {
                var ticketType = await _ticketTypeRepository.GetTicketTypeById(itemDto.TicketTypeId);
                if (ticketType == null || ticketType.QuantityAvailable < itemDto.Quantity)
                {
                    throw new Exception("Stock insuficiente para el tipo de entrada.");
                }

                totalAmount += ticketType.Price * itemDto.Quantity;

                order.OrderItems.Add(new OrderItem
                {
                    TicketTypeId = itemDto.TicketTypeId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = ticketType.Price
                });
            }

            order.TotalAmount = totalAmount;
            await _orderRepository.AddOrder(order);

            // =========================================================================
            // 🧪 1. FUNCIONALIDAD TEMPORAL / MOCK (ACTIVA)
            // =========================================================================
            await Task.Delay(300); // Simula latencia
            string mockPreferenceId = "PREFERENCE_MOCK_" + Guid.NewGuid().ToString("N");

            return new PaymentPreferenceResponseDto
            {
                OrderId = order.Id,
                PreferenceId = mockPreferenceId,
                InitPoint = "http://localhost:5173/mytickets" // Redirige directamente al front
            };


            // =========================================================================
            // 💳 2. CÓDIGO REAL DE MERCADO PAGO (DESCOMENTAR CUANDO TENGAS EL ACCESS TOKEN)
            // =========================================================================
            /*
            var preferenceItems = new List<PreferenceItemRequest>();

            foreach (var item in order.OrderItems)
            {
                preferenceItems.Add(new PreferenceItemRequest
                {
                    Title = "Entrada Evento",
                    Quantity = item.Quantity,
                    CurrencyId = "ARS",
                    UnitPrice = item.UnitPrice
                });
            }

            var request = new PreferenceRequest
            {
                Items = preferenceItems,
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:5173/mytickets",
                    Failure = "http://localhost:5173/checkout",
                    Pending = "http://localhost:5173/mytickets"
                },
                AutoReturn = "approved",
                ExternalReference = order.Id.ToString()
            };

            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            return new PaymentPreferenceResponseDto
            {
                OrderId = order.Id,
                PreferenceId = preference.Id,
                InitPoint = preference.InitPoint
            };
            */
        }

        public async Task<int> AddOrderAsync(CreateOrderDto newOrderDto)
        {
            decimal totalAmount = 0;
            var order = new Order
            {
                UserId = newOrderDto.UserId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in newOrderDto.Items)
            {
                var ticketType = await _ticketTypeRepository.GetTicketTypeById(itemDto.TicketTypeId);
                if (ticketType == null || ticketType.QuantityAvailable < itemDto.Quantity)
                {
                    throw new Exception("Stock insuficiente para el tipo de entrada.");
                }

                ticketType.QuantityAvailable -= itemDto.Quantity;
                totalAmount += ticketType.Price * itemDto.Quantity;

                order.OrderItems.Add(new OrderItem
                {
                    TicketTypeId = itemDto.TicketTypeId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = ticketType.Price
                });
            }

            order.TotalAmount = totalAmount;
            order.Status = "Completed";
            await _orderRepository.AddOrder(order);

            return order.Id;
        }
    }
}