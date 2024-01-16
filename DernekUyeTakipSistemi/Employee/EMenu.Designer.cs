namespace DernekUyeTakipSistemi.Employee
{
    partial class EMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMenu));
            this.btnListele = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAidat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKullanici = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBilgilerim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListele
            // 
            this.btnListele.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListele.BackgroundImage")));
            this.btnListele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnListele.Location = new System.Drawing.Point(12, 375);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(316, 339);
            this.btnListele.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnListele, "Listeleme İşlemleri");
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(725, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 42);
            this.btnExit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnExit, "UYGULAMADAN ÇIKIŞ");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAidat
            // 
            this.btnAidat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAidat.BackgroundImage")));
            this.btnAidat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAidat.Location = new System.Drawing.Point(350, 389);
            this.btnAidat.Name = "btnAidat";
            this.btnAidat.Size = new System.Drawing.Size(422, 325);
            this.btnAidat.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnAidat, "Aidat İşlemleri");
            this.btnAidat.UseVisualStyleBackColor = true;
            this.btnAidat.Click += new System.EventHandler(this.btnAidat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(168, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Hoş Geldiniz Murrem";
            // 
            // btnKullanici
            // 
            this.btnKullanici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKullanici.BackgroundImage")));
            this.btnKullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullanici.Location = new System.Drawing.Point(350, 78);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(422, 310);
            this.btnKullanici.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnKullanici, "Kullanıcı İşlemleri");
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnBilgilerim
            // 
            this.btnBilgilerim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBilgilerim.BackgroundImage")));
            this.btnBilgilerim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBilgilerim.Location = new System.Drawing.Point(12, 78);
            this.btnBilgilerim.Name = "btnBilgilerim";
            this.btnBilgilerim.Size = new System.Drawing.Size(316, 277);
            this.btnBilgilerim.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnBilgilerim, "Kullanıcı İşlemleri");
            this.btnBilgilerim.UseVisualStyleBackColor = true;
            this.btnBilgilerim.Click += new System.EventHandler(this.btnBilgilerim_Click);
            // 
            // EMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(790, 735);
            this.ControlBox = false;
            this.Controls.Add(this.btnBilgilerim);
            this.Controls.Add(this.btnKullanici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAidat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çalışan Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAidat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.Button btnBilgilerim;
    }
}