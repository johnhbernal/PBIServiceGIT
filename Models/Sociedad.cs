using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_DimSociedad")]
    public partial class Sociedades
    {
        public string IdSociedad { get; set; }

        [Column("Sociedad")]
        public string Sociedad { get; set; }
    }
}