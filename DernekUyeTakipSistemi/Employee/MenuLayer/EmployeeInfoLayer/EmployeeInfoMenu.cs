using BusinessLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.EmployeeInfoLayer.MenuLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.EmployeeInfoLayer
{
    public partial class EmployeeInfoMenu : Form
    {
        private EmployeeInfoLogin UserName;
        private EmployeeInfoPersonal UserUpdate;
        private bool uygulamaKapatildi = false;
        public static string Tc_no { get; set; }
        public EmployeeInfoMenu()
        {
            InitializeComponent();
        }
        private void btnUserName_Click(object sender, EventArgs e)
        {
            if (UserName == null || UserName.IsDisposed)
            {
                UserName = new EmployeeInfoLogin();
                UserName.FormClosed += (s, args) => this.Focus();
                UserName.Show();
                UserName.TcAtama(Tc_no);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UserUpdate == null || UserUpdate.IsDisposed)
            {
                UserUpdate = new EmployeeInfoPersonal();
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
            EMenu eMenu = Application.OpenForms["EMenu"] as EMenu;
            eMenu.Show();
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
        private void EmployeeInfoMenu_FormClosing(object sender, FormClosingEventArgs e)
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