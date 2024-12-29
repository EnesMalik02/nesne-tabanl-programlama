using System;
using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities.Payments
{
    public class CashPayment : Payment
    {
        public override void Pay()
        {
            Console.WriteLine("Nakit ödeme alındı.");
        }
    }
}
