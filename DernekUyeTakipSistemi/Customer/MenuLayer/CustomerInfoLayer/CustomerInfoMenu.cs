using DernekUyeTakipSistemi.Customer.MenuLayer.CustomerInfoLayer.MenuLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Customer.MenuLayer
{
    public partial class CustomerInfoMenu : Form
    {
        private CustomerInfoLogin UserName;
        private CustomerInfoPersonal UserUpdate;
        private bool uygulamaKapatildi = false;
        public static string Tc_no { get; set; }
        public CustomerInfoMenu()
        {
            InitializeComponent();
        }
        private void btnUserName_Click(object sender, EventArgs e)
        {
            if (UserName == null || UserName.IsDisposed)
            {
                UserName = new CustomerInfoLogin();
                UserName.FormClosed += (s, args) => this.Focus();
                UserName.Show();
                UserName.TcAtama(Tc_no);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UserUpdate == null || UserUpdate.IsDisposed)
            {
                UserUpdate = new CustomerInfoPersonal();
                UserUpdate.FormClosed += (s, args) => this.Focus();
                UserUpdate.Show();
                UserUpdate.TcGetir(Tc_no);
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormlariKapa();
            uygulamaKapatildi = true;
            this.Close();
            CMenu cMenu = Application.OpenForms["CMenu"] as CMenu;
            cMenu?.Show();
        }
        public void FormlariKapa()
        {
            if (UserName != null)
            {
                UserName.Close();
            }
            if (UserUpdate != null)
            {
                UserUpdate.Close();
            }
        }
        private void CustomerInfoMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!uygulamaKapatildi)
            {
                DialogResult cikis = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes) 
                {
                    uygulamaKapatildi = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
