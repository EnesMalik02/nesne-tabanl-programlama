using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Kullanıcıya menüyü göster ve seçim yapmasını iste
        while (true)
        {
            Console.WriteLine("Lütfen çalıştırmak istediğiniz soruyu seçin:");
            Console.WriteLine("1) Soru 1");
            Console.WriteLine("2) Soru 2");
            Console.WriteLine("3) Soru 3");
            Console.WriteLine("4) Soru 4");
            Console.WriteLine("5) Soru 5");
            Console.WriteLine("6) Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();
            Console.WriteLine();

            switch (secim)
            {
                case "1":
                    Soru1();
                    break;
                case "2":
                    Soru2();
                    break;
                case "3":
                    Soru3();
                    break;
                case "4":
                    Soru4();
                    break;
                case "5":
                    Soru5();
                    break;
                case "6":
                    return; // Programı sonlandır
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Soru 1:
    // Kullanıcıdan bir dizi tam sayı alın ve bu sayıları sıralayın.
    // Ardından, kullanıcıdan bir sayı alın ve bu sayının dizide olup olmadığını
    // ikili arama algoritması ile kontrol edin. Sonucu ekrana yazdırın.
    static void Soru1()
    {
        // Kullanıcıdan tam sayıları al
        List<int> sayilar = new List<int>();
        Console.WriteLine("Sayıları girin (tam sayı olmayan bir değer girerek bitirin):");
        while (true)
        {
            string girdi = Console.ReadLine();
            int sayi;
            if (int.TryParse(girdi, out sayi))
            {
                // Girilen değeri sayılar listesine ekle
                sayilar.Add(sayi);
            }
            else
            {
                // Tam sayı olmayan bir değer girildiğinde döngüyü sonlandır
                break;
            }
        }

        // Sayıları sırala
        sayilar.Sort();

        // Sıralanmış sayıları ekrana yazdır
        Console.WriteLine("Sıralanmış sayılar:");
        foreach (int sayi in sayilar)
        {
            Console.WriteLine(sayi);
        }

        // Kullanıcıdan aramak istediği sayıyı al
        Console.Write("Aramak istediğiniz sayıyı girin: ");
        int arananSayi;
        while (!int.TryParse(Console.ReadLine(), out arananSayi))
        {
            Console.Write("Lütfen geçerli bir tam sayı girin: ");
        }

        int sol = 0;
        int sag = sayilar.Count - 1;
        bool bulundu = false;

        // İkili arama algoritması
        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;
            if (sayilar[orta] == arananSayi)
            {
                // Sayı bulundu
                bulundu = true;
                break;
            }
            else if (sayilar[orta] < arananSayi)
            {
                // Aranan sayı sağ tarafta
                sol = orta + 1;
            }
            else
            {
                // Aranan sayı sol tarafta
                sag = orta - 1;
            }
        }

        // Sonucu ekrana yazdır
        if (bulundu)
        {
            Console.WriteLine("Aradığınız sayı dizide bulundu.");
        }
        else
        {
            Console.WriteLine("Aradığınız sayı dizide bulunamadı.");
        }
    }

    // Soru 2:
    // Kullanıcıdan pozitif tam sayılar alarak, bu sayıların ortalamasını ve medyanını
    // hesaplayan bir program yazın. Kullanıcı 0 girene kadar sayıları almaya devam etsin.
    // 0 girildiğinde ortalamayı ve medyanı gösterin.
    static void Soru2()
    {
        // Sayıları tutmak için bir liste oluştur
        List<int> sayilar = new List<int>();
        Console.WriteLine("Pozitif tam sayıları girin (0 girerek bitirin):");
        while (true)
        {
            int sayi;
            while (!int.TryParse(Console.ReadLine(), out sayi))
            {
                Console.Write("Lütfen geçerli bir tam sayı girin: ");
            }
            if (sayi == 0)
            {
                // 0 girildiyse döngüyü sonlandır
                break;
            }
            else if (sayi > 0)
            {
                // Sayıyı listeye ekle
                sayilar.Add(sayi);
            }
            else
            {
                // Negatif sayı girildiğinde uyarı ver
                Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
            }
        }

        // Ortalama hesapla
        double ortalama = 0;
        if (sayilar.Count > 0)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;
            }
            ortalama = (double)toplam / sayilar.Count;
        }

        // Medyanı hesapla
        double medyan = 0;
        if (sayilar.Count > 0)
        {
            // Sayıları sırala
            sayilar.Sort();
            int ortaIndex = sayilar.Count / 2;
            if (sayilar.Count % 2 == 0)
            {
                // Çift sayıda eleman varsa, ortadaki iki sayının ortalamasını al
                medyan = (sayilar[ortaIndex - 1] + sayilar[ortaIndex]) / 2.0;
            }
            else
            {
                // Tek sayıda eleman varsa, ortadaki sayı medyandır
                medyan = sayilar[ortaIndex];
            }
        }

        // Sonuçları ekrana yazdır
        Console.WriteLine("Ortalama: " + ortalama);
        Console.WriteLine("Medyan: " + medyan);
    }

    // Soru 3:
    // Kullanıcıdan bir dizi tamsayı alın ve bu dizideki ardışık sayı gruplarını tespit eden bir
    // program yazın. Örneğin, 1, 2, 3, 5, 6, 7, 10 dizisi için program, 1-3 ve 5-7 gruplarını
    // döndürmelidir. Kullanıcı 0 girene kadar sayıları almaya devam etsin.
    static void Soru3()
    {
        // Sayıları tutmak için bir liste oluştur
        List<int> sayilar = new List<int>();
        Console.WriteLine("Tam sayıları girin (0 girerek bitirin):");
        while (true)
        {
            int sayi;
            while (!int.TryParse(Console.ReadLine(), out sayi))
            {
                Console.Write("Lütfen geçerli bir tam sayı girin: ");
            }
            if (sayi == 0)
            {
                // 0 girildiyse döngüyü sonlandır
                break;
            }
            else
            {
                // Sayıyı listeye ekle
                sayilar.Add(sayi);
            }
        }

        // Sayıları sırala
        sayilar.Sort();

        // Ardışık sayı gruplarını bul
        List<string> gruplar = new List<string>();
        if (sayilar.Count > 0)
        {
            int baslangic = sayilar[0];
            int onceki = sayilar[0];

            for (int i = 1; i < sayilar.Count; i++)
            {
                if (sayilar[i] == onceki + 1)
                {
                    // Ardışık sayı
                    onceki = sayilar[i];
                }
                else
                {
                    // Grup sonlandı, grubu ekle
                    if (baslangic == onceki)
                    {
                        // Tek sayı
                        gruplar.Add(baslangic.ToString());
                    }
                    else
                    {
                        // Ardışık sayı grubu
                        gruplar.Add(baslangic + "-" + onceki);
                    }
                    // Yeni gruba başla
                    baslangic = sayilar[i];
                    onceki = sayilar[i];
                }
            }

            // Son grubu ekle
            if (baslangic == onceki)
            {
                gruplar.Add(baslangic.ToString());
            }
            else
            {
                gruplar.Add(baslangic + "-" + onceki);
            }
        }

        // Grupları ekrana yazdır
        Console.WriteLine("Ardışık sayı grupları:");
        foreach (string grup in gruplar)
        {
            Console.WriteLine(grup);
        }
    }

    // Soru 4:
    // Kullanıcının girdiği matematiksel ifadeyi işlem önceliklerine göre çözümleyen bir program yazın.
    // Program, sonucu yazdırmadan önce ifadenin çözüm sürecini açıklamalıdır (hangi işlemlerin hangi sırayla yapıldığını gösterin).
    static void Soru4()
    {
        Console.WriteLine("Matematiksel ifadeyi girin:");
        string ifade = Console.ReadLine();

        List<string> postfix = InfixToPostfix(ifade);
        Console.WriteLine("Postfix gösterimi: " + string.Join(" ", postfix));

        double sonuc = EvaluatePostfix(postfix);
        Console.WriteLine("Sonuç: " + sonuc);
    }

    // İşlem önceliklerini tanımla
    static Dictionary<string, int> oncelik = new Dictionary<string, int>
    {
        {"^", 4},
        {"/", 3},
        {"*", 3},
        {"+", 2},
        {"-", 2},
        {"(", 1}
    };

    // Orta düzenden (infix) son düzene (postfix) çevirme
    static List<string> InfixToPostfix(string infix)
    {
        Stack<string> islemYigini = new Stack<string>();
        List<string> postfix = new List<string>();

        // İfadeyi tokenize et
        string[] tokenler = Regex.Split(infix, @"(\D)");

        foreach (string token in tokenler)
        {
            string t = token.Trim();
            if (t == "")
                continue;

            double sayi;
            if (double.TryParse(t, out sayi))
            {
                // Sayıları postfix listesine ekle
                postfix.Add(t);
            }
            else if (t == "(")
            {
                // Açık parantezi yığına ekle
                islemYigini.Push(t);
            }
            else if (t == ")")
            {
                // Kapanış parantezi geldiğinde yığından işlemleri çıkar
                string top = islemYigini.Pop();
                while (top != "(")
                {
                    postfix.Add(top);
                    top = islemYigini.Pop();
                }
            }
            else
            {
                // İşlemin önceliğine göre yığına ekle veya yığından çıkar
                while (islemYigini.Count > 0 && oncelik.ContainsKey(islemYigini.Peek()) && oncelik[islemYigini.Peek()] >= oncelik[t])
                {
                    postfix.Add(islemYigini.Pop());
                }
                islemYigini.Push(t);
            }
        }

        // Yığında kalan işlemleri postfix listesine ekle
        while (islemYigini.Count > 0)
        {
            postfix.Add(islemYigini.Pop());
        }

        return postfix;
    }

    // Postfix ifadeyi değerlendir
    static double EvaluatePostfix(List<string> postfix)
    {
        Stack<double> degerYigini = new Stack<double>();

        foreach (string token in postfix)
        {
            double sayi;
            if (double.TryParse(token, out sayi))
            {
                // Sayıları yığına ekle
                degerYigini.Push(sayi);
            }
            else
            {
                // İşlemleri gerçekleştir
                double operand2 = degerYigini.Pop();
                double operand1 = degerYigini.Pop();
                double sonuc = 0;

                switch (token)
                {
                    case "+":
                        sonuc = operand1 + operand2;
                        break;
                    case "-":
                        sonuc = operand1 - operand2;
                        break;
                    case "*":
                        sonuc = operand1 * operand2;
                        break;
                    case "/":
                        sonuc = operand1 / operand2;
                        break;
                    case "^":
                        sonuc = Math.Pow(operand1, operand2);
                        break;
                }

                // Her adımı ekrana yazdır
                Console.WriteLine($"{operand1} {token} {operand2} = {sonuc}");
                degerYigini.Push(sonuc);
            }
        }

        // Sonucu döndür
        return degerYigini.Pop();
    }

    // Soru 5:
    // Kullanıcıdan iki polinom girmesini isteyin.
    // Program, bu iki polinomu toplayıp ve çıkararak sonuçları göstermelidir.
    // Kullanıcı, exit yazarak işlemi sonlandırana kadar yeni polinomlar girmeye devam etsin.
    static void Soru5()
    {
        while (true)
        {
            Console.WriteLine("İki polinom girin (örneğin: 2x^2+3x-5). Çıkmak için 'exit' yazın.");

            Console.Write("Polinom 1: ");
            string input1 = Console.ReadLine();
            if (input1.ToLower() == "exit")
                break;

            Console.Write("Polinom 2: ");
            string input2 = Console.ReadLine();
            if (input2.ToLower() == "exit")
                break;

            Polinom p1 = new Polinom(input1);
            Polinom p2 = new Polinom(input2);

            Polinom toplam = p1 + p2;
            Polinom fark = p1 - p2;

            Console.WriteLine("Toplam: " + toplam.ToString());
            Console.WriteLine("Fark: " + fark.ToString());
        }
    }
}

// Terim sınıfı: Polinomun her bir terimini temsil eder
class Terim
{
    public int Katsayi { get; set; }
    public int Us { get; set; }
}

// Polinom sınıfı: Polinom işlemlerini gerçekleştirir
class Polinom
{
    public List<Terim> Terimler { get; set; }

    public Polinom(string girdi)
    {
        // Polinomu parçala ve terimleri oluştur
        Terimler = Parse(girdi);
    }

    // Polinomu parçalama metodu
    private List<Terim> Parse(string girdi)
    {
        List<Terim> terimler = new List<Terim>();
        girdi = girdi.Replace(" ", "");
        Regex regex = new Regex(@"([+-]?)(\d*)(x?)(\^?)(\d*)");
        MatchCollection matches = regex.Matches(girdi);
        foreach (Match match in matches)
        {
            if (string.IsNullOrEmpty(match.Value))
                continue;

            int katsayi = 0;
            int us = 0;

            string isaret = match.Groups[1].Value;
            string katsayiStr = match.Groups[2].Value;
            string xVar = match.Groups[3].Value;
            string usStr = match.Groups[5].Value;

            // İşaret belirleme
            int isaretDegeri = (isaret == "-") ? -1 : 1;

            // Katsayı belirleme
            if (!string.IsNullOrEmpty(katsayiStr))
            {
                katsayi = int.Parse(katsayiStr) * isaretDegeri;
            }
            else
            {
                // Katsayı belirtilmemişse ve x varsa, katsayı 1 veya -1'dir
                if (!string.IsNullOrEmpty(xVar))
                {
                    katsayi = 1 * isaretDegeri;
                }
                else
                {
                    // Sadece sayı varsa
                    katsayi = 0;
                }
            }

            // Üs belirleme
            if (!string.IsNullOrEmpty(xVar))
            {
                if (!string.IsNullOrEmpty(usStr))
                {
                    us = int.Parse(usStr);
                }
                else
                {
                    us = 1;
                }
            }
            else
            {
                us = 0;
                katsayi = int.Parse(isaret + katsayiStr);
            }

            terimler.Add(new Terim { Katsayi = katsayi, Us = us });
        }
        return terimler;
    }

    // Polinom toplama işlemi
    public static Polinom operator +(Polinom p1, Polinom p2)
    {
        Dictionary<int, int> terimDict = new Dictionary<int, int>();
        // İlk polinomun terimlerini ekle
        foreach (var terim in p1.Terimler)
        {
            if (terimDict.ContainsKey(terim.Us))
            {
                terimDict[terim.Us] += terim.Katsayi;
            }
            else
            {
                terimDict[terim.Us] = terim.Katsayi;
            }
        }
        // İkinci polinomun terimlerini ekle
        foreach (var terim in p2.Terimler)
        {
            if (terimDict.ContainsKey(terim.Us))
            {
                terimDict[terim.Us] += terim.Katsayi;
            }
            else
            {
                terimDict[terim.Us] = terim.Katsayi;
            }
        }

        // Sonuç polinomunu oluştur
        Polinom sonuc = new Polinom("");
        sonuc.Terimler.Clear();
        foreach (var kvp in terimDict)
        {
            sonuc.Terimler.Add(new Terim { Katsayi = kvp.Value, Us = kvp.Key });
        }
        return sonuc;
    }

    // Polinom çıkarma işlemi
    public static Polinom operator -(Polinom p1, Polinom p2)
    {
        Dictionary<int, int> terimDict = new Dictionary<int, int>();
        // İlk polinomun terimlerini ekle
        foreach (var terim in p1.Terimler)
        {
            if (terimDict.ContainsKey(terim.Us))
            {
                terimDict[terim.Us] += terim.Katsayi;
            }
            else
            {
                terimDict[terim.Us] = terim.Katsayi;
            }
        }
        // İkinci polinomun terimlerini çıkar
        foreach (var terim in p2.Terimler)
        {
            if (terimDict.ContainsKey(terim.Us))
            {
                terimDict[terim.Us] -= terim.Katsayi;
            }
            else
            {
                terimDict[terim.Us] = -terim.Katsayi;
            }
        }

        // Sonuç polinomunu oluştur
        Polinom sonuc = new Polinom("");
        sonuc.Terimler.Clear();
        foreach (var kvp in terimDict)
        {
            sonuc.Terimler.Add(new Terim { Katsayi = kvp.Value, Us = kvp.Key });
        }
        return sonuc;
    }

    // Polinomu string olarak döndür
    public override string ToString()
    {
        // Terimleri üslerine göre sırala (büyükten küçüğe)
        Terimler.Sort((a, b) => b.Us.CompareTo(a.Us));
        string sonuc = "";
        foreach (var terim in Terimler)
        {
            if (terim.Katsayi == 0)
                continue;

            string katsayiStr = terim.Katsayi > 0 ? "+" + terim.Katsayi : terim.Katsayi.ToString();
            if (terim.Us == 0)
            {
                sonuc += katsayiStr;
            }
            else if (terim.Us == 1)
            {
                sonuc += katsayiStr + "x";
            }
            else
            {
                sonuc += katsayiStr + "x^" + terim.Us;
            }
        }
        if (sonuc.StartsWith("+"))
        {
            sonuc = sonuc.Substring(1);
        }
        return sonuc;
    }
}
