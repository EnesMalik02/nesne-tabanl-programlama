using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Customers
{
    public class IndividualCustomer : Customer
    {
        // Varsayılan boş değer
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string TCKN { get; set; } = string.Empty;

        public override string GetCustomerInfo()
        {
            return $"Bireysel Müşteri: {FirstName} {LastName}, TCKN: {TCKN}";
        }
    }
}
