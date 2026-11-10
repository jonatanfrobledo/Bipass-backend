using Application.Models.Requests;
using Application.Services;
using Infraestructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BipassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly CheckoutService _checkoutService;

        public OrdersController(OrderService orderService, CheckoutService checkoutService)
        {
            _orderService = orderService;
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto createOrderDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            createOrderDto.UserId = userId;

            try
            {
                var newOrderId = await _orderService.AddOrderAsync(createOrderDto);
                return CreatedAtAction(nameof(GetById), new { id = newOrderId }, new { id = newOrderId });
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

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (order.UserId != userId && !User.IsInRole("SuperAdmin"))
            {
                return Forbid();
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
        public async Task<IActionResult> CreatePreference([FromBody] CreatePreferenceDto requestDto)
        {
            if (requestDto == null || requestDto.Items == null || requestDto.Items.Count == 0)
            {
                return BadRequest(new { message = "Los ítems de la orden son requeridos." });
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { message = "Token inválido o sin identificador de usuario." });
            }

            var userId = int.Parse(userIdClaim);
            requestDto.UserId = userId;

            try
            {
                string preferenceId = await _checkoutService.CreatePreferenceFromCheckoutAsync(requestDto);

                var userOrders = await _orderService.GetOrdersByUserIdAsync(userId);
                var latestOrder = userOrders.OrderByDescending(o => o.Id).FirstOrDefault();
                int orderId = latestOrder?.Id ?? 0;

                return Ok(new { preferenceId, orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("approve/{orderId:int}")]
        public async Task<IActionResult> ApproveOrder(int orderId)
        {
            try
            {
                var success = await _checkoutService.ApproveOrderByExternalReferenceAsync(orderId);
                if (!success)
                {
                    return NotFound(new { message = "Orden no encontrada." });
                }
                return Ok(new { message = "Orden aprobada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}