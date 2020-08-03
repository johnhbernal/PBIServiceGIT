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
    public class VentasController : ControllerBase
    {
        private readonly InventoryContext _context;

        public VentasController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas(string? NumIdOrgVentas="1000", string? NumUndNegocio = "masc", string? NumIdVendedor="019")
        {

            return await _context.Ventas.Where(x => x.IdOrgVentas == NumIdOrgVentas).Where(x => EF.Functions.Like(x.UndNegocio, "%"+NumUndNegocio+"%")).Where(x => x.IdVendedor == NumIdVendedor).ToListAsync();
            //return await _context.Ventas.Where(x => x.IdOrgVentas == "1065").ToListAsync();

          
        }

    }
}
