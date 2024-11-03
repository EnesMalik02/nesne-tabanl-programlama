using System;
using System.Collections.Generic;

namespace Sorular
{
    // Soru 1: BankaHesabı Sınıfı
    public class BankaHesabi
    {
        public string HesapNumarasi { get; private set; }
        public decimal Bakiye { get; private set; }

        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
            }
        }

        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem yapılamadı.");
            }
        }
    }

    // Soru 2: Ürün Sınıfı
    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        private decimal indirim;
        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value < 0)
                    indirim = 0;
                else if (value > 50)
                    indirim = 50;
                else
                    indirim = value;
            }
        }

        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
            Indirim = 0;
        }

        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }

    // Soru 3: Araç Kiralama Sınıfı
    public class KiralikArac
    {
        public string Plaka { get; set; }
        public decimal GunlukUcret { get; set; }
        public bool MusaitMi { get; private set; }

        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine($"{Plaka} plakalı araç kiralandı.");
            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı araç zaten kirada.");
            }
        }

        public void AraciTeslimEt()
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine($"{Plaka} plakalı araç teslim edildi.");
            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı araç zaten müsait durumda.");
            }
        }
    }

    // Soru 4: Adres Defteri Sınıfı
    public class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }

        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        public string KisiBilgisi()
        {
            return $"{Ad} {Soyad} - Telefon: {TelefonNumarasi}";
        }
    }

    // Soru 5: Kütüphane Sınıfı
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public Kutuphane Kutuphane { get; private set; }

        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }

        public void SetKutuphane(Kutuphane kutuphane)
        {
            Kutuphane = kutuphane;
        }
    }

    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; private set; }

        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap yeniKitap)
        {
            if (yeniKitap != null)
            {
                Kitaplar.Add(yeniKitap);
                yeniKitap.SetKutuphane(this); // 'this' anahtar kelimesi kullanıldı
                Console.WriteLine($"{yeniKitap.Ad} adlı kitap kütüphaneye eklendi.");
            }
        }

        public void KitaplariListele()
        {
            Console.WriteLine("Kütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"Kitap: {kitap.Ad}, Yazar: {kitap.Yazar}");
            }
        }
    }

    // Program Sınıfı ve Main Metodu
    class Program
    {
        static void Main(string[] args)
        {
            // Soru 1: BankaHesabi
            Console.WriteLine("Banka Hesabı İşlemleri:");
            BankaHesabi hesap = new BankaHesabi("1234567890", 1000);
            hesap.ParaYatir(500);
            hesap.ParaCek(200);
            hesap.ParaCek(1500); // Yetersiz bakiye durumu
            Console.WriteLine();

            // Soru 2: Urun
            Console.WriteLine("Ürün İşlemleri:");
            Urun urun = new Urun("Laptop", 5000);
            urun.Indirim = 10;
            Console.WriteLine($"Ürün: {urun.Ad}, Fiyat: {urun.Fiyat} TL, İndirimli Fiyat: {urun.IndirimliFiyat()} TL");
            urun.Indirim = 60; // İndirim %50 ile sınırlandırılmalı
            Console.WriteLine($"Yeni İndirim: {urun.Indirim}%, İndirimli Fiyat: {urun.IndirimliFiyat()} TL");
            Console.WriteLine();

            // Soru 3: KiralikArac
            Console.WriteLine("Araç Kiralama İşlemleri:");
            KiralikArac arac = new KiralikArac("34ABC123", 150);
            arac.AraciKirala();
            arac.AraciKirala(); // Araç zaten kirada
            arac.AraciTeslimEt();
            arac.AraciTeslimEt(); // Araç zaten müsait
            Console.WriteLine();

            // Soru 4: Kisi
            Console.WriteLine("Adres Defteri İşlemleri:");
            Kisi kisi = new Kisi("Ali", "Yılmaz", "0555 123 45 67");
            Console.WriteLine(kisi.KisiBilgisi());
            Console.WriteLine();

            // Soru 5: Kutuphane ve Kitap
            Console.WriteLine("Kütüphane İşlemleri:");
            Kutuphane kutuphane = new Kutuphane();
            Kitap kitap1 = new Kitap("Sefiller", "Victor Hugo");
            Kitap kitap2 = new Kitap("Suç ve Ceza", "Fyodor Dostoyevski");
            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);
            kutuphane.KitaplariListele();
            Console.WriteLine();

            Console.WriteLine("Program sonlandı. Çıkmak için bir tuşa basın.");
            Console.ReadKey();
        }
    }
}
