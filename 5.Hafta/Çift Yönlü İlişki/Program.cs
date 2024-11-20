using System;
using System.Collections.Generic;

namespace Ornek2_DoktorHasta
{
    public class Doktor
    {
        public string Ad { get; set; }
        public string Brans { get; set; }
        public List<Hasta> Hastalar { get; set; } = new List<Hasta>();

        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
            hasta.DoktorAtama(this);
        }
    }

    public class Hasta
    {
        public string Ad { get; set; }
        public string TCNo { get; set; }
        public Doktor Doktor { get; private set; }

        public void DoktorAtama(Doktor doktor)
        {
            Doktor = doktor;
            if (!doktor.Hastalar.Contains(this))
            {
                doktor.HastaEkle(this);
            }
        }
    }
}

namespace Ornek3_YazarKitap
{
    public class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            kitap.YazarAtama(this);
        }
    }

    public class Kitap
    {
        public string Baslik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public Yazar Yazar { get; private set; }

        public void YazarAtama(Yazar yazar)
        {
            Yazar = yazar;
            if (!yazar.Kitaplar.Contains(this))
            {
                yazar.KitapEkle(this);
            }
        }
    }
}

namespace Ornek4_SirketCalisan
{
    public class Sirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Calisan> Calisanlar { get; set; } = new List<Calisan>();

        public void CalisanEkle(Calisan calisan)
        {
            Calisanlar.Add(calisan);
            calisan.SirketAtama(this);
        }
    }

    public class Calisan
    {
        public string Ad { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public Sirket Sirket { get; private set; }

        public void SirketAtama(Sirket sirket)
        {
            Sirket = sirket;
            if (!sirket.Calisanlar.Contains(this))
            {
                sirket.CalisanEkle(this);
            }
        }
    }
}

namespace Ornek5_EbeveynCocuk
{
    public class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public List<Cocuk> Cocuklar { get; set; } = new List<Cocuk>();

        public void CocukEkle(Cocuk cocuk)
        {
            Cocuklar.Add(cocuk);
            cocuk.EbeveynAtama(this);
        }
    }

    public class Cocuk
    {
        public string Ad { get; set; }
        public int Yas { get; set; }
        public Ebeveyn Ebeveyn { get; private set; }

        public void EbeveynAtama(Ebeveyn ebeveyn)
        {
            Ebeveyn = ebeveyn;
            if (!ebeveyn.Cocuklar.Contains(this))
            {
                ebeveyn.CocukEkle(this);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ornek 2: Doktor ve Hasta
        var doktor = new Ornek2_DoktorHasta.Doktor { Ad = "Dr. Ahmet", Brans = "Kardiyoloji" };
        var hasta = new Ornek2_DoktorHasta.Hasta { Ad = "Ali", TCNo = "12345678901" };
        doktor.HastaEkle(hasta);

        Console.WriteLine($"Doktor: {doktor.Ad}, Hastalar: {doktor.Hastalar[0].Ad}");
        Console.WriteLine($"Hasta: {hasta.Ad}, Doktor: {hasta.Doktor.Ad}");

        // Ornek 3: Yazar ve Kitap
        var yazar = new Ornek3_YazarKitap.Yazar { Ad = "Orhan Pamuk", Ulke = "Türkiye" };
        var kitap = new Ornek3_YazarKitap.Kitap { Baslik = "Masumiyet Müzesi", YayinTarihi = new DateTime(2008, 1, 1) };
        yazar.KitapEkle(kitap);

        Console.WriteLine($"Yazar: {yazar.Ad}, Kitaplar: {yazar.Kitaplar[0].Baslik}");
        Console.WriteLine($"Kitap: {kitap.Baslik}, Yazar: {kitap.Yazar.Ad}");

        // Ornek 4: Şirket ve Çalışan
        var sirket = new Ornek4_SirketCalisan.Sirket { Ad = "Teknoloji A.Ş.", Konum = "Ankara" };
        var calisan = new Ornek4_SirketCalisan.Calisan { Ad = "Mehmet", IseGirisTarihi = DateTime.Now };
        sirket.CalisanEkle(calisan);

        Console.WriteLine($"Şirket: {sirket.Ad}, Çalışanlar: {sirket.Calisanlar[0].Ad}");
        Console.WriteLine($"Çalışan: {calisan.Ad}, Şirket: {calisan.Sirket.Ad}");

        // Ornek 5: Ebeveyn ve Çocuk
        var ebeveyn = new Ornek5_EbeveynCocuk.Ebeveyn { Ad = "Ayşe", Yas = 40 };
        var cocuk = new Ornek5_EbeveynCocuk.Cocuk { Ad = "Fatma", Yas = 10 };
        ebeveyn.CocukEkle(cocuk);

        Console.WriteLine($"Ebeveyn: {ebeveyn.Ad}, Çocuklar: {ebeveyn.Cocuklar[0].Ad}");
        Console.WriteLine($"Çocuk: {cocuk.Ad}, Ebeveyn: {cocuk.Ebeveyn.Ad}");
    }
}
