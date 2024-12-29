namespace MarketManagementSystem.Entities.Abstract
{
    // İndirim için abstract base sınıf
    public abstract class Discount
    {
        // İndirim miktarının hesaplanıp dönüldüğü metot
        public abstract decimal CalculateDiscountAmount(decimal totalAmount);
    }
}
