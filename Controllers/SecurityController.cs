using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBIServices.Ldap;

//namespace PBIServices.Controllers
namespace InventoryService.Controllers
{
    //[Route("api/[controller/action]")]
    [Route("api/[controller]")]
    //[ApiController]
    public class SecurityController : ControllerBase
    {
        //private readonly PBIServices.Ldap.IAuthenticationService authService;
        private readonly PBIServices.Ldap.LdapAuthenticationService authService;

        private readonly InventoryContext _context;


        public SecurityController(IAuthenticationService authService, InventoryContext context)
        {
            this.authService = (LdapAuthenticationService)authService;
            _context = context;

        }



        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Lineas>>> GetLineas(string UserName, string Password)
        public async Task<IActionResult> Login(string UserName, string Password)
        {

            //var user = GetLineas(UserName="john.bernal", Password="Carval2019b");




   


            var user = authService.Login( "john.bernal","Carval2019b");


            //if (null != user)
            if (null != user)
            {
                try
                {
                    // create your login token here
                    //return (IActionResult)await _context.Lineas.ToListAsync();
                    //return (IActionResult)user;
                    //return await _context.Lineas.ToListAsync();
                    return Ok("debe estar bien");
                }
                catch (Exception ex)
                {
                    Funciones.Logs("SecurityController", "Problemas al abrir la conexion; Captura error: " + ex.Message);
                    Funciones.Logs("SecurityController_DEBUG", ex.StackTrace);
                    return Unauthorized("en el catch");
                }
            }
            else
            {
                return Unauthorized("en el else");

            }


        }

    }


}
