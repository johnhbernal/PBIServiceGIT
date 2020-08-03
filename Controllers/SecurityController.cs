using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//namespace PBIServices.Controllers
namespace InventoryService.Controllers
{
    //[Route("api/[controller/action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IAuthenticationService authService;

        private readonly InventoryContext _context;


    

        public SecurityController(IAuthenticationService authService, InventoryContext context)
        {
            this.authService = authService;
            _context = context;

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lineas>>> GetLineas(string UserName, string Password)
        {



            var user = GetLineas(UserName="john.bernal", Password="Carval2019b");



            if (null != user)
            {
                // create your login token here
                return await _context.Lineas.ToListAsync();
            }
            else
            {
                return Unauthorized();
            }


        }

    }
   
  
}
