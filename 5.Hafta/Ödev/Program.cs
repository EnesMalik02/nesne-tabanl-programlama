using System;
using System.Collections.Generic;

namespace Ornek1_InsanVeKalp
{
    class Kalp
    {
        public int KanBasinci { get; set; }
        public int Nabiz { get; set; }

        public Kalp(int kanBasinci, int nabiz)
        {
            KanBasinci = kanBasinci;
            Nabiz = nabiz;
        }

        public void KalpBilgisi()
        {
            Console.WriteLine($"Kan Basıncı: {KanBasinci}, Nabız: {Nabiz}");
        }
    }

    class Insan
    {
        public string Ad { get; set; }
        public Kalp Kalp { get; set; }

        public Insan(string ad)
        {
            Ad = ad;
            Kalp = new Kalp(120, 70);
        }
    }
}

namespace Ornek2_YazarVeKitap
{
    class Kitap
    {
        public string Baslik { get; set; }
        public string ISBN { get; set; }

        public Kitap(string baslik, string isbn)
        {
            Baslik = baslik;
            ISBN = isbn;
        }
    }

    class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Console.WriteLine($"{Ad} adlı yazarın yeni kitabı eklendi: {kitap.Baslik}");
        }
    }
}

namespace Ornek3_CalisanVeDepartman
{
    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        public Calisan(string ad, string pozisyon, Departman departman)
        {
            Ad = ad;
            Pozisyon = pozisyon;
            Departman = departman;
        }
    }
}

namespace Ornek4_UrunVeSiparis
{
    class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        public Urun(string ad, int fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public void UrunBilgisi()
        {
            Console.WriteLine($"Ürün: {Ad}, Fiyat: {Fiyat}");
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }

        public Siparis(DateTime tarih, decimal toplam)
        {
            Tarih = tarih;
            Toplam = toplam;
        }
    }
}

namespace Ornek5_MusteriVeSiparis
{
    class Urun
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }

        public Urun(string ad, string telefon)
        {
            Ad = ad;
            Telefon = telefon;
        }

        public void SiparisVer(Siparis siparis)
        {
            Console.WriteLine($"{Ad} adlı ürün için sipariş verildi. Sipariş Tarihi: {siparis.Tarih}, Durum: {siparis.Durum}");
        }
    }

    class Siparis
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }

        public Siparis(DateTime tarih, string durum)
        {
            Tarih = tarih;
            Durum = durum;
        }
    }

    class Musteri
    {
        public string Ad { get; set; }
        public List<Siparis> Siparisler { get; private set; }

        public Musteri(string ad)
        {
            Ad = ad;
            Siparisler = new List<Siparis>();
        }

        public void SiparisEkle(Siparis siparis)
        {
            Siparisler.Add(siparis);
            Console.WriteLine($"{Ad} adlı müşteri yeni bir sipariş ekledi. Sipariş Tarihi: {siparis.Tarih}, Durum: {siparis.Durum}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ornek 1: İnsan ve Kalp
        var insan = new Ornek1_InsanVeKalp.Insan("Ömer");
        insan.Kalp.KalpBilgisi();

        // Ornek 2: Yazar ve Kitap
        var yazar = new Ornek2_YazarVeKitap.Yazar("Ahmet Ümit", "Türkiye");
        yazar.KitapEkle(new Ornek2_YazarVeKitap.Kitap("İstanbul Hatırası", "1234567890"));

        // Ornek 3: Çalışan ve Departman
        var departman = new Ornek3_CalisanVeDepartman.Departman("IT", "İstanbul");
        var calisan = new Ornek3_CalisanVeDepartman.Calisan("Ayşe", "Yazılım Mühendisi", departman);

        // Ornek 4: Ürün ve Sipariş
        var urun1 = new Ornek4_UrunVeSiparis.Urun("Laptop", 5000);
        urun1.UrunBilgisi();
        var siparis1 = new Ornek4_UrunVeSiparis.Siparis(DateTime.Now, 5000);

        // Ornek 5: Müşteri ve Sipariş
        var urun2 = new Ornek5_MusteriVeSiparis.Urun("Telefon", "+905551234567");
        var musteri = new Ornek5_MusteriVeSiparis.Musteri("Ömer");
        var siparis2 = new Ornek5_MusteriVeSiparis.Siparis(DateTime.Now, "Hazırlanıyor");
        musteri.SiparisEkle(siparis2);
        urun2.SiparisVer(siparis2);
    }
}
