using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SociedadesController : ControllerBase
    {
        private readonly InventoryContext _context;

        public SociedadesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Sociedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sociedades>>> GetSociedades()
        {
            return await _context.Sociedades.ToListAsync();
        }
    }
}