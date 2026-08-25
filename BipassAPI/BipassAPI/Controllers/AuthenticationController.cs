using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BipassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomAuthenticationService _authService;
        public AuthenticationController(ICustomAuthenticationService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var token = _authService.Login(loginRequest);
            if (token == null)
            {
                return Unauthorized(new { message = "Credenciales invalidas" });
            }
            return Ok(new { token });
        }
        

    }
}
