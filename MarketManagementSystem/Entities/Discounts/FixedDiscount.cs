using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Discounts
{
    public class FixedDiscount : Discount
    {
        public decimal DiscountValue { get; set; }

        public FixedDiscount(decimal discountValue)
        {
            DiscountValue = discountValue;
        }

        public override decimal CalculateDiscountAmount(decimal totalAmount)
        {
            // Sabit indirim miktarı
            // Toplam tutardan büyük olmamasına dikkat edebiliriz.
            if (DiscountValue > totalAmount)
                return totalAmount;
            else
                return DiscountValue;
        }
    }
}
