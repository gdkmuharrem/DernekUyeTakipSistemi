using DernekUyeTakipSistemi.Admin;
using DernekUyeTakipSistemi.Employee.MenuLayer.DuesLayer.MenuLayer;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee
{
    public partial class DuesMenu : Form
    {
        private bool uygulamaKapatildi = false;
        public DuesMenu()
        {
            InitializeComponent();
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            uygulamaKapatildi = true;
            FormlariKapa();
            AMenu aMenu = Application.OpenForms["AMenu"] as AMenu;
            EMenu eMenu = Application.OpenForms["EMenu"] as EMenu;
            if (aMenu != null)
            {
                this.Close();
                aMenu.Show();
            }
            if (eMenu != null)
            {
                this.Close();
                eMenu.Show();
            }
        }
        private void FormlariKapa()
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form.Name == "DuesMenu" || form.Name == "SetDues" || form.Name == "PaymentDues")
                {
                    form.Close();
                }
            }
        }
        private void btnBelirle_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SetDues"] == null)
            {
                SetDues aidatBelirle = new SetDues();
                aidatBelirle.Show();
            }
        }
        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PaymentDues"] == null)
            {
                PaymentDues aidatOdeme = new PaymentDues();
                aidatOdeme.Show();
            }
        }
        private void DuesMenu_FormClosing(object sender, FormClosingEventArgs e)
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
