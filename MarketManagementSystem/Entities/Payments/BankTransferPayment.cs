using System;
using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Payments
{
    public class BankTransferPayment : Payment
    {
        // Varsayılan boş değer
        public string BankName { get; set; } = string.Empty;
        public string IBAN { get; set; } = string.Empty;

        public override void Pay()
        {
            Console.WriteLine($"Havale/EFT ile ödeme alındı. Banka: {BankName}, IBAN: {IBAN}");
        }
    }
}
