using DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.EmployeeEditMenu;
using DernekUyeTakipSistemi.Admin.MenuLayer.GraphLayer.GraphMenu;
using DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu;
using DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer;
using DernekUyeTakipSistemi.Employee;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Admin
{
    public partial class AMenu : Form
    {
        EmployeeEditMenu employeeMenu;
        CustomerEditMenu customerMenu;
        ListMenu listMenu;
        DuesMenu duesMenu;
        GraphMenu graphMenu;
        public AMenu()
        {
            InitializeComponent();
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (employeeMenu == null || employeeMenu.IsDisposed)
            {
                employeeMenu = new EmployeeEditMenu();
                employeeMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Çalışan Menüsüne Ulaşırken Bir HATA Oluştu."); }
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (customerMenu == null || customerMenu.IsDisposed)
            {
                customerMenu = new CustomerEditMenu();
                customerMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Müşteri Menüsüne Ulaşırken Bir HATA Oluştu."); }
        }
        private void btnAidat_Click(object sender, EventArgs e)
        {
            if (duesMenu == null || duesMenu.IsDisposed)
            {
                duesMenu = new DuesMenu();
                duesMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Aidat Menüsüne Ulaşırken Bir HATA Oluştu."); }
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            if (listMenu == null || listMenu.IsDisposed)
            {
                listMenu = new ListMenu();
                listMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Listeleme Menüsüne Ulaşırken Bir HATA Oluştu."); }
        }
        private void btnGraph_Click(object sender, EventArgs e)
        {
            if (graphMenu == null || graphMenu.IsDisposed)
            {
                graphMenu = new GraphMenu();
                graphMenu.Show();
                this.Hide();
            }
            else { MessageBox.Show("Grafik Menüsüne Ulaşırken Bir HATA Oluştu."); }
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
