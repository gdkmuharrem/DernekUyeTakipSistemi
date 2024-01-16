namespace DernekUyeTakipSistemi.Customer
{
    partial class CMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMenu));
            this.btnUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAidat = new System.Windows.Forms.Button();
            this.btnBorc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUser.BackgroundImage")));
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.Location = new System.Drawing.Point(12, 74);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(324, 295);
            this.btnUser.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnUser, "GİRİŞ İŞLEMLERİ");
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(704, 636);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 73);
            this.btnExit.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnExit, "UYGULAMADAN ÇIKIŞ");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAidat
            // 
            this.btnAidat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAidat.BackgroundImage")));
            this.btnAidat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAidat.Location = new System.Drawing.Point(378, 74);
            this.btnAidat.Name = "btnAidat";
            this.btnAidat.Size = new System.Drawing.Size(406, 295);
            this.btnAidat.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAidat, "AİDAT İŞLEMLERİ");
            this.btnAidat.UseVisualStyleBackColor = true;
            this.btnAidat.Click += new System.EventHandler(this.btnAidat_Click);
            // 
            // btnBorc
            // 
            this.btnBorc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBorc.BackgroundImage")));
            this.btnBorc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBorc.Location = new System.Drawing.Point(66, 403);
            this.btnBorc.Name = "btnBorc";
            this.btnBorc.Size = new System.Drawing.Size(547, 318);
            this.btnBorc.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnBorc, "ÖDEME İŞLEMLERİ");
            this.btnBorc.UseVisualStyleBackColor = true;
            this.btnBorc.Click += new System.EventHandler(this.btnBorc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(221, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // CMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 733);
            this.ControlBox = false;
            this.Controls.Add(this.btnBorc);
            this.Controls.Add(this.btnAidat);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CMenu";
            this.Text = "Müşteri Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAidat;
        private System.Windows.Forms.Button btnBorc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}