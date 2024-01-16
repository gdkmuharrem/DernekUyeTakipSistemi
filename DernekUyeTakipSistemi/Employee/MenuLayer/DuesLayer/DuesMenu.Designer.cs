namespace DernekUyeTakipSistemi.Employee
{
    partial class DuesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuesMenu));
            this.btnBelirle = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBelirle
            // 
            this.btnBelirle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBelirle.BackgroundImage")));
            this.btnBelirle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBelirle.Location = new System.Drawing.Point(24, 26);
            this.btnBelirle.Name = "btnBelirle";
            this.btnBelirle.Size = new System.Drawing.Size(303, 252);
            this.btnBelirle.TabIndex = 1;
            this.btnBelirle.UseVisualStyleBackColor = true;
            this.btnBelirle.Click += new System.EventHandler(this.btnBelirle_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeri.BackgroundImage")));
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.Location = new System.Drawing.Point(724, 237);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(43, 41);
            this.btnGeri.TabIndex = 13;
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnOdeme
            // 
            this.btnOdeme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOdeme.BackgroundImage")));
            this.btnOdeme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOdeme.Location = new System.Drawing.Point(370, 26);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(303, 252);
            this.btnOdeme.TabIndex = 2;
            this.btnOdeme.UseVisualStyleBackColor = true;
            this.btnOdeme.Click += new System.EventHandler(this.btnOdeme_Click);
            // 
            // DuesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 304);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnBelirle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuesMenu";
            this.Text = "Aidat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuesMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBelirle;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnOdeme;
    }
}