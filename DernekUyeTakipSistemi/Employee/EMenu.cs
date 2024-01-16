using BusinessLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu;
using DernekUyeTakipSistemi.Employee.MenuLayer.EmployeeInfoLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer.MenuLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.DuesLayer.MenuLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee
{
    public partial class EMenu : Form
    {
        BlUserLogin _blUserLogin;
        BlUser _blUser;
        EmployeeInfoMenu BilgilerimMenu;
        CustomerEditMenu CustomerEditMenu;
        DuesMenu Aidat;
        ListMenu Listeleme;
        public string kullaniciAdi;
        public string tc_no;
        public EMenu()
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
        private void btnBilgilerim_Click(object sender, EventArgs e)
        {
            if (BilgilerimMenu == null || BilgilerimMenu.IsDisposed)
            {
                BilgilerimMenu = new EmployeeInfoMenu();
                BilgilerimMenu.Show();
                EmployeeInfoMenu.Tc_no = tc_no;
                this.Hide();
            }
        }
        private void btnKullanici_Click(object sender, EventArgs e)
        {
            if (CustomerEditMenu == null || CustomerEditMenu.IsDisposed)
            {
                CustomerEditMenu = new CustomerEditMenu();
                CustomerEditMenu.Show();
                this.Hide();
            }
        }
        private void btnAidat_Click(object sender, EventArgs e)
        {
            if (Aidat == null || Aidat.IsDisposed)
            {
                Aidat = new DuesMenu();
                Aidat.Show();
                this.Hide();
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            if (Listeleme == null || Listeleme.IsDisposed)
            {
                Listeleme = new ListMenu();
                Listeleme.Show();
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
