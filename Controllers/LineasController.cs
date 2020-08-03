using InventoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LineasController : ControllerBase
    {
        private readonly InventoryContext _context;

        public LineasController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Lineas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lineas>>> GetLineas()
        {
            return await _context.Lineas.ToListAsync();
        }


    }
}
