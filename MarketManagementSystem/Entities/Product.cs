namespace MarketManagementSystem.Entities
{
    public class Product
    {
        public int Id { get; set; }

        // Varsayılan değer
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
