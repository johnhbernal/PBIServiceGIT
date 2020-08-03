using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestosController : ControllerBase
    {
        private readonly InventoryContext _context;

        public PresupuestosController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Presupuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presupuesto>>> GetPresupuestos(string? NumIdOrgVentas = "1000", string? NumIdVendedor = "019")
        {
            //return await _context.Presupuestos.ToListAsync();

            return await _context.Presupuestos.Where(x => x.IdOrgVentas == NumIdOrgVentas).Where(x => x.IdVendedor == NumIdVendedor).ToListAsync();
        }

    }
}
