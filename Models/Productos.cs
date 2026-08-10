using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimProductos")]
    public class Productos
    {
        public string idMaterial { get; set; }
        public string Producto { get; set; }
        public string IdGrArticulos { get; set; }
        public string NombreGrArticulos { get; set; }
        public string AgrupacionMarca { get; set; }
        public string GrupoProductos { get; set; }
    }
}