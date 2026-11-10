using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Error;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Services
{
    public class CheckoutService
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketTypeRepository _ticketTypeRepository;

        public CheckoutService(
            IConfiguration configuration,
            IOrderRepository orderRepository,
            ITicketTypeRepository ticketTypeRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;
            _ticketTypeRepository = ticketTypeRepository;
        }

        public async Task<string> CreatePreferenceFromCheckoutAsync(CreatePreferenceDto orderDto)
        {
            var token = _configuration["MercadoPago:AccessToken"];
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("El token de Mercado Pago 'MercadoPago:AccessToken' no está configurado en appsettings.json.");
            }
            MercadoPagoConfig.AccessToken = token;

            decimal calculatedTotal = 0;
            var newOrder = new Order
            {
                UserId = orderDto.UserId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in orderDto.Items)
            {
                var ticketType = await _ticketTypeRepository.GetTicketTypeById(itemDto.TicketTypeId);
                if (ticketType == null || ticketType.QuantityAvailable < itemDto.Quantity)
                {
                    throw new Exception($"Stock insuficiente para el tipo de entrada: {ticketType?.Name ?? "Desconocido"}");
                }

                ticketType.QuantityAvailable -= itemDto.Quantity;
                calculatedTotal += ticketType.Price * itemDto.Quantity;

                newOrder.OrderItems.Add(new OrderItem
                {
                    TicketTypeId = itemDto.TicketTypeId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = ticketType.Price
                });
            }

            newOrder.TotalAmount = calculatedTotal;

            await _orderRepository.AddOrder(newOrder);

            var preferenceItems = newOrder.OrderItems.Select(item => new PreferenceItemRequest
            {
                Title = "Entrada BIPASS - Evento",
                Quantity = item.Quantity,
                CurrencyId = "ARS",
                UnitPrice = item.UnitPrice
            }).ToList();

            var request = new PreferenceRequest
            {
                Items = preferenceItems,
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "http://localhost:5173/mytickets?status=approved",
                    Failure = "http://localhost:5173/checkout",
                    Pending = "http://localhost:5173/mytickets?status=pending"
                },
                ExternalReference = newOrder.Id.ToString()
            };

            try
            {
                var client = new PreferenceClient();
                Preference preference = await client.CreateAsync(request);

                if (preference == null || string.IsNullOrEmpty(preference.Id))
                {
                    throw new Exception("Mercado Pago no devolvió un ID de preferencia válido.");
                }

                return preference.Id;
            }
            catch (MercadoPagoApiException mpEx)
            {
                throw new Exception($"Error API Mercado Pago (Status {mpEx.StatusCode}): {mpEx.Message}");
            }
        }

        public async Task<bool> ApproveOrderByExternalReferenceAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return false;

            order.Status = "Approved";
            await _orderRepository.UpdateOrder(order);
            return true;
        }
    }
}