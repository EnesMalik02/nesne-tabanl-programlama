using System;
using MarketManagementSystem.Entities.Abstract;

namespace MarketManagementSystem.Entities
{
    public enum OrderStatus
    {
        Created,
        Confirmed,
        Preparing,
        Delivered
    }

    public class Order
    {
        public Cart Cart { get; set; }
        public Customer Customer { get; set; }
        public Payment PaymentMethod { get; set; }
        public OrderStatus Status { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal FinalAmount { get; private set; }

        public Order(Cart cart, Customer customer, Payment paymentMethod)
        {
            Cart = cart;
            Customer = customer;
            PaymentMethod = paymentMethod;
            Status = OrderStatus.Created;

            TotalAmount = Cart.GetTotalAmount();
            FinalAmount = TotalAmount;
        }

        public void ApplyDiscount(Discount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount nesnesi null olamaz.");

            DiscountAmount = discount.CalculateDiscountAmount(TotalAmount);
            FinalAmount = TotalAmount - DiscountAmount;
        }

        public void ConfirmOrder()
        {
            if (Status == OrderStatus.Created)
            {
                PaymentMethod.Amount = FinalAmount;
                PaymentMethod.Pay();
                Status = OrderStatus.Confirmed;
            }
            else
            {
                Console.WriteLine("Sipariş zaten onaylanmış veya başka aşamada.");
            }
        }

        public void PrepareOrder()
        {
            if (Status == OrderStatus.Confirmed)
            {
                Status = OrderStatus.Preparing;
                Console.WriteLine("Sipariş hazırlanmaya başlandı.");
            }
            else
            {
                Console.WriteLine("Sipariş onaylanmadan hazırlanamaz.");
            }
        }

        public void DeliverOrder()
        {
            if (Status == OrderStatus.Preparing)
            {
                Status = OrderStatus.Delivered;
                Console.WriteLine("Sipariş teslim edildi.");
            }
            else
            {
                Console.WriteLine("Sipariş hazırlanmadan teslim edilemez.");
            }
        }

        public void PrintOrderSummary()
        {
            Console.WriteLine($"Müşteri Bilgisi: {Customer.GetCustomerInfo()}");
            Console.WriteLine($"Sipariş Durumu: {Status}");
            Console.WriteLine($"Toplam Tutar: {TotalAmount} TL");
            Console.WriteLine($"İndirim Tutarı: {DiscountAmount} TL");
            Console.WriteLine($"Ödenecek Tutar: {FinalAmount} TL");
        }
    }
}
