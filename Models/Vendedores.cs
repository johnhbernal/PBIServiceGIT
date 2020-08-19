using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PBIServices.Models
{
    [Table("[CCDIMVentas].[dbo].[BI_PoolVendedores]")]
    public class Vendedores
    {
        public int IdUserDomain { get; set; }
        public string UserDomain { get; set; }
        public string Email { get; set; }
        public string IdVendedor { get; set; }
        public string VendFilter { get; set; }
        public string IdOrgVentas { get; set; }
    }
}
