namespace MarketManagementSystem.Entities.Abstract
{
    public abstract class Customer
    {
        public int Id { get; set; }

        // Burada varsayılan değer atıyoruz
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public abstract string GetCustomerInfo();
    }
}
