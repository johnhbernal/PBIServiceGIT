using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{

    [Table("PBI_DimSociedad")]
    public partial class Sociedades
    {
        public string IdSociedad { get; }
        [Column("Sociedad")]
        public string Sociedad { get; }

    }
}
