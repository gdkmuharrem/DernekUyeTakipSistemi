using BusinessLayer;
using DernekUyeTakipSistemi.Customer.MenuLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Customer
{
    public partial class CMenu : Form
    {
        private CustomerInfoMenu UserMenu;
        private CustomerDues AidatMenu;
        private CustomerDebt BorcMenu;
        public string kullaniciAdi;
        BlUserLogin _blUserLogin;
        BlUser _blUser;
        private string tc_no;
        public CMenu()
        {
            InitializeComponent();
            _blUserLogin = new BlUserLogin();
            _blUser = new BlUser();
        }
        public void TcNoAlma(string a)
        {
            tc_no = _blUserLogin.TcNoAl(a);
            SetLabelText();
        }
        public void SetLabelText()
        {
            string isim = _blUser.AdGetir(tc_no);
            label1.Text = "Merhaba Sayın " + isim.ToUpper();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            if (UserMenu == null || UserMenu.IsDisposed)
            {
                UserMenu = new CustomerInfoMenu();
                UserMenu.Show();
                CustomerInfoMenu.Tc_no = tc_no;
                this.Hide();
            }
        }
        private void btnAidat_Click(object sender, EventArgs e)
        {
            if (AidatMenu == null || AidatMenu.IsDisposed)
            {
                AidatMenu = new CustomerDues();
                AidatMenu.Show();
                CustomerDues.Tc_no = tc_no;
                this.Hide();
            }
        }
        private void btnBorc_Click(object sender, EventArgs e)
        {
            if (BorcMenu == null || BorcMenu.IsDisposed)
            {
                BorcMenu = new CustomerDebt();
                CustomerDebt.Tc_No = tc_no;
                BorcMenu.Show();
                this.Hide();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult cıkıs = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "", MessageBoxButtons.YesNo);
            if (cıkıs == DialogResult.Yes)
            {
                LoginPage loginPage = Application.OpenForms["LoginPage"] as LoginPage;
                loginPage.Show();
                this.Close();
            }
        }
    }
}
