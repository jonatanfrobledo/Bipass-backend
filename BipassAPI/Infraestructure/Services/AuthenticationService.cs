using Application.Interfaces;
using Application.Models.Requests;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string? Login(LoginRequest loginRequest)
        {
            var user = _userRepository.ValidateUser(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            var secretKey = _configuration["AuthenticationService:SecretForKey"]
                ?? throw new InvalidOperationException("La clave secreta del JWT no está configurada.");

            var securityPassword = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                
                
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["AuthenticationService:Issuer"],
                audience: _configuration["AuthenticationService:Audience"],
                claims: claimsForToken,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(8), 
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}