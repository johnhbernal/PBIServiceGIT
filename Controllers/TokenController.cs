using InventoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PBIServices.Ldap;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _directory;
        private readonly IConfiguration _configuration;
        private readonly InventoryContext _context;

        public TokenController(IConfiguration config, InventoryContext context, IAuthenticationService directory)
        {
            _configuration = config;
            _context = context;
            _directory = directory;
        }

        /// <summary>
        /// Teaching login against seeded InMemory users + simulated directory.
        /// Demo: admin@demo.local / Admin123!  ·  seller@demo.local / Seller123!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInfo userData)
        {
            if (userData == null || string.IsNullOrWhiteSpace(userData.Email) || string.IsNullOrWhiteSpace(userData.Password))
            {
                return BadRequest(new { code = "400", description = "Email and password are required." });
            }

            var user = await GetUser(userData.Email, userData.Password);
            if (user == null)
            {
                return Unauthorized(new { code = "401", description = "Invalid credentials (use seeded demo users)." });
            }

            var directoryEnabled = !string.Equals(_configuration["Ldap:Enabled"], "false", StringComparison.OrdinalIgnoreCase);
            if (directoryEnabled)
            {
                var dirUser = _directory.Login(user.UserName, userData.Password);
                if (dirUser == null)
                {
                    return Unauthorized(new { code = "401", description = "Simulated directory rejected user." });
                }
            }

            var minutes = 60;
            if (int.TryParse(_configuration["Jwt:ExpirationMinutes"], out var parsed) && parsed > 0)
            {
                minutes = Math.Min(parsed, 24 * 60);
            }

            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("Id", user.UserId.ToString()),
                new Claim("FirstName", user.FirstName ?? string.Empty),
                new Claim("LastName", user.LastName ?? string.Empty),
                new Claim("UserName", user.UserName ?? string.Empty),
                new Claim("Email", user.Email ?? string.Empty),
                new Claim("lab", "teaching")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                notBefore: now,
                expires: now.AddMinutes(minutes),
                signingCredentials: credentials);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiresInMinutes = minutes,
                demoHint = "Teaching lab — InMemory seed + simulated directory"
            });
        }

        private Task<UserInfo> GetUser(string email, string password)
        {
            return _context.UserInfo.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
