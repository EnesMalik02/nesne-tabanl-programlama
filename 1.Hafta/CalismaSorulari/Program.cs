using System;
using System.Collections.Generic;

class Program
{
    // Ana programın başlangıç noktası
    static void Main(string[] args)
    {
        // Sınıfların ana metodlarını çağırıyoruz.
        SpiralMatris.RunSpiralMatris();
        MatrisCarpimi.RunMatrisCarpimi();
        AsalSayilarToplami.RunAsalSayilarToplami();
        TechCity.RunTechCity();
        AltinTapinak.RunAltinTapinak();
    }
}

// 1. Spiral Matris
class SpiralMatris
{
    public static void RunSpiralMatris() // Artık bir `Main` değil, sınıf çağrısıyla çalışacak metod
    {
        Console.Write("Lütfen matrisin boyutunu giriniz (N): ");
        int N = int.Parse(Console.ReadLine());

        int[,] matris = new int[N, N];
        int sol = 0, sağ = N - 1, üst = 0, alt = N - 1;
        int sayı = 1;

        while (sayı <= N * N)
        {
            for (int i = sol; i <= sağ; i++) matris[üst, i] = sayı++;
            üst++;

            for (int i = üst; i <= alt; i++) matris[i, sağ] = sayı++;
            sağ--;

            for (int i = sağ; i >= sol; i--) matris[alt, i] = sayı++;
            alt--;

            for (int i = alt; i >= üst; i--) matris[i, sol] = sayı++;
            sol++;
        }

        // Spiral matrisi ekrana yazdırıyoruz
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(matris[i, j].ToString().PadLeft(4));
            Console.WriteLine();
        }
    }
}

// 2. Matris Çarpımı
class MatrisCarpimi
{
    public static void RunMatrisCarpimi() // Ana fonksiyon
    {
        Console.Write("Lütfen matrislerin boyutunu giriniz (N): ");
        int N = int.Parse(Console.ReadLine());

        int[,] matris1 = new int[N, N];
        int[,] matris2 = new int[N, N];
        int[,] sonucMatrisi = new int[N, N];

        Console.WriteLine("Birinci matrisin elemanlarını giriniz:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Matris1[{i + 1},{j + 1}]: ");
                matris1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("İkinci matrisin elemanlarını giriniz:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Matris2[{i + 1},{j + 1}]: ");
                matris2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Matris çarpımını gerçekleştiriyoruz
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                int toplam = 0;
                for (int k = 0; k < N; k++)
                    toplam += matris1[i, k] * matris2[k, j];
                sonucMatrisi[i, j] = toplam;
            }
        }

        Console.WriteLine("Matrislerin çarpımının sonucu:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(sonucMatrisi[i, j].ToString().PadLeft(6));
            Console.WriteLine();
        }
    }
}

// 3. Asal Sayıların Toplamı
class AsalSayilarToplami
{
    public static void RunAsalSayilarToplami()
    {
        Console.Write("Lütfen N sayısını giriniz: ");
        int N = int.Parse(Console.ReadLine());

        int toplam = 0;
        for (int sayi = 2; sayi <= N; sayi++)
        {
            if (AsalMi(sayi)) toplam += sayi;
        }

        Console.WriteLine($"0'dan {N}'ye kadar olan asal sayıların toplamı: {toplam}");
    }

    static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false;
        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0) return false;
        }
        return true;
    }
}

// 4. TechCity - Robotlar ve Grid

class TechCity
{
    static int N;
    static int[,] grid;
    static bool[,] ziyaretEdildi; // Ziyaret edilen düğümleri takip eder
    static int[] dx = { -1, 1, 0, 0 }; // Yukarı ve aşağı hareket
    static int[] dy = { 0, 0, -1, 1 }; // Sol ve sağ hareket

    public static void RunTechCity()
    {
        // Grid boyutunu alıyoruz
        Console.Write("Lütfen grid boyutunu giriniz (N): ");
        N = int.Parse(Console.ReadLine());

        // Grid ve ziyaret matrislerini başlatıyoruz
        grid = new int[N, N];
        ziyaretEdildi = new bool[N, N];

        // Grid değerlerini kullanıcıdan alıyoruz
        Console.WriteLine("Grid değerlerini giriniz (0 veya 1):");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                bool gecerliDeger = false;
                while (!gecerliDeger) // Geçerli değer girene kadar tekrar iste
                {
                    Console.Write($"Grid[{i},{j}] (0 veya 1): ");
                    int deger = int.Parse(Console.ReadLine());
                    if (deger == 0 || deger == 1) // Sadece 0 veya 1 değerini kabul ediyoruz
                    {
                        grid[i, j] = deger;
                        gecerliDeger = true;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen sadece 0 veya 1 giriniz.");
                    }
                }
            }
        }

        // Robotların başlangıç pozisyonlarını alıyoruz
        List<Tuple<int, int>> robotPozisyonlari = new List<Tuple<int, int>>();
        Console.WriteLine("Robotların başlangıç pozisyonlarını giriniz:");
        for (int k = 1; k <= 3; k++)
        {
            int x, y;
            bool gecerliPozisyon = false;

            while (!gecerliPozisyon)
            {
                Console.Write($"Robot {k} X koordinatı (0-{N-1}): ");
                x = int.Parse(Console.ReadLine());
                Console.Write($"Robot {k} Y koordinatı (0-{N-1}): ");
                y = int.Parse(Console.ReadLine());

                if (x >= 0 && x < N && y >= 0 && y < N && grid[x, y] == 1) // Pozisyon grid sınırları ve geçerli mi?
                {
                    robotPozisyonlari.Add(new Tuple<int, int>(x, y));
                    gecerliPozisyon = true;
                }
                else
                {
                    Console.WriteLine($"Geçersiz pozisyon girdiniz veya zarar görmüş bir düğüm seçtiniz! Lütfen tekrar deneyin.");
                }
            }
        }

        // Robotların kurtardığı düğüm sayısını hesaplayalım
        int toplamKurtarilan = 0;
        for (int i = 0; i < robotPozisyonlari.Count; i++)
        {
            int kurtarilan = BFS(robotPozisyonlari[i].Item1, robotPozisyonlari[i].Item2);
            Console.WriteLine($"Robot {i + 1} pozisyonundan {kurtarilan} düğüm kurtardı.");
            toplamKurtarilan += kurtarilan;
        }

        // Toplam kurtarılan düğüm sayısı
        Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {toplamKurtarilan}");
    }

    // BFS algoritması ile bir robotun kaç düğüm kurtardığını hesaplar
    static int BFS(int baslangicX, int baslangicY)
    {
        if (grid[baslangicX, baslangicY] == 0 || ziyaretEdildi[baslangicX, baslangicY]) // Eğer geçilemezse geri dön
        {
            return 0;
        }

        int sayac = 1; // Kurtarılan düğüm sayısını tutar
        Queue<Tuple<int, int>> kuyruk = new Queue<Tuple<int, int>>();
        kuyruk.Enqueue(new Tuple<int, int>(baslangicX, baslangicY)); // Başlangıç noktasını kuyruğa ekliyoruz
        ziyaretEdildi[baslangicX, baslangicY] = true; // Ziyaret edildi olarak işaretliyoruz

        while (kuyruk.Count > 0) // Kuyruk boşalana kadar devam et
        {
            var mevcut = kuyruk.Dequeue(); // Kuyruktan eleman çıkar
            int x = mevcut.Item1;
            int y = mevcut.Item2;

            for (int i = 0; i < 4; i++) // 4 yöne bakıyoruz
            {
                int yeniX = x + dx[i];
                int yeniY = y + dy[i];

                if (GecerliPozisyon(yeniX, yeniY) && grid[yeniX, yeniY] == 1 && !ziyaretEdildi[yeniX, yeniY])
                {
                    ziyaretEdildi[yeniX, yeniY] = true; // Ziyaret edildi olarak işaretle
                    sayac++; // Kurtarılan düğüm sayısını artır
                    kuyruk.Enqueue(new Tuple<int, int>(yeniX, yeniY)); // Kuyruğa yeni düğüm ekle
                }
            }
        }

        return sayac; // Kurtarılan toplam düğüm sayısını döndür
    }

    // Geçerli pozisyon olup olmadığını kontrol eder
    static bool GecerliPozisyon(int x, int y)
    {
        return x >= 0 && x < N && y >= 0 && y < N; // Pozisyon grid sınırları içinde mi?
    }
}

// 5. Altın Tapınak - Labirent
class AltinTapinak
{
    static int N;
    static int[,] maze;
    static bool[,] visited;
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    public static void RunAltinTapinak()
    {
        Console.Write("Lütfen labirentin boyutunu giriniz (N): ");
        N = int.Parse(Console.ReadLine());

        maze = new int[N, N];
        visited = new bool[N, N];

        Console.WriteLine("Labirent değerlerini giriniz (0 veya 1):");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Labirent[{i},{j}]: ");
                maze[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int steps = BFS();
        if (steps != -1)
            Console.WriteLine($"En Kısa Yol: {steps} adım");
        else
            Console.WriteLine("Yol Yok");
    }

    static int BFS()
    {
        if (maze[0, 0] == 0 || maze[N - 1, N - 1] == 0)
            return -1;

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(0, 0));
        visited[0, 0] = true;

        int steps = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                int x = current.Item1;
                int y = current.Item2;

                if (x == N - 1 && y == N - 1)
                    return steps;

                for (int j = 0; j < 4; j++)
                {
                    int newX = x + dx[j];
                    int newY = y + dy[j];

                    if (IsValidPosition(newX, newY) && maze[newX, newY] == 1 && !visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        queue.Enqueue(new Tuple<int, int>(newX, newY));
                    }
                }
            }
            steps++;
        }

        return -1;
    }

    static bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < N && y >= 0 && y < N;
    }
}
