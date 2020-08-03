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
    public class RepoPresuVentasController : ControllerBase
    {
        private readonly InventoryContext _context;

        public RepoPresuVentasController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/RepoPresuVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepoPresuVentas>>> GetRepoPresuVentas(string? NumIdOrgVentas = "1000", string? NumUndNegocio = "masc", string? NumIdVendedor = "019")
        {
            return await _context.RepoPresuVentas.Where(x => x.IdOrgVentas == NumIdOrgVentas).Where(x => x.IdVendedor == NumIdVendedor).ToListAsync();
        }

    }
}
