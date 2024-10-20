namespace FlappyBird
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groundPictureBox = new System.Windows.Forms.PictureBox();
            this.pipeBottomPictureBox = new System.Windows.Forms.PictureBox();
            this.birdPictureBox = new System.Windows.Forms.PictureBox();
            this.pipeTopPictureBox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottomPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birdPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTopPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groundPictureBox
            // 
            this.groundPictureBox.Image = global::FlappyBird.Properties.Resources.ground;
            this.groundPictureBox.Location = new System.Drawing.Point(0, 375);
            this.groundPictureBox.Name = "groundPictureBox";
            this.groundPictureBox.Size = new System.Drawing.Size(816, 86);
            this.groundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.groundPictureBox.TabIndex = 4;
            this.groundPictureBox.TabStop = false;
            // 
            // pipeBottomPictureBox
            // 
            this.pipeBottomPictureBox.Image = global::FlappyBird.Properties.Resources.pipeUp;
            this.pipeBottomPictureBox.Location = new System.Drawing.Point(456, 281);
            this.pipeBottomPictureBox.Name = "pipeBottomPictureBox";
            this.pipeBottomPictureBox.Size = new System.Drawing.Size(115, 257);
            this.pipeBottomPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeBottomPictureBox.TabIndex = 3;
            this.pipeBottomPictureBox.TabStop = false;
            // 
            // birdPictureBox
            // 
            this.birdPictureBox.Image = global::FlappyBird.Properties.Resources.bird;
            this.birdPictureBox.Location = new System.Drawing.Point(118, 193);
            this.birdPictureBox.Name = "birdPictureBox";
            this.birdPictureBox.Size = new System.Drawing.Size(81, 61);
            this.birdPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.birdPictureBox.TabIndex = 1;
            this.birdPictureBox.TabStop = false;
            // 
            // pipeTopPictureBox
            // 
            this.pipeTopPictureBox.Image = global::FlappyBird.Properties.Resources.pipeDown;
            this.pipeTopPictureBox.Location = new System.Drawing.Point(456, -104);
            this.pipeTopPictureBox.Name = "pipeTopPictureBox";
            this.pipeTopPictureBox.Size = new System.Drawing.Size(115, 257);
            this.pipeTopPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeTopPictureBox.TabIndex = 0;
            this.pipeTopPictureBox.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(232, 52);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(52, 13);
            this.scoreLabel.TabIndex = 5;
            this.scoreLabel.Text = "SKOR : 0";
            this.scoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.groundPictureBox);
            this.Controls.Add(this.pipeBottomPictureBox);
            this.Controls.Add(this.birdPictureBox);
            this.Controls.Add(this.pipeTopPictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottomPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birdPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTopPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pipeTopPictureBox;
        private System.Windows.Forms.PictureBox birdPictureBox;
        private System.Windows.Forms.PictureBox pipeBottomPictureBox;
        private System.Windows.Forms.PictureBox groundPictureBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer gameTimer;
    }
}

