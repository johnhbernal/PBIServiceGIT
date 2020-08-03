namespace InventoryService.Models
{
    public partial class Products
    {
        public int ProductId { get; }
        public string Name { get; }
        public string Category { get; }
        public string Color { get; }
        public decimal UnitPrice { get; }
        public int AvailableQuantity { get; }
    }
}
