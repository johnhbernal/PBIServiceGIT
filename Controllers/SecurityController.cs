using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    /// <summary>
    /// Legacy login probe — disabled. Use POST /api/Token.
    /// Previous implementation leaked VentClienProductos without AuthZ (fixed 2026-08).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Login()
        {
            return BadRequest(new
            {
                code = "410",
                description = "SecurityController login is disabled. Use POST /api/Token with email/password."
            });
        }
    }
}
