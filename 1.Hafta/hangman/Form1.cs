using System;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        private string[] kelimeler = { "elma", "armut", "kitap", "bilgisayar", "araba" }; // Tahmin edilecek kelimeler
        private string secilenKelime; // Se�ilen kelime
        private char[] dogruTahminler; // Do�ru tahmin edilen harfler
        private int kalanDeneme = 6; // Kalan deneme hakk�
        private string yanlisTahminler = ""; // Yanl�� tahmin edilen harfler

        public Form1()
        {
            InitializeComponent();
            OyunuBaslat(); // Oyun ba�lad���nda ilk kelimeyi se� ve oyunu ba�lat
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Oyunu ba�latan ve gerekli de�erleri s�f�rlayan fonksiyon
        private void OyunuBaslat()
        {
            Random rastgele = new Random();
            secilenKelime = kelimeler[rastgele.Next(kelimeler.Length)]; // Rastgele kelime se�
            dogruTahminler = new string('_', secilenKelime.Length).ToCharArray(); // Bo� �izgilerle kelimeyi ba�lat
            lblDogruTahminler.Text = new string(dogruTahminler); // Do�ru tahminlerin g�sterildi�i label'� g�ncelle
            lblYanlisTahminler.Text = "Yanl�� Tahminler: "; // Yanl�� tahminlerin g�sterildi�i label'� temizle
            lblKalanDeneme.Text = "Kalan Deneme: " + kalanDeneme; // Kalan deneme hakk�n� g�ster
            picAdamAsmaca.Image = null; // Ba�lang��ta bo� resim
        }

        // Tahmin etme i�lemi
        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text.ToLower(); // Kullan�c�n�n tahminini k���k harfe �evir

            if (tahmin.Length == 1) // E�er sadece tek bir harf girildiyse
            {
                char harf = tahmin[0];
                bool dogruMu = false;

                // Harfin do�ru olup olmad���n� kontrol et
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (secilenKelime[i] == harf)
                    {
                        dogruTahminler[i] = harf; // Do�ruysa, do�ru tahminler aras�na ekle
                        dogruMu = true;
                    }
                }

                if (dogruMu)
                {
                    lblDogruTahminler.Text = new string(dogruTahminler); // Do�ru tahminler g�ncellenir
                    if (!lblDogruTahminler.Text.Contains("_")) // E�er kelimenin tamam� bulunduysa
                    {
                        MessageBox.Show("Tebrikler, kelimeyi buldunuz!");
                        OyunuBaslat(); // Oyunu yeniden ba�lat
                    }
                }
                else
                {
                    // E�er yanl�� tahmin ise ve harf zaten yanl�� tahminler aras�nda de�ilse
                    if (!yanlisTahminler.Contains(harf))
                    {
                        yanlisTahminler += harf + " "; // Yanl�� tahminler aras�na ekle
                        lblYanlisTahminler.Text = "Yanl�� Tahminler: " + yanlisTahminler; // Yanl�� tahminleri g�ncelle
                        kalanDeneme--; // Kalan deneme say�s�n� azalt
                        lblKalanDeneme.Text = "Kalan Deneme: " + kalanDeneme; // Kalan deneme hakk�n� g�ster
                        GorseliGuncelle(); // Adam asmaca g�rselini g�ncelle

                        if (kalanDeneme == 0) // E�er kalan deneme hakk� biterse
                        {
                            MessageBox.Show("Oyunu kaybettiniz! Kelime: " + secilenKelime);
                            OyunuBaslat(); // Oyunu yeniden ba�lat
                        }
                    }
                }
            }

            txtTahmin.Clear(); // TextBox'� temizle
        }

        // Yanl�� tahminlere g�re adam asmaca g�rselini g�ncelle
        private void GorseliGuncelle()
        {
            switch (kalanDeneme)
            {
                case 5:
                    picAdamAsmaca.Image = Properties.Resources.adam1; // �lk yanl�� tahmin sonras� ilk g�rsel
                    break;
                case 4:
                    picAdamAsmaca.Image = Properties.Resources.adam2;
                    break;
                case 3:
                    picAdamAsmaca.Image = Properties.Resources.adam3;
                    break;
                case 2:
                    picAdamAsmaca.Image = Properties.Resources.adam4;
                    break;
                case 1:
                    picAdamAsmaca.Image = Properties.Resources.adam5;
                    break;
                case 0:
                    picAdamAsmaca.Image = Properties.Resources.adam6; // Son a�ama, oyun bitti�inde
                    break;
            }
        }
    }
}
