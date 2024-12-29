using System;
using System.Collections.Generic;

namespace BankaMagazaObserver
{
    // 1. Bölüm: Banka Hesap Sistemi
    public abstract class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);
    }

    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    public class BirikimHesabi : Hesap, IBankaHesabi
    {
        public double FaizOrani { get; set; } = 0.03;
        public DateTime HesapAcilisTarihi { get; set; } = DateTime.Now;

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar + (miktar * (decimal)FaizOrani);
            Console.WriteLine($"{miktar} TL yatırıldı. Faiz uygulandı. Yeni Bakiye: {Bakiye}");
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni Bakiye: {Bakiye}");
            }
            else
                Console.WriteLine("Bakiye yetersiz.");
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Birikim Hesap No: {HesapNo}, Bakiye: {Bakiye}, Faiz Oranı: {FaizOrani}, Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }

    public class VadesizHesap : Hesap, IBankaHesabi
    {
        public DateTime HesapAcilisTarihi { get; set; } = DateTime.Now;
        private decimal IslemUcreti = 2.5m;

        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Yeni Bakiye: {Bakiye}");
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar + IslemUcreti)
            {
                Bakiye -= (miktar + IslemUcreti);
                Console.WriteLine($"{miktar} TL çekildi. İşlem üreti ({IslemUcreti} TL) kesildi. Yeni Bakiye: {Bakiye}");
            }
            else
                Console.WriteLine("Bakiye yetersiz.");
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Vadesiz Hesap No: {HesapNo}, Bakiye: {Bakiye}, Açılış Tarihi: {HesapAcilisTarihi}");
        }
    }

    // 2. Bölüm: Mağaza Sistemi
    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public abstract decimal HesaplaOdeme();
        public void BilgiYazdir()
        {
            Console.WriteLine($"Urun: {Ad}, Fiyat: {Fiyat}, Ödenecek Tutar: {HesaplaOdeme()}");
        }
    }

    public class Kitap : Urun
    {
        public override decimal HesaplaOdeme()
        {
            return Fiyat * 1.10m; // %10 vergi
        }
    }

    public class Elektronik : Urun
    {
        public override decimal HesaplaOdeme()
        {
            return Fiyat * 1.25m; // %25 vergi
        }
    }

    // 3. Bölüm: Observer Deseni
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void BildirimGonder(string mesaj);
    }

    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
        }

        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
        }

        public void BildirimGonder(string mesaj)
        {
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj);
            }
        }
    }

    public class Abone : IAbone
    {
        public string Ad { get; set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} bilgisi alındı: {mesaj}");
        }
    }

    // Program Test
    class Program
    {
        static void Main(string[] args)
        {
            // Banka Sistemi Testi
            BirikimHesabi birikim = new BirikimHesabi { HesapNo = "B123", Bakiye = 5000 };
            VadesizHesap vadesiz = new VadesizHesap { HesapNo = "V456", Bakiye = 3000 };
            birikim.ParaYatir(1000);
            birikim.ParaCek(200);
            birikim.HesapOzeti();
            vadesiz.ParaCek(500);
            vadesiz.HesapOzeti();

            // Mağaza Sistemi Testi
            List<Urun> urunler = new List<Urun>
            {
                new Kitap { Ad = "C# Kitabı", Fiyat = 100 },
                new Elektronik { Ad = "Laptop", Fiyat = 5000 }
            };

            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }

            // Observer Deseni Testi
            Yayinci yayinci = new Yayinci();
            IAbone abone1 = new Abone("Ali");
            IAbone abone2 = new Abone("Ayşe");

            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.BildirimGonder("Yeni haber yayınlandı!");
        }
    }
}
