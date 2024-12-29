namespace MarketManagementSystem.Entities.Abstract
{
    // Ödeme yöntemleri için abstract base sınıf
    public abstract class Payment
    {
        public decimal Amount { get; set; }

        // Polimorfik olarak farklı ödeme şekillerini handle etmek için
        public abstract void Pay();
    }
}
