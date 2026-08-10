using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimClientes")]
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string NombreComercial { get; set; }
    }
}