namespace Hangman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picAdamAsmaca = new PictureBox();
            txtTahmin = new TextBox();
            btnTahminEt = new Button();
            lblYanlisTahminler = new Label();
            lblDogruTahminler = new Label();
            lblKalanDeneme = new Label();
            ((System.ComponentModel.ISupportInitialize)picAdamAsmaca).BeginInit();
            SuspendLayout();
            // 
            // picAdamAsmaca
            // 
            picAdamAsmaca.Location = new Point(27, 19);
            picAdamAsmaca.Name = "picAdamAsmaca";
            picAdamAsmaca.Size = new Size(378, 363);
            picAdamAsmaca.TabIndex = 0;
            picAdamAsmaca.TabStop = false;
            picAdamAsmaca.Click += pictureBox1_Click;
            // 
            // txtTahmin
            // 
            txtTahmin.Location = new Point(605, 53);
            txtTahmin.Name = "txtTahmin";
            txtTahmin.Size = new Size(183, 23);
            txtTahmin.TabIndex = 1;
            // 
            // btnTahminEt
            // 
            btnTahminEt.Location = new Point(605, 82);
            btnTahminEt.Name = "btnTahminEt";
            btnTahminEt.Size = new Size(75, 23);
            btnTahminEt.TabIndex = 2;
            btnTahminEt.Text = "Tahmin Et";
            btnTahminEt.UseVisualStyleBackColor = true;
            btnTahminEt.Click += btnTahminEt_Click;
            // 
            // lblYanlisTahminler
            // 
            lblYanlisTahminler.AutoSize = true;
            lblYanlisTahminler.Location = new Point(600, 191);
            lblYanlisTahminler.Name = "lblYanlisTahminler";
            lblYanlisTahminler.Size = new Size(95, 15);
            lblYanlisTahminler.TabIndex = 3;
            lblYanlisTahminler.Text = "Yanlış Tahminler:";
            // 
            // lblDogruTahminler
            // 
            lblDogruTahminler.AutoSize = true;
            lblDogruTahminler.Location = new Point(605, 247);
            lblDogruTahminler.Name = "lblDogruTahminler";
            lblDogruTahminler.Size = new Size(32, 15);
            lblDogruTahminler.TabIndex = 4;
            lblDogruTahminler.Text = "_____";
            // 
            // lblKalanDeneme
            // 
            lblKalanDeneme.AutoSize = true;
            lblKalanDeneme.Location = new Point(80, 424);
            lblKalanDeneme.Name = "lblKalanDeneme";
            lblKalanDeneme.Size = new Size(95, 15);
            lblKalanDeneme.TabIndex = 5;
            lblKalanDeneme.Text = "Kalan Deneme: 6";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblKalanDeneme);
            Controls.Add(lblDogruTahminler);
            Controls.Add(lblYanlisTahminler);
            Controls.Add(btnTahminEt);
            Controls.Add(txtTahmin);
            Controls.Add(picAdamAsmaca);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picAdamAsmaca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTahmin;
        private Button btnTahminEt;
        private Label lblYanlisTahminler;
        private Label lblDogruTahminler;
        private Label lblKalanDeneme;
        private PictureBox picAdamAsmaca;

    }
}
