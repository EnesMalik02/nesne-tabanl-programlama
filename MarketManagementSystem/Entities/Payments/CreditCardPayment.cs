using System;
using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Payments
{
    public class CreditCardPayment : Payment
    {
        // Varsayılan boş değer
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;

        public override void Pay()
        {
            Console.WriteLine(
                $"Kredi Kartı ile ödeme alındı. Kart Sahibi: {CardHolderName}, Kart Numarası: {CardNumber}"
            );
        }
    }
}
