using System;
using System.Collections.Generic;

namespace AggregationExample
{
    // Ev ve Oda
    public class Ev
    {
        public string Ad { get; set; }
        public List<Oda> Odalar { get; set; } = new List<Oda>();

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }
    }

    public class Oda
    {
        public string Boyut { get; set; }
        public string Tip { get; set; }

        public Oda(string boyut, string tip)
        {
            Boyut = boyut;
            Tip = tip;
        }
    }

    // Şirket ve Çalışan
    public class Sirket
    {
        public string Ad { get; set; }
        public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }
    }

    public class Calisan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }

        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        public void CalisanBilgisi()
        {
            Console.WriteLine($"Çalışan: {Ad}, Pozisyon: {Pozisyon}");
        }
    }

    // Kütüphane ve Kitap
    public class Kutuphane
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }

    public class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }

        public Kitap(string baslik, string yazar)
        {
            Baslik = baslik;
            Yazar = yazar;
        }

        public void KitapBilgisi()
        {
            Console.WriteLine($"Kitap: {Baslik}, Yazar: {Yazar}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Örnek 1: Ev ve Oda
            Console.WriteLine("Ev ve Oda Örneği:");
            var ev = new Ev { Ad = "Ahşap Ev" };
            var oda1 = new Oda("20m²", "Yatak Odası");
            var oda2 = new Oda("15m²", "Mutfak");

            ev.OdaEkle(oda1);
            ev.OdaEkle(oda2);

            Console.WriteLine($"Ev: {ev.Ad}");
            foreach (var oda in ev.Odalar)
            {
                Console.WriteLine($"Oda: {oda.Tip}, Boyut: {oda.Boyut}");
            }

            Console.WriteLine("\n");

            // Örnek 2: Şirket ve Çalışan
            Console.WriteLine("Şirket ve Çalışan Örneği:");
            var sirket = new Sirket { Ad = "Teknoloji A.Ş." };
            var calisan1 = new Calisan("Ali", "Yazılım Geliştirici");
            var calisan2 = new Calisan("Ayşe", "Tasarımcı");

            sirket.CalisanEkle(calisan1);
            sirket.CalisanEkle(calisan2);

            Console.WriteLine($"Şirket: {sirket.Ad}");
            foreach (var calisan in sirket.Calisanlar)
            {
                calisan.CalisanBilgisi();
            }

            Console.WriteLine("\n");

            // Örnek 3: Kütüphane ve Kitap
            Console.WriteLine("Kütüphane ve Kitap Örneği:");
            var kutuphane = new Kutuphane { Ad = "Merkez Kütüphane" };
            var kitap1 = new Kitap("Suç ve Ceza", "Dostoyevski");
            var kitap2 = new Kitap("1984", "George Orwell");

            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);

            Console.WriteLine($"Kütüphane: {kutuphane.Ad}");
            foreach (var kitap in kutuphane.Kitaplar)
            {
                kitap.KitapBilgisi();
            }
        }
    }
}
