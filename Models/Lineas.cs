using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimLinea")]
    public class Lineas
    {
        public string Linea { get; }
        public string UndNegocio { get; }
        public string UndNegocioNombre { get; }
    }
}