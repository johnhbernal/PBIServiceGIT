using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentasClientesProductos")]
    public class VentClienProductos
    {
        [Key]
        public string Linea { get; }

        public string UndNegocio { get; }
        public string IdOrgVentas { get; }
        public string IdMaterial { get; }
        public string Producto { get; }
        public decimal VentaML { get; }

        [StringLength(1)]
        public int AjusteFormato { get; }

        //public string RepresentanteVentas { get; internal set; }
    }
}