using System;

namespace TikTakToe
{
    class Program
    {
        static char[,] tahta = new char[3, 3];
        static char oyuncu = 'X';

        static void Main(string[] args)
        {
            TahtayiOlustur();
            int hamleSayisi = 0;
            bool oyunBitti = false;

            while (!oyunBitti && hamleSayisi < 9)
            {
                TahtayiYazdir();
                Console.WriteLine($"Oyuncu {oyuncu}, lütfen hamlenizi yapın.");
                int satir = -1;
                int sutun = -1;

                // Geçerli bir giriş alın
                while (true)
                {
                    Console.Write("Satır (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out satir) || satir < 1 || satir > 3)
                    {
                        Console.WriteLine("Geçersiz satır numarası. Lütfen 1 ile 3 arasında bir değer girin.");
                        continue;
                    }

                    Console.Write("Sütun (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out sutun) || sutun < 1 || sutun > 3)
                    {
                        Console.WriteLine("Geçersiz sütun numarası. Lütfen 1 ile 3 arasında bir değer girin.");
                        continue;
                    }

                    if (tahta[satir - 1, sutun - 1] != ' ')
                    {
                        Console.WriteLine("Bu kare dolu. Lütfen başka bir kare seçin.");
                        continue;
                    }

                    break;
                }

                tahta[satir - 1, sutun - 1] = oyuncu;
                hamleSayisi++;

                if (KazananKontrol(oyuncu))
                {
                    TahtayiYazdir();
                    Console.WriteLine($"Tebrikler! Oyuncu {oyuncu} kazandı.");
                    oyunBitti = true;
                }
                else if (hamleSayisi == 9)
                {
                    TahtayiYazdir();
                    Console.WriteLine("Oyun berabere bitti.");
                    oyunBitti = true;
                }
                else
                {
                    oyuncu = (oyuncu == 'X') ? 'O' : 'X';
                }
            }

            Console.WriteLine("Oyun bitti. Çıkmak için bir tuşa basın.");
            Console.ReadKey();
        }

        static void TahtayiOlustur()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tahta[i, j] = ' ';
                }
            }
        }

        static void TahtayiYazdir()
        {
            Console.Clear();
            Console.WriteLine("   1   2   3");
            Console.WriteLine("  -----------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1} |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {tahta[i, j]} |");
                }
                Console.WriteLine();
                Console.WriteLine("  -----------");
            }
        }

        static bool KazananKontrol(char oyuncu)
        {
            // Satırlar
            for (int i = 0; i < 3; i++)
            {
                if (tahta[i, 0] == oyuncu && tahta[i, 1] == oyuncu && tahta[i, 2] == oyuncu)
                    return true;
            }

            // Sütunlar
            for (int i = 0; i < 3; i++)
            {
                if (tahta[0, i] == oyuncu && tahta[1, i] == oyuncu && tahta[2, i] == oyuncu)
                    return true;
            }

            // Çaprazlar
            if (tahta[0, 0] == oyuncu && tahta[1, 1] == oyuncu && tahta[2, 2] == oyuncu)
                return true;
            if (tahta[0, 2] == oyuncu && tahta[1, 1] == oyuncu && tahta[2, 0] == oyuncu)
                return true;

            return false;
        }
    }
}
