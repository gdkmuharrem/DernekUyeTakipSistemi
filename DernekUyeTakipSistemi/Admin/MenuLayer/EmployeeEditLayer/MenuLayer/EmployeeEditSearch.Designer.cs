﻿namespace DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.MenuLayer
{
    partial class EmployeeEditSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeEditSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.rbMail = new System.Windows.Forms.RadioButton();
            this.rbTel = new System.Windows.Forms.RadioButton();
            this.rbAdSoyad = new System.Windows.Forms.RadioButton();
            this.rbTc = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(479, 223);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 143);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb2.Location = new System.Drawing.Point(214, 200);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(64, 25);
            this.lb2.TabIndex = 22;
            this.lb2.Text = "label3";
            this.lb2.Visible = false;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb1.Location = new System.Drawing.Point(214, 158);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(64, 25);
            this.lb1.TabIndex = 21;
            this.lb1.Text = "label2";
            this.lb1.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt2.Location = new System.Drawing.Point(316, 201);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(145, 30);
            this.txt2.TabIndex = 6;
            this.txt2.Visible = false;
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt1.Location = new System.Drawing.Point(316, 153);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(145, 30);
            this.txt1.TabIndex = 5;
            this.txt1.Visible = false;
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // rbMail
            // 
            this.rbMail.AutoSize = true;
            this.rbMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbMail.Location = new System.Drawing.Point(39, 235);
            this.rbMail.Name = "rbMail";
            this.rbMail.Size = new System.Drawing.Size(60, 26);
            this.rbMail.TabIndex = 4;
            this.rbMail.TabStop = true;
            this.rbMail.Text = "Mail";
            this.rbMail.UseVisualStyleBackColor = true;
            this.rbMail.CheckedChanged += new System.EventHandler(this.rbMail_CheckedChanged);
            // 
            // rbTel
            // 
            this.rbTel.AutoSize = true;
            this.rbTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbTel.Location = new System.Drawing.Point(39, 205);
            this.rbTel.Name = "rbTel";
            this.rbTel.Size = new System.Drawing.Size(89, 26);
            this.rbTel.TabIndex = 3;
            this.rbTel.TabStop = true;
            this.rbTel.Text = "Telefon";
            this.rbTel.UseVisualStyleBackColor = true;
            this.rbTel.CheckedChanged += new System.EventHandler(this.rbTel_CheckedChanged);
            // 
            // rbAdSoyad
            // 
            this.rbAdSoyad.AutoSize = true;
            this.rbAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbAdSoyad.Location = new System.Drawing.Point(39, 175);
            this.rbAdSoyad.Name = "rbAdSoyad";
            this.rbAdSoyad.Size = new System.Drawing.Size(111, 26);
            this.rbAdSoyad.TabIndex = 2;
            this.rbAdSoyad.TabStop = true;
            this.rbAdSoyad.Text = "Ad, Soyad";
            this.rbAdSoyad.UseVisualStyleBackColor = true;
            this.rbAdSoyad.CheckedChanged += new System.EventHandler(this.rbAdSoyad_CheckedChanged);
            // 
            // rbTc
            // 
            this.rbTc.AutoSize = true;
            this.rbTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbTc.Location = new System.Drawing.Point(39, 145);
            this.rbTc.Name = "rbTc";
            this.rbTc.Size = new System.Drawing.Size(77, 26);
            this.rbTc.TabIndex = 1;
            this.rbTc.TabStop = true;
            this.rbTc.Text = "Tc No";
            this.rbTc.UseVisualStyleBackColor = true;
            this.rbTc.CheckedChanged += new System.EventHandler(this.rbTc_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 113);
            this.label1.TabIndex = 20;
            this.label1.Text = "Aşağıda bulunan seçenekleri kullanarak bulmak istediğiniz kullanıcının bilgilerin" +
    "e daha kolay erişebilirsiniz.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeEditSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 378);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.rbMail);
            this.Controls.Add(this.rbTel);
            this.Controls.Add(this.rbAdSoyad);
            this.Controls.Add(this.rbTc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeEditSearch";
            this.Text = "Çalışan ARAMA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.RadioButton rbMail;
        private System.Windows.Forms.RadioButton rbTel;
        private System.Windows.Forms.RadioButton rbAdSoyad;
        private System.Windows.Forms.RadioButton rbTc;
        private System.Windows.Forms.Label label1;
    }
}