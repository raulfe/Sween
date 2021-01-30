﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityServices;
        public TokenController(IConfiguration configuration, ISecurityService securityServices)
        {
            _configuration = configuration;
            _securityServices = securityServices;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login) 
        {
            var validation = await IsValidUser(login);    
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
            
        }

        private async Task<(bool,Security)> IsValidUser(UserLogin login)
        {
            var user = await _securityServices.GetLoginByCredentials(login);
            return (user!= null,user);
        }

        private string GenerateToken(Security security)
        {
            //Header
            var symetricSecutiryKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

            var signingCredentials = new SigningCredentials(symetricSecutiryKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,security.User),
                new Claim(ClaimTypes.Role,security.Rol.ToString()),
            };
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(5)
            );

            //Token
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
