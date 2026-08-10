using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimLinea")]
    public class Lineas
    {
        public string Linea { get; set; }
        public string UndNegocio { get; set; }
        public string UndNegocioNombre { get; set; }
    }
}