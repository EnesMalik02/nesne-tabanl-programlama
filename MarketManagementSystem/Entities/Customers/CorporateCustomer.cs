using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Customers
{
    public class CorporateCustomer : Customer
    {
        // Varsayılan boş değer
        public string CompanyName { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;

        public override string GetCustomerInfo()
        {
            return $"Kurumsal Müşteri: {CompanyName}, Vergi No: {TaxNumber}";
        }
    }
}
