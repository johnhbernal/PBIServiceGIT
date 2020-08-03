using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryService.Models;

namespace PBIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentClienProductosController : ControllerBase
    {
        private readonly InventoryContext _context;

        public VentClienProductosController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/VentClienProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentClienProductos>>> GetVentClienProductos(string? NumIdOrgVentas = "1000", string? NumUndNegocio = "masc")
        {

            //return await _context.VentClienProductos.Where(x => x.IdOrgVentas == NumIdOrgVentas).Where(x => EF.Functions.Like(x.UndNegocio, "%" + NumUndNegocio + "%")).ToListAsync();

            return await _context.VentClienProductos.Where(x => x.IdOrgVentas == NumIdOrgVentas).ToListAsync();
        }

    }
}
