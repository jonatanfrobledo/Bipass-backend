using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BipassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Todos los endpoints requieren autenticación
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto createOrderDto)
        {
            // Obtiene el ID del usuario del token JWT para evitar suplantación de identidad
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            createOrderDto.UserId = userId;

            try
            {
                var newOrderId = await _orderService.AddOrderAsync(createOrderDto);
                return CreatedAtAction(nameof(GetById), new { id = newOrderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "Orden no encontrada." });
            }

            // Valida que el usuario logueado sea el dueño de la orden o un admin
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (order.UserId != userId && !User.IsInRole("admin"))
            {
                return Forbid(); // 403 Forbidden si el usuario no tiene permisos
            }

            return Ok(order);
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }
        [HttpPost("create-preference")]
        public async Task<IActionResult> CreatePreference([FromBody] CreateOrderDto createOrderDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            createOrderDto.UserId = userId;

            try
            {
                var preferenceResult = await _orderService.CreatePaymentPreferenceAsync(createOrderDto);
                return Ok(preferenceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}