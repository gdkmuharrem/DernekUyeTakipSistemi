namespace DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu
{
    partial class ListMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListMenu));
            this.btnGeri = new System.Windows.Forms.Button();
            this.ekran = new System.Windows.Forms.DataGridView();
            this.cbGenel = new System.Windows.Forms.ComboBox();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.cbOrtak1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOrtak1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeri.BackgroundImage")));
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.Location = new System.Drawing.Point(1291, 405);
            this.btnGeri.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(77, 63);
            this.btnGeri.TabIndex = 6;
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // ekran
            // 
            this.ekran.AllowUserToAddRows = false;
            this.ekran.AllowUserToDeleteRows = false;
            this.ekran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ekran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ekran.Location = new System.Drawing.Point(16, 15);
            this.ekran.Margin = new System.Windows.Forms.Padding(4);
            this.ekran.Name = "ekran";
            this.ekran.ReadOnly = true;
            this.ekran.RowHeadersWidth = 51;
            this.ekran.Size = new System.Drawing.Size(888, 453);
            this.ekran.TabIndex = 24;
            // 
            // cbGenel
            // 
            this.cbGenel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbGenel.FormattingEnabled = true;
            this.cbGenel.Items.AddRange(new object[] {
            "İşlem Seçiniz...",
            "Kan Grubuna Göre Listeleme",
            "İllere Göre Listeleme",
            "Aktif/Pasif Listeleme",
            "Borç Durumuna Göre Listeleme",
            "Belirli Tarihlere Göre Listeleme"});
            this.cbGenel.Location = new System.Drawing.Point(935, 114);
            this.cbGenel.Margin = new System.Windows.Forms.Padding(4);
            this.cbGenel.Name = "cbGenel";
            this.cbGenel.Size = new System.Drawing.Size(433, 37);
            this.cbGenel.TabIndex = 1;
            this.cbGenel.SelectedIndexChanged += new System.EventHandler(this.cbGenel_SelectedIndexChanged);
            // 
            // btnMail
            // 
            this.btnMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMail.BackgroundImage")));
            this.btnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMail.Location = new System.Drawing.Point(923, 367);
            this.btnMail.Margin = new System.Windows.Forms.Padding(4);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(140, 101);
            this.btnMail.TabIndex = 4;
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPDF.BackgroundImage")));
            this.btnPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPDF.Location = new System.Drawing.Point(1089, 367);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(116, 101);
            this.btnPDF.TabIndex = 5;
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // cbOrtak1
            // 
            this.cbOrtak1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrtak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbOrtak1.FormattingEnabled = true;
            this.cbOrtak1.Items.AddRange(new object[] {
            "Tümü",
            "0 Rh+",
            "0 Rh-",
            "A Rh+",
            "A Rh-",
            "B Rh+",
            "B Rh-",
            "AB Rh+",
            "AB Rh-"});
            this.cbOrtak1.Location = new System.Drawing.Point(1089, 188);
            this.cbOrtak1.Margin = new System.Windows.Forms.Padding(4);
            this.cbOrtak1.Name = "cbOrtak1";
            this.cbOrtak1.Size = new System.Drawing.Size(279, 37);
            this.cbOrtak1.TabIndex = 2;
            this.cbOrtak1.SelectedIndexChanged += new System.EventHandler(this.cbOrtak1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(968, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 71);
            this.label1.TabIndex = 30;
            this.label1.Text = "Yapmak istediğiniz İşlemi Seçiniz.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOrtak1
            // 
            this.lbOrtak1.AutoSize = true;
            this.lbOrtak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbOrtak1.Location = new System.Drawing.Point(956, 196);
            this.lbOrtak1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrtak1.Name = "lbOrtak1";
            this.lbOrtak1.Size = new System.Drawing.Size(81, 29);
            this.lbOrtak1.TabIndex = 31;
            this.lbOrtak1.Text = "label2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(923, 250);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 32;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(1168, 250);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 33;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(970, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1234, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // ListMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 485);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbOrtak1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOrtak1);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.cbGenel);
            this.Controls.Add(this.ekran);
            this.Controls.Add(this.btnGeri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListMenu";
            this.Text = "LİSTELEME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListMenu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ekran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.DataGridView ekran;
        private System.Windows.Forms.ComboBox cbGenel;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.ComboBox cbOrtak1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOrtak1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}