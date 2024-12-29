using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Discounts
{
    public class PercentageDiscount : Discount
    {
        public decimal Percentage { get; set; }

        public PercentageDiscount(decimal percentage)
        {
            Percentage = percentage;
        }

        public override decimal CalculateDiscountAmount(decimal totalAmount)
        {
            // Yüzdelik oranda indirim hesaplama
            return totalAmount * (Percentage / 100);
        }
    }
}
