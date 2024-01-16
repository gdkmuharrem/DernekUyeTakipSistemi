using BusinessLayer;
using DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.MenuLayer;
using DernekUyeTakipSistemi.Employee.MenuLayer.EmployeeInfoLayer.MenuLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.EmployeeEditMenu
{
    public partial class EmployeeEditMenu : Form
    {
        BlEmployee _blEmployee;
        public EmployeeEditEkle InsertEmployee;
        public EmployeeEditDuzenle UpdateEmployee;
        public EmployeeEditLogin EmployeeEditLogin;
        public EmployeeEditSearch SearchEmployee;
        string tcno;
        private bool uygulamaKapatildi = false;
        public EmployeeEditMenu()
        {
            InitializeComponent();
            _blEmployee = new BlEmployee();
            goster();
        }
        public void goster()
        {
            ekran.DataSource = _blEmployee.TabloSorgu("1");
            ekran.AutoResizeColumns();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (ekran.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ekran.SelectedCells[0].RowIndex;

                // TC No sütununun index'i
                int tcNoColumnIndex = ekran.Columns["Tc_No"].Index;

                // Seçili satırdaki TC No'yu alın
                tcno = ekran.Rows[selectedRowIndex].Cells[tcNoColumnIndex].Value.ToString();

                if (EmployeeEditLogin != null)
                {
                    EmployeeEditLogin.TcAtama(tcno);
                }
                if(EmployeeEditLogin == null || EmployeeEditLogin.IsDisposed)
                {
                    EmployeeEditLogin = new EmployeeEditLogin();
                    EmployeeEditLogin.TcAtama(tcno);
                }
            }
        }
        private Dictionary<string, object> GetCellData(int rowIndex, int columnIndex)
        {
            Dictionary<string, object> cellData = new Dictionary<string, object>();

            // Seçilen hücrenin verilerini sözlüğe ekle
            foreach (DataGridViewCell cell in ekran.Rows[rowIndex].Cells)
            {
                cellData[cell.OwningColumn.Name] = cell.Value;
            }
            return cellData;
        }
        private void ekran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Seçilen satır ve sütun indekslerini al
                int selectedRowIndex = e.RowIndex;
                int selectedColumnIndex = e.ColumnIndex;

                // Seçilen hücrenin verilerini diğer forma iletmek için olayı tetikle
                if (UpdateEmployee != null)
                {
                    UpdateEmployee.OnVeriSecildi(GetCellData(selectedRowIndex, selectedColumnIndex));
                }
            }
        }
        public void TcArama(string TcNo)
        {
            ekran.DataSource = _blEmployee.TcArama(TcNo);
            ekran.AutoResizeColumns();
        }
        public void AdSoyadArama(string Ad, String Soyad)
        {
            ekran.DataSource = _blEmployee.AdSoyadArama(Ad, Soyad);
            ekran.AutoResizeColumns();
        }
        public void TelArama(string Tel)
        {
            ekran.DataSource = _blEmployee.TelArama(Tel);
            ekran.AutoResizeColumns();
        }
        public void MailArama(string Mail)
        {
            ekran.DataSource = _blEmployee.MailArama(Mail);
            ekran.AutoResizeColumns();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (InsertEmployee == null || InsertEmployee.IsDisposed)
            {
                InsertEmployee = new EmployeeEditEkle();
                InsertEmployee.Show();
            }
            else
            {
                InsertEmployee.Show();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool deleteSonuc = _blEmployee.SilmeSorgu(tcno);
            if (deleteSonuc)
            {
                MessageBox.Show("Silme işlemi başarılı.");
                goster();
            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız.");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateEmployee == null || UpdateEmployee.IsDisposed)
            {
                UpdateEmployee = new EmployeeEditDuzenle();
                UpdateEmployee.Show();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (EmployeeEditLogin == null || EmployeeEditLogin.IsDisposed)
            {
                EmployeeEditLogin = new EmployeeEditLogin();
                EmployeeEditLogin.Show();
            }
            if(EmployeeEditLogin != null)
            {
                EmployeeEditLogin.Show();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (SearchEmployee == null || SearchEmployee.IsDisposed)
            {
                SearchEmployee = new EmployeeEditSearch();
                SearchEmployee.Show();
            }
            else if (SearchEmployee != null)
            {
                SearchEmployee.Show();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            goster();
        }
        public void FormlariKapa()
        {
            if (InsertEmployee != null)
            {
                InsertEmployee.Close();
            }
            if (UpdateEmployee != null)
            {
                UpdateEmployee.Close();
            }
            if (EmployeeEditLogin != null)
            {
                EmployeeEditLogin.Close();
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormlariKapa();
            uygulamaKapatildi = true;
            this.Close();
            AMenu aMenu = Application.OpenForms["AMenu"] as AMenu;
            aMenu?.Show();
        }
        private void EmployeeEditMenu_FormClosing(object sender, FormClosingEventArgs e)
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