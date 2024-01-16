using BusinessLayer;
using DataAccessLayer;
using DernekUyeTakipSistemi.Admin;
using DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer.MenuLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer
{
    public partial class CustomerEditMenu : Form
    {
        BlUser _blUser;
        public CustomerEditEkle CustomerEditEkle;
        public CustemerEditDuzenle CustemerEditDuzenle;
        public CustomerEditSearch CustomerEditSearch;
        public CustomerEditLogin CustomerEditLogin;
        public string Tc_no;
        private bool uygulamaKapatildi = false;
        public CustomerEditMenu()
        {
            InitializeComponent();
            _blUser = new BlUser();
            goster();
        }
        public void goster()
        {
            ekran.DataSource = _blUser.TabloSorgu("2");
            ekran.AutoResizeColumns();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (CustomerEditEkle == null || CustomerEditEkle.IsDisposed)
            {
                CustomerEditEkle = new CustomerEditEkle();
                CustomerEditEkle.Show();
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            bool deleteSonuc = _blUser.SilmeSorgu(Tc_no);
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
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (CustemerEditDuzenle == null || CustemerEditDuzenle.IsDisposed)
            {
                CustemerEditDuzenle = new CustemerEditDuzenle();
                CustemerEditDuzenle.Show();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CustomerEditLogin == null || CustomerEditLogin.IsDisposed)
            {
                CustomerEditLogin = new CustomerEditLogin();
                CustomerEditLogin.Show();
            }
            if(CustomerEditLogin != null)
            {
                CustomerEditLogin.Show();
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormlariKapa();
            EMenu eMenu = Application.OpenForms["EMenu"] as EMenu;
            AMenu aMenu = Application.OpenForms["AMenu"] as AMenu;
            if (aMenu != null)
            {
                uygulamaKapatildi = true;
                this.Close();
                aMenu.Show();
            }
            if (eMenu != null)
            {
                uygulamaKapatildi = true;
                this.Close();
                eMenu.Show();
            }
        }
        public void FormlariKapa()
        {
            if (CustomerEditEkle != null)
            {
                CustomerEditEkle.Close();
            }
            if (CustemerEditDuzenle != null)
            {
                CustemerEditDuzenle.Close();
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (ekran.SelectedCells.Count > 0)
            {
                int selectedRowIndex = ekran.SelectedCells[0].RowIndex;

                // TC No sütununun index'i
                int tcNoColumnIndex = ekran.Columns["Tc_No"].Index;

                // Seçili satırdaki TC No'yu alın
                string tcNo = ekran.Rows[selectedRowIndex].Cells[tcNoColumnIndex].Value.ToString();

                Tc_no = tcNo;
                if (CustomerEditLogin != null)
                {
                    CustomerEditLogin.TcAtama(tcNo);
                }
                if(CustomerEditLogin == null || CustomerEditLogin.IsDisposed)
                {
                    CustomerEditLogin = new CustomerEditLogin();
                    CustomerEditLogin.TcAtama(tcNo);
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
                if (CustemerEditDuzenle != null)
                {
                    CustemerEditDuzenle.OnVeriSecildi(GetCellData(selectedRowIndex, selectedColumnIndex));
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CustomerEditSearch == null || CustomerEditSearch.IsDisposed)
            {
                CustomerEditSearch = new CustomerEditSearch();
                CustomerEditSearch.Show();
            }
            else
            {
                CustomerEditSearch.Show();
            }
        }
        public void TcArama(string TcNo)
        {
            ekran.DataSource = _blUser.TcArama(TcNo);
            ekran.AutoResizeColumns();
        }
        public void AdSoyadArama(string Ad, String Soyad)
        {
            ekran.DataSource = _blUser.AdSoyadArama(Ad, Soyad);
            ekran.AutoResizeColumns();
        }
        public void TelArama(string Tel)
        {
            ekran.DataSource = _blUser.TelArama(Tel);
            ekran.AutoResizeColumns();
        }
        public void MailArama(string Mail)
        {
            ekran.DataSource = _blUser.MailArama(Mail);
            ekran.AutoResizeColumns();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            goster();
        }
        private void CustomerEditMenu_FormClosing(object sender, FormClosingEventArgs e)
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