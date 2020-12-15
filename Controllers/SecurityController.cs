using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBIServices.Ldap;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

//namespace PBIServices.Controllers
namespace InventoryService.Controllers
{
    //[Route("api/[controller/action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        //private readonly PBIServices.Ldap.IAuthenticationService authService;
        private readonly PBIServices.Ldap.LdapAuthenticationService authService;

        private readonly InventoryContext _context;


        //var connections = _configuration.GetSection("ConnectionStrings").GetChildren().AsEnumerable();

        public SecurityController(IAuthenticationService authService, InventoryContext context)
        {
            this.authService = (LdapAuthenticationService)authService;
            _context = context;
        }

        public SqlCommand SqlCommand { get; private set; }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Lineas>>> GetLineas(string UserName, string Password)
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            //var user = GetLineas(UserName="john.bernal", Password="Carval2019b");

            //var user = authService.Login( "john.bernal","Carval2019b");
            var user = authService.Login("john.bernal");



            return (IActionResult)await _context.VentClienProductos.ToListAsync();





            //if (null != user)
            if (null != user)
            {
                try
                {
                    // create your login token here
                    //return (IActionResult)await _context.Vendedores.ToListAsync();
                    //return (IActionResult)user;
                    return (IActionResult)await _context.Lineas.ToListAsync();

                    //return Ok("debe estar bien " + user.UserName + " - " + user.Password);

                    //return await _context.Lineas.ToListAsync();
                }
                catch (Exception ex)
                {
                    Funciones.Logs("SecurityController", "Problemas al abrir la conexion; Captura error: " + ex.Message);
                    Funciones.Logs("SecurityController_DEBUG", ex.StackTrace);
                    return Unauthorized("en el catch " + user);
                }
            }
            else
            {
                return Unauthorized("en el else " + user);
            }
        }
    }
}