using System;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        private string[] kelimeler = { "elma", "armut", "kitap", "bilgisayar", "araba" }; // Tahmin edilecek kelimeler
        private string secilenKelime; // Seçilen kelime
        private char[] dogruTahminler; // Doðru tahmin edilen harfler
        private int kalanDeneme = 6; // Kalan deneme hakký
        private string yanlisTahminler = ""; // Yanlýþ tahmin edilen harfler

        public Form1()
        {
            InitializeComponent();
            OyunuBaslat(); // Oyun baþladýðýnda ilk kelimeyi seç ve oyunu baþlat
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Oyunu baþlatan ve gerekli deðerleri sýfýrlayan fonksiyon
        private void OyunuBaslat()
        {
            Random rastgele = new Random();
            secilenKelime = kelimeler[rastgele.Next(kelimeler.Length)]; // Rastgele kelime seç
            dogruTahminler = new string('_', secilenKelime.Length).ToCharArray(); // Boþ çizgilerle kelimeyi baþlat
            lblDogruTahminler.Text = new string(dogruTahminler); // Doðru tahminlerin gösterildiði label'ý güncelle
            lblYanlisTahminler.Text = "Yanlýþ Tahminler: "; // Yanlýþ tahminlerin gösterildiði label'ý temizle
            lblKalanDeneme.Text = "Kalan Deneme: " + kalanDeneme; // Kalan deneme hakkýný göster
            picAdamAsmaca.Image = null; // Baþlangýçta boþ resim
        }

        // Tahmin etme iþlemi
        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text.ToLower(); // Kullanýcýnýn tahminini küçük harfe çevir

            if (tahmin.Length == 1) // Eðer sadece tek bir harf girildiyse
            {
                char harf = tahmin[0];
                bool dogruMu = false;

                // Harfin doðru olup olmadýðýný kontrol et
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (secilenKelime[i] == harf)
                    {
                        dogruTahminler[i] = harf; // Doðruysa, doðru tahminler arasýna ekle
                        dogruMu = true;
                    }
                }

                if (dogruMu)
                {
                    lblDogruTahminler.Text = new string(dogruTahminler); // Doðru tahminler güncellenir
                    if (!lblDogruTahminler.Text.Contains("_")) // Eðer kelimenin tamamý bulunduysa
                    {
                        MessageBox.Show("Tebrikler, kelimeyi buldunuz!");
                        OyunuBaslat(); // Oyunu yeniden baþlat
                    }
                }
                else
                {
                    // Eðer yanlýþ tahmin ise ve harf zaten yanlýþ tahminler arasýnda deðilse
                    if (!yanlisTahminler.Contains(harf))
                    {
                        yanlisTahminler += harf + " "; // Yanlýþ tahminler arasýna ekle
                        lblYanlisTahminler.Text = "Yanlýþ Tahminler: " + yanlisTahminler; // Yanlýþ tahminleri güncelle
                        kalanDeneme--; // Kalan deneme sayýsýný azalt
                        lblKalanDeneme.Text = "Kalan Deneme: " + kalanDeneme; // Kalan deneme hakkýný göster
                        GorseliGuncelle(); // Adam asmaca görselini güncelle

                        if (kalanDeneme == 0) // Eðer kalan deneme hakký biterse
                        {
                            MessageBox.Show("Oyunu kaybettiniz! Kelime: " + secilenKelime);
                            OyunuBaslat(); // Oyunu yeniden baþlat
                        }
                    }
                }
            }

            txtTahmin.Clear(); // TextBox'ý temizle
        }

        // Yanlýþ tahminlere göre adam asmaca görselini güncelle
        private void GorseliGuncelle()
        {
            switch (kalanDeneme)
            {
                case 5:
                    picAdamAsmaca.Image = Properties.Resources.adam1; // Ýlk yanlýþ tahmin sonrasý ilk görsel
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
                    picAdamAsmaca.Image = Properties.Resources.adam6; // Son aþama, oyun bittiðinde
                    break;
            }
        }
    }
}
