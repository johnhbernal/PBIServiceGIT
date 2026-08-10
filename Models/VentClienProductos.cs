using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentasClientesProductos")]
    public class VentClienProductos
    {
        [Key]
        public string Linea { get; set; }

        public string UndNegocio { get; set; }
        public string IdOrgVentas { get; set; }
        public string IdMaterial { get; set; }
        public string Producto { get; set; }
        public decimal VentaML { get; set; }

        [StringLength(1)]
        public int AjusteFormato { get; set; }

        //public string RepresentanteVentas { get; internal set; }
    }
}