using Application.Models.Requests;
using Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly CheckoutService _checkoutService;

    public CheckoutController(CheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpPost("create-preference")]
    public async Task<IActionResult> CreatePreference([FromBody] OrderDto orderDto)
    {
        if (orderDto == null)
            return BadRequest("Los datos de la orden son requeridos.");

        // Llama al servicio pasando el DTO
        string preferenceId = await _checkoutService.CreatePreferenceAsync(orderDto);

        return Ok(new { preferenceId });
    }
}