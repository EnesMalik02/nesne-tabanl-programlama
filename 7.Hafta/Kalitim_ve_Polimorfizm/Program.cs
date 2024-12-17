using System;

namespace MultiScenarioProgram
{
    // 1. Senaryo: Şirket Yönetim Sistemi
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maas: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazilim Dili: {YazilimDili}");
        }
    }

    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    // 2. Senaryo: Hayvanat Bahçesi Sistemi
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Genel hayvan sesi");
        }
    }

    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Memeli sesi: Homurdanma");
        }
    }

    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine("Kus sesi: Cik cik");
        }
    }

    // 3. Senaryo: Banka Sistemi
    class Hesap
    {
        public string HesapNo { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni Bakiye: {Bakiye}");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni Bakiye: {Bakiye}");
            }
            else
            {
                Console.WriteLine("Bakiye yetersiz.");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}");
        }
    }

    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni Bakiye: {Bakiye}");
            }
            else
            {
                Console.WriteLine("Bakiye ve ek hesap limiti yetersiz.");
            }
        }
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; }
        public double FaizOrani { get; set; }
        public bool VadeDoldu { get; set; } = false;

        public override void ParaCek(decimal miktar)
        {
            if (!VadeDoldu)
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz!");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Senaryo: Şirket Sistemi\n2. Senaryo: Hayvan Sistemi\n3. Senaryo: Banka Sistemi");
            Console.Write("Seçim yapınız: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    Calisan calisan;
                    Console.WriteLine("Calisan turu: (1) Yazilimci, (2) Muhasebeci");
                    int tur = int.Parse(Console.ReadLine());
                    if (tur == 1)
                    {
                        calisan = new Yazilimci { Ad = "Ali", Soyad = "Yilmaz", Maas = 12000, Pozisyon = "Kidemli", YazilimDili = "C#" };
                    }
                    else
                    {
                        calisan = new Muhasebeci { Ad = "Ayşe", Soyad = "Kara", Maas = 10000, Pozisyon = "Uzman", MuhasebeYazilimi = "Logo" };
                    }
                    calisan.BilgiYazdir();
                    break;
                case 2:
                    Hayvan hayvan;
                    Console.WriteLine("Hayvan turu: (1) Memeli, (2) Kus");
                    int hayvanTur = int.Parse(Console.ReadLine());
                    if (hayvanTur == 1)
                    {
                        hayvan = new Memeli { Ad = "Aslan", Tur = "Yirtici", Yas = 5, TuyRengi = "Sari" };
                    }
                    else
                    {
                        hayvan = new Kus { Ad = "Kartal", Tur = "Yirtici Kus", Yas = 3, KanatGenisligi = 2.1 };
                    }
                    hayvan.SesCikar();
                    break;
                case 3:
                    Hesap hesap;
                    Console.WriteLine("Hesap turu: (1) Vadesiz, (2) Vadeli");
                    int hesapTur = int.Parse(Console.ReadLine());
                    if (hesapTur == 1)
                    {
                        hesap = new VadesizHesap { HesapNo = "1234", HesapSahibi = "Mehmet", Bakiye = 5000, EkHesapLimiti = 2000 };
                    }
                    else
                    {
                        hesap = new VadeliHesap { HesapNo = "5678", HesapSahibi = "Zeynep", Bakiye = 10000, VadeSuresi = 12, FaizOrani = 0.05 };
                    }
                    hesap.ParaYatir(1000);
                    hesap.ParaCek(2000);
                    hesap.BilgiYazdir();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
