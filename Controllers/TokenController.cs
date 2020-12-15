using InventoryService.Models;
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
    public class TokenController : ControllerBase
    {

        private readonly PBIServices.Ldap.LdapAuthenticationService authService;
        public IConfiguration _configuration;
        private readonly InventoryContext _context;

        public TokenController(IConfiguration config, InventoryContext context, IAuthenticationService authService)
        {
            _configuration = config;
            _context = context;
            this.authService = (LdapAuthenticationService)authService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                var ldapUser = authService.Login(user.UserName);


                if (null != ldapUser)
                {
                    try
                    {
                        if (user != null)
                        {
                            //create claims details based on the user information
                            var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("Id", user.UserId.ToString()),
                            new Claim("FirstName", user.FirstName),
                            new Claim("LastName", user.LastName),
                            new Claim("UserName", user.UserName),
                            new Claim("Email", user.Email)
                   };

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(365), signingCredentials: signIn);

                            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                        }
                        else
                        {
                            return BadRequest("Invalid credentials");
                        }
                    }
                    catch (Exception ex)
                    {
                        Funciones.Logs("TokenController", "Problemas al abrir la conexion; Captura error: " + ex.Message);
                        Funciones.Logs("TokenController", ex.StackTrace);
                        return Unauthorized("en el catch");
                    }
                }
                else
                {
                    return Unauthorized("en el else de token controller");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserInfo> GetUser(string email, string password)
        {
            return await _context.UserInfo.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}