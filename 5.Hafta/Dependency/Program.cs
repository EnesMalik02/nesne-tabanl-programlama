using System;
using System.Collections.Generic;

namespace CompositionExample
{
    // Bilgisayar ve İşlemci
    public class Bilgisayar
    {
        public string Model { get; set; }
        public Islemci Islemci { get; private set; }

        public Bilgisayar(string model, int cekirdekler, int frekans)
        {
            Model = model;
            Islemci = new Islemci(cekirdekler, frekans);
        }

        public void BilgisayarBilgisi()
        {
            Console.WriteLine($"Bilgisayar: {Model}");
            Islemci.IslemciBilgisi();
        }
    }

    public class Islemci
    {
        public int Cekirdekler { get; set; }
        public int Frekans { get; set; } // MHz

        public Islemci(int cekirdekler, int frekans)
        {
            Cekirdekler = cekirdekler;
            Frekans = frekans;
        }

        public void IslemciBilgisi()
        {
            Console.WriteLine($"İşlemci: {Cekirdekler} Çekirdek, {Frekans} MHz");
        }
    }

    // Otomobil ve Motor
    public class Otomobil
    {
        public string Marka { get; set; }
        public Motor Motor { get; private set; }

        public Otomobil(string marka, int guc, string tip)
        {
            Marka = marka;
            Motor = new Motor(guc, tip);
        }

        public void OtomobilBilgisi()
        {
            Console.WriteLine($"Otomobil: {Marka}");
            Motor.MotorBilgisi();
        }
    }

    public class Motor
    {
        public int Guc { get; set; } // Beygir Gücü
        public string Tip { get; set; }

        public Motor(int guc, string tip)
        {
            Guc = guc;
            Tip = tip;
        }

        public void MotorBilgisi()
        {
            Console.WriteLine($"Motor: {Guc} HP, Tip: {Tip}");
        }
    }

    // Okul ve Öğrenci
    public class Okul
    {
        public string Ad { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; } = new List<Ogrenci>();

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            Ogrenciler.Add(ogrenci);
        }

        public void OkulBilgisi()
        {
            Console.WriteLine($"Okul: {Ad}");
            foreach (var ogrenci in Ogrenciler)
            {
                ogrenci.OgrenciBilgisi();
            }
        }
    }

    public class Ogrenci
    {
        public string Ad { get; set; }
        public int Yas { get; set; }

        public Ogrenci(string ad, int yas)
        {
            Ad = ad;
            Yas = yas;
        }

        public void OgrenciBilgisi()
        {
            Console.WriteLine($"Öğrenci: {Ad}, Yaş: {Yas}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Örnek 1: Bilgisayar ve İşlemci
            Console.WriteLine("Bilgisayar ve İşlemci Örneği:");
            var bilgisayar = new Bilgisayar("Dell XPS 15", 8, 2400);
            bilgisayar.BilgisayarBilgisi();

            Console.WriteLine("\n");

            // Örnek 2: Otomobil ve Motor
            Console.WriteLine("Otomobil ve Motor Örneği:");
            var otomobil = new Otomobil("Toyota Corolla", 132, "Benzin");
            otomobil.OtomobilBilgisi();

            Console.WriteLine("\n");

            // Örnek 3: Okul ve Öğrenci
            Console.WriteLine("Okul ve Öğrenci Örneği:");
            var okul = new Okul { Ad = "Anadolu Lisesi" };
            var ogrenci1 = new Ogrenci("Ali", 16);
            var ogrenci2 = new Ogrenci("Ayşe", 17);

            okul.OgrenciEkle(ogrenci1);
            okul.OgrenciEkle(ogrenci2);

            okul.OkulBilgisi();
        }
    }
}
