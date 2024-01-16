namespace DernekUyeTakipSistemi.Employee.MenuLayer.DuesLayer.MenuLayer
{
    partial class PaymentDues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentDues));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbBireysel = new System.Windows.Forms.CheckBox();
            this.cbTum = new System.Windows.Forms.CheckBox();
            this.gbOdeme = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListele = new System.Windows.Forms.Button();
            this.cmOdemeYil = new System.Windows.Forms.ComboBox();
            this.cmOdemeAy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.lbTc = new System.Windows.Forms.Label();
            this.rbOk = new System.Windows.Forms.RadioButton();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbTum = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbOdeme.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(766, 178);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // cbBireysel
            // 
            this.cbBireysel.AutoSize = true;
            this.cbBireysel.Location = new System.Drawing.Point(110, 271);
            this.cbBireysel.Name = "cbBireysel";
            this.cbBireysel.Size = new System.Drawing.Size(62, 17);
            this.cbBireysel.TabIndex = 1;
            this.cbBireysel.Text = "Bireysel";
            this.cbBireysel.UseVisualStyleBackColor = true;
            this.cbBireysel.CheckedChanged += new System.EventHandler(this.cbBireysel_CheckedChanged);
            // 
            // cbTum
            // 
            this.cbTum.AutoSize = true;
            this.cbTum.Location = new System.Drawing.Point(110, 239);
            this.cbTum.Name = "cbTum";
            this.cbTum.Size = new System.Drawing.Size(100, 17);
            this.cbTum.TabIndex = 2;
            this.cbTum.Text = "Tüm Kullanıcılar";
            this.cbTum.UseVisualStyleBackColor = true;
            this.cbTum.CheckedChanged += new System.EventHandler(this.cbTum_CheckedChanged);
            // 
            // gbOdeme
            // 
            this.gbOdeme.Controls.Add(this.btnTemizle);
            this.gbOdeme.Controls.Add(this.label1);
            this.gbOdeme.Controls.Add(this.btnListele);
            this.gbOdeme.Controls.Add(this.cmOdemeYil);
            this.gbOdeme.Controls.Add(this.cmOdemeAy);
            this.gbOdeme.Controls.Add(this.label2);
            this.gbOdeme.Location = new System.Drawing.Point(412, 215);
            this.gbOdeme.Name = "gbOdeme";
            this.gbOdeme.Size = new System.Drawing.Size(191, 161);
            this.gbOdeme.TabIndex = 12;
            this.gbOdeme.TabStop = false;
            this.gbOdeme.Text = "Ödeme Durumu";
            this.gbOdeme.Visible = false;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(6, 132);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(53, 23);
            this.btnTemizle.TabIndex = 17;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Yıl";
            // 
            // btnListele
            // 
            this.btnListele.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnListele.Location = new System.Drawing.Point(101, 112);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(75, 32);
            this.btnListele.TabIndex = 7;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // cmOdemeYil
            // 
            this.cmOdemeYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmOdemeYil.FormattingEnabled = true;
            this.cmOdemeYil.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cmOdemeYil.Location = new System.Drawing.Point(62, 40);
            this.cmOdemeYil.Name = "cmOdemeYil";
            this.cmOdemeYil.Size = new System.Drawing.Size(87, 21);
            this.cmOdemeYil.TabIndex = 8;
            // 
            // cmOdemeAy
            // 
            this.cmOdemeAy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmOdemeAy.FormattingEnabled = true;
            this.cmOdemeAy.Items.AddRange(new object[] {
            "Ocak",
            "Şubat",
            "Mart",
            "Nisan",
            "Mayıs",
            "Haziran",
            "Temmuz",
            "Ağustos",
            "Eylül",
            "Ekim",
            "Kasım",
            "Aralık"});
            this.cmOdemeAy.Location = new System.Drawing.Point(62, 75);
            this.cmOdemeAy.Name = "cmOdemeAy";
            this.cmOdemeAy.Size = new System.Drawing.Size(87, 21);
            this.cmOdemeAy.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ay";
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(200, 295);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(100, 20);
            this.txtTc.TabIndex = 13;
            this.txtTc.Visible = false;
            this.txtTc.TextChanged += new System.EventHandler(this.txtTc_TextChanged);
            this.txtTc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTc_KeyPress);
            // 
            // lbTc
            // 
            this.lbTc.AutoSize = true;
            this.lbTc.Location = new System.Drawing.Point(151, 298);
            this.lbTc.Name = "lbTc";
            this.lbTc.Size = new System.Drawing.Size(43, 13);
            this.lbTc.TabIndex = 14;
            this.lbTc.Text = "Tc No :";
            this.lbTc.Visible = false;
            // 
            // rbOk
            // 
            this.rbOk.AutoSize = true;
            this.rbOk.Location = new System.Drawing.Point(682, 239);
            this.rbOk.Name = "rbOk";
            this.rbOk.Size = new System.Drawing.Size(66, 17);
            this.rbOk.TabIndex = 15;
            this.rbOk.TabStop = true;
            this.rbOk.Text = "Ödenmiş";
            this.rbOk.UseVisualStyleBackColor = true;
            this.rbOk.CheckedChanged += new System.EventHandler(this.rbOk_CheckedChanged);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(682, 262);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(80, 17);
            this.rbNo.TabIndex = 16;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "Ödenmemiş";
            this.rbNo.UseVisualStyleBackColor = true;
            this.rbNo.CheckedChanged += new System.EventHandler(this.rbNo_CheckedChanged);
            // 
            // rbTum
            // 
            this.rbTum.AutoSize = true;
            this.rbTum.Location = new System.Drawing.Point(682, 216);
            this.rbTum.Name = "rbTum";
            this.rbTum.Size = new System.Drawing.Size(52, 17);
            this.rbTum.TabIndex = 17;
            this.rbTum.TabStop = true;
            this.rbTum.Text = "Tümü";
            this.rbTum.UseVisualStyleBackColor = true;
            this.rbTum.CheckedChanged += new System.EventHandler(this.rbTum_CheckedChanged);
            // 
            // PaymentDues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 388);
            this.Controls.Add(this.rbTum);
            this.Controls.Add(this.rbNo);
            this.Controls.Add(this.rbOk);
            this.Controls.Add(this.lbTc);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.gbOdeme);
            this.Controls.Add(this.cbTum);
            this.Controls.Add(this.cbBireysel);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentDues";
            this.Text = "AidatOdeme";
            this.Load += new System.EventHandler(this.AidatOdeme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbOdeme.ResumeLayout(false);
            this.gbOdeme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbBireysel;
        private System.Windows.Forms.CheckBox cbTum;
        private System.Windows.Forms.GroupBox gbOdeme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.ComboBox cmOdemeYil;
        private System.Windows.Forms.ComboBox cmOdemeAy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label lbTc;
        private System.Windows.Forms.RadioButton rbOk;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.RadioButton rbTum;
    }
}