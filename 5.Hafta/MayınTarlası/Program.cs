using System;

namespace MayinTarlasi
{
    class Program
    {
        // Oyun tahtasının boyutları
        static int satirSayisi = 9;
        static int sutunSayisi = 9;
        static int mayinSayisi = 10;

        // Oyun tahtası ve kullanıcı görünümü
        static char[,] tahta;
        static char[,] gorunenTahta;
        static bool oyunBitti = false;

        static void Main(string[] args)
        {
            TahtaOlustur();
            MayinlariYerlestir();
            SayilariHesapla();

            while (!oyunBitti)
            {
                TahtayiYazdir();
                KullaniciHamlesi();
            }
        }

        static void TahtaOlustur()
        {
            tahta = new char[satirSayisi, sutunSayisi];
            gorunenTahta = new char[satirSayisi, sutunSayisi];

            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    tahta[i, j] = '0';
                    gorunenTahta[i, j] = '#'; // Kullanıcının gördüğü kapalı kare
                }
            }
        }

        static void MayinlariYerlestir()
        {
            Random rand = new Random();
            int yerlestirilenMayin = 0;

            while (yerlestirilenMayin < mayinSayisi)
            {
                int x = rand.Next(0, satirSayisi);
                int y = rand.Next(0, sutunSayisi);

                if (tahta[x, y] != '*')
                {
                    tahta[x, y] = '*';
                    yerlestirilenMayin++;
                }
            }
        }

        static void SayilariHesapla()
        {
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (tahta[i, j] == '*')
                    {
                        // Etrafındaki hücreleri kontrol ediyoruz
                        for (int x = i - 1; x <= i + 1; x++)
                        {
                            for (int y = j - 1; y <= j + 1; y++)
                            {
                                // Sınırların dışında değilse ve mayın değilse
                                if (x >= 0 && x < satirSayisi && y >= 0 && y < sutunSayisi && tahta[x, y] != '*')
                                {
                                    tahta[x, y]++;
                                }
                            }
                        }
                    }
                }
            }
        }

        static void TahtayiYazdir()
        {
            Console.Clear();
            Console.WriteLine("   Mayın Tarlası Oyunu");
            Console.Write("   ");
            for (int i = 0; i < sutunSayisi; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < satirSayisi; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < sutunSayisi; j++)
                {
                    Console.Write(gorunenTahta[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void KullaniciHamlesi()
        {
            int x, y;
            Console.Write("Satır giriniz: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Sütun giriniz: ");
            y = Convert.ToInt32(Console.ReadLine());

            // Kullanıcının girdiği koordinatlar sınırlar içinde mi?
            if (x >= 0 && x < satirSayisi && y >= 0 && y < sutunSayisi)
            {
                if (tahta[x, y] == '*')
                {
                    // Mayına bastı, oyun bitti
                    oyunBitti = true;
                    gorunenTahta[x, y] = '*';
                    TahtayiYazdir();
                    Console.WriteLine("Mayına bastınız! Oyun bitti.");
                }
                else
                {
                    // Hücreyi aç
                    HucreyiAc(x, y);

                    // Tüm hücreler açıldıysa oyunu kazandı
                    if (KazandiMi())
                    {
                        oyunBitti = true;
                        TahtayiYazdir();
                        Console.WriteLine("Tebrikler! Oyunu kazandınız.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Geçersiz koordinatlar. Tekrar deneyiniz.");
            }
        }

        static void HucreyiAc(int x, int y)
        {
            // Zaten açılmışsa geri dön
            if (gorunenTahta[x, y] != '#')
                return;

            // Tahtadaki değeri kullanıcı görünümüne aktar
            gorunenTahta[x, y] = tahta[x, y];

            // Eğer '0' ise etrafındaki hücreleri de aç (rekürsif)
            if (tahta[x, y] == '0')
            {
                // Etrafındaki hücreleri kontrol ediyoruz
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        // Sınırların dışında değilse
                        if (i >= 0 && i < satirSayisi && j >= 0 && j < sutunSayisi)
                        {
                            // Kendisi değilse
                            if (!(i == x && j == y))
                            {
                                HucreyiAc(i, j);
                            }
                        }
                    }
                }
            }
        }

        static bool KazandiMi()
        {
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    // Mayın olmayan ve açılmamış bir hücre varsa henüz kazanmadı
                    if (tahta[i, j] != '*' && gorunenTahta[i, j] == '#')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
