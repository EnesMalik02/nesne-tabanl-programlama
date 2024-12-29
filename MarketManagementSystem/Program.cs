using System;
using System.Collections.Generic;
using MarketManagementSystem.Entities;
using MarketManagementSystem.Entities.Abstract;
using MarketManagementSystem.Entities.Discounts;
using MarketManagementSystem.Entities.Payments;
using MarketManagementSystem.Entities.Customers;

namespace MarketManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Örnek Ürünler
                Product product1 = new Product
                {
                    Id = 1,
                    Name = "Elma",
                    Price = 5.5m
                };
                Product product2 = new Product
                {
                    Id = 2,
                    Name = "Peynir",
                    Price = 30m
                };
                Product product3 = new Product
                {
                    Id = 3,
                    Name = "Çikolata",
                    Price = 15m
                };

                // Müşteriler
                IndividualCustomer customer1 = new IndividualCustomer
                {
                    Id = 101,
                    FirstName = "Ali",
                    LastName = "Yılmaz",
                    TCKN = "12345678901"
                };

                CorporateCustomer customer2 = new CorporateCustomer
                {
                    Id = 102,
                    CompanyName = "ABC Gıda A.Ş.",
                    TaxNumber = "1234567890"
                };

                // Sepet ve Ürün Ekleme
                Cart cart = new Cart();
                cart.AddProduct(product1, 4); // 4 adet Elma
                cart.AddProduct(product2, 1); // 1 adet Peynir
                cart.AddProduct(product3, 2); // 2 adet Çikolata

                // İndirim seçenekleri
                Discount discount1 = new PercentageDiscount(10); // %10 indirim
                Discount discount2 = new FixedDiscount(20); // 20 TL sabit indirim

                // Ödeme yöntemleri
                Payment payment1 = new CreditCardPayment
                {
                    CardNumber = "1111 2222 3333 4444",
                    CardHolderName = "Ali Yılmaz",
                    ExpiryDate = "12/28"
                };

                Payment payment2 = new CashPayment();
                Payment payment3 = new BankTransferPayment
                {
                    BankName = "XYZ Bank",
                    IBAN = "TR123456789012345678901234"
                };

                // Sipariş oluşturma
                Order order1 = new Order(cart, customer1, payment1);
                order1.ApplyDiscount(discount1); // %10 indirim uygula
                order1.ConfirmOrder(); // Siparişi Onayla

                Console.WriteLine("----- Sipariş 1 Özeti -----");
                order1.PrintOrderSummary();
                Console.WriteLine("******************************\n");

                // İkinci sipariş
                Cart cart2 = new Cart();
                cart2.AddProduct(product1, 2);
                cart2.AddProduct(product3, 3);

                Order order2 = new Order(cart2, customer2, payment3);
                order2.ApplyDiscount(discount2); // 20 TL sabit indirim uygula
                order2.ConfirmOrder();
                order2.PrepareOrder(); // Sipariş hazırlama aşamasına geç
                order2.DeliverOrder(); // Siparişi teslim et

                Console.WriteLine("----- Sipariş 2 Özeti -----");
                order2.PrintOrderSummary();
            }
            catch (Exception ex)
            {
                // Tüm beklenmeyen hataları yakalayabiliriz
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            Console.WriteLine("\nProgram sonlanıyor, devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
