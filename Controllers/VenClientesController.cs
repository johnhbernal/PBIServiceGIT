using InventoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBIServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VenClientesController : ControllerBase
    {
        private readonly InventoryContext _context;

        public VenClientesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/VenClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VenClientes>>> GetVenClientes()
        {
            return await _context.VenClientes.ToListAsync();
        }
    }
}