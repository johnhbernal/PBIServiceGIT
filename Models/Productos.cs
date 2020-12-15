using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimProductos")]
    public class Productos
    {
        public string idMaterial { get; }
        public string Producto { get; }
        public string IdGrArticulos { get; }
        public string NombreGrArticulos { get; }
        public string AgrupacionMarca { get; }
        public string GrupoProductos { get; }
    }
}