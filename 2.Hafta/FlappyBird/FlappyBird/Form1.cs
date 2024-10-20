using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        // Oyun Değişkenleri
        int pipeSpeed = 8;     // Boruların hızı
        int gravity = 2;       // Yerçekimi kuvveti
        int birdSpeed = 0;     // Kuşun hızı
        int score = 0;         // Oyun skoru
        bool gameStarted = false; // Oyun başladı mı kontrolü
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Tick += new EventHandler(gameTimer_Tick);  // Timer'ın Tick olayını bağla
            gameTimer.Interval = 20;  // Zamanlayıcı aralığını belirleyin
            this.KeyPreview = true;   // Klavye olaylarının form tarafından işlenmesini sağlar
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                // Kuşun hareketi
                birdPictureBox.Top += birdSpeed;  // Kuşun yukarı/aşağı hareketi
                birdSpeed += gravity;  // Yerçekimi etkisi

                // Boruların hareketi
                pipeTopPictureBox.Left -= pipeSpeed;
                pipeBottomPictureBox.Left -= pipeSpeed;

                // Borular ekran dışına çıkarsa yeniden başlat
                if (pipeTopPictureBox.Left < -50)
                {
                    pipeTopPictureBox.Left = 800;

                    // Rastgele yükseklik ayarla
                    int randomHeight = rand.Next(-150, -50);  // Rastgele yükseklik
                    pipeTopPictureBox.Top = randomHeight;

                    // Alt borunun konumunu yeniden ayarla
                    pipeBottomPictureBox.Top = randomHeight + pipeTopPictureBox.Height + 150;  // Aralarındaki boşluğu ayarla
                }

                if (pipeBottomPictureBox.Left < -50)
                {
                    pipeBottomPictureBox.Left = 800;
                    score++;  // Skoru artır
                }

                // Skoru güncelle
                scoreLabel.Text = "Score: " + score;

                // Çarpışma kontrolü
                if (birdPictureBox.Bounds.IntersectsWith(pipeTopPictureBox.Bounds) ||
                    birdPictureBox.Bounds.IntersectsWith(pipeBottomPictureBox.Bounds) ||
                    birdPictureBox.Bounds.IntersectsWith(groundPictureBox.Bounds))
                {
                    gameOver();
                }

                // Kuş üst veya alt sınıra çarparsa oyun biter
                if (birdPictureBox.Top < 0 || birdPictureBox.Bottom > groundPictureBox.Top)
                {
                    gameOver();
                }
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!gameStarted)
                {
                    gameStarted = true;  // Oyun başlatılır
                    gameTimer.Start();   // Oyun hareket etmeye başlar
                    birdSpeed = -10;     // İlk zıplama
                }
                else
                {
                    birdSpeed = -10;     // Kuş zıplar
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // Skor Label'ına tıklama olayı, bu da boş kalabilir.
        }
        private void gameOver()
        {
            gameTimer.Stop();  // Zamanlayıcıyı durdur
            gameStarted = false;  // Oyun durdu
            birdSpeed = 0;  // Kuşun hızını sıfırla
            MessageBox.Show("Game Over! Your Score: " + score);  // Oyun bitti mesajı

            // Oyun sıfırlama
            birdPictureBox.Top = 100;  // Kuşu başlangıç pozisyonuna getir
            pipeTopPictureBox.Left = 800;  // Boruları başa döndür
            pipeBottomPictureBox.Left = 800;
            score = 0;  // Skoru sıfırla
            scoreLabel.Text = "Score: 0";  // Skor etiketini sıfırla
        }
    }
}

