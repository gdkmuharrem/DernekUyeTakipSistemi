using BusinessLayer;
using DernekUyeTakipSistemi.Admin;
using DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu;
using DernekUyeTakipSistemi.Employee;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu
{
    public partial class ListMenu : Form
    {
        BlList _blList;
        private bool uygulamaKapatildi = false;
        public ListMenu()
        {
            InitializeComponent();
            _blList = new BlList();
            ekran.DataSource = null;
            cbOrtak1.Visible = false;
            lbOrtak1.Visible = false;
            btnMail.Visible = false;
            btnPDF.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            cbOrtak1.SelectedIndex = -1;
            cbGenel.SelectedIndex = 0;
        }
        private void KanlariComboBoxaEkle()
        {
            cbOrtak1.DataSource = null;
            cbOrtak1.Items.Clear();
            cbOrtak1.Items.Add("Tümü");
            cbOrtak1.Items.Add("0 Rh +");
            cbOrtak1.Items.Add("0 Rh -");
            cbOrtak1.Items.Add("A Rh +");
            cbOrtak1.Items.Add("A Rh -");
            cbOrtak1.Items.Add("B Rh +");
            cbOrtak1.Items.Add("B Rh -");
            cbOrtak1.Items.Add("AB Rh +");
            cbOrtak1.Items.Add("AB Rh -");
        }
        private void IlleriComboBoxaEkle()
        {
            cbOrtak1.DataSource = _blList.IlSorgu();
            cbOrtak1.DisplayMember = "IlAdi";
            cbOrtak1.ValueMember = "IlID";
            cbOrtak1.SelectedIndex = -1;
        }
        private void StatuleriComboBoxaEkle()
        {
            cbOrtak1.DataSource = null;
            cbOrtak1.Items.Clear();
            cbOrtak1.Items.Add("Tümü");
            cbOrtak1.Items.Add("Aktif Üyeler");
            cbOrtak1.Items.Add("Pasif Üyeler");
        }
        private void BorclariComboBoxaEkle()
        {
            cbOrtak1.DataSource = null;
            cbOrtak1.Items.Clear();
            cbOrtak1.Items.Add("Tümü");
            cbOrtak1.Items.Add("Borçlu Üyeler");
            cbOrtak1.Items.Add("Borcu OLMAYAN Üyeler");
        }
        private void cbGenel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ekran.DataSource = null;
            cbOrtak1.Visible = false;
            lbOrtak1.Visible = false;
            btnMail.Visible = false;
            btnPDF.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            if (cbGenel.SelectedIndex == 1)
            {
                lbOrtak1.Visible = true;
                cbOrtak1.Visible = true;
                lbOrtak1.Text = "Kan Grubu";
                KanlariComboBoxaEkle();
            }
            else if (cbGenel.SelectedIndex == 2)
            {
                lbOrtak1.Visible = true;
                cbOrtak1.Visible = true;
                lbOrtak1.Text = "İl";
                IlleriComboBoxaEkle();
            }
            else if (cbGenel.SelectedIndex == 3)
            {
                lbOrtak1.Visible = true;
                cbOrtak1.Visible = true;
                lbOrtak1.Text = "Üye Durumu";
                StatuleriComboBoxaEkle();
            }
            else if (cbGenel.SelectedIndex == 4)
            {
                lbOrtak1.Visible = true;
                cbOrtak1.Visible = true;
                btnPDF.Visible = true;
                lbOrtak1.Text = "Borç Bilgisi";
                BorclariComboBoxaEkle();
            }
            else if (cbGenel.SelectedIndex == 5)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
        }
        private void cbOrtak1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGenel.SelectedIndex == 1)
            {
                if (cbOrtak1.SelectedIndex != -1)
                {
                    string KanGrubu;
                    if (cbOrtak1.SelectedIndex == 0)
                    {
                        ekran.DataSource = _blList.KanSorgu1();
                    }
                    if (cbOrtak1.SelectedIndex > 0)
                    {
                        KanGrubu = cbOrtak1.SelectedItem?.ToString() ?? string.Empty;
                        ekran.DataSource = _blList.KanSorgu2(KanGrubu);
                    }
                }
            }
            if (cbGenel.SelectedIndex == 2)
            {
                if (cbOrtak1.SelectedIndex != 1)
                {
                    if (cbOrtak1.SelectedIndex == 0)
                    {
                        ekran.DataSource = _blList.KanSorgu1();
                    }
                    if (cbOrtak1.SelectedIndex > 0)
                    {
                        int ilID = cbOrtak1.SelectedIndex >= 0 ? Convert.ToInt32(cbOrtak1.SelectedValue) : -1;
                        ekran.DataSource = _blList.IlIlceTablo(ilID);
                    }
                }
            }
            if (cbGenel.SelectedIndex == 3)
            {
                if (cbOrtak1.SelectedIndex != -1)
                {
                    string statu;
                    if (cbOrtak1.SelectedIndex == 0)
                    {
                        ekran.DataSource = _blList.StatuSorgu1();
                    }
                    if (cbOrtak1.SelectedIndex == 1)
                    {
                        statu = "A";
                        ekran.DataSource = _blList.StatuSorgu2(statu);
                    }
                    if (cbOrtak1.SelectedIndex == 2)
                    {
                        statu = "D";
                        ekran.DataSource = _blList.StatuSorgu2(statu);
                    }
                }
            }
            if (cbGenel.SelectedIndex == 4)
            {
                if (cbOrtak1.SelectedIndex != -1)
                {
                    bool borcBilgi;
                    if (cbOrtak1.SelectedIndex == 0)
                    {
                        btnMail.Visible = false;
                        ekran.DataSource = _blList.BorcSorgu1();
                    }
                    if (cbOrtak1.SelectedIndex == 1)
                    {
                        btnMail.Visible = true;
                        borcBilgi = true;
                        ekran.DataSource = _blList.BorcSorgu2(borcBilgi);
                    }
                    if (cbOrtak1.SelectedIndex == 2)
                    {
                        btnMail.Visible = false;
                        borcBilgi = false;
                        ekran.DataSource = _blList.BorcSorgu2(borcBilgi);
                    }
                }
            }
        }    
        private void btnGeri_Click(object sender, EventArgs e)
        {
            AMenu aMenu = Application.OpenForms["AMenu"] as AMenu;
            EMenu eMenu = Application.OpenForms["EMenu"] as EMenu;
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
        private void OpenDetailsForm(DataGridViewRow selectedRow, string[] emailList)
        {
            // Yeni bir detay formu oluştur
            MailPage detailsForm = new MailPage();

            // Detay formuna tıklanan satırın bilgilerini iletiyoruz
            detailsForm.SetDetails(selectedRow.Cells["Ad"].Value.ToString(),
                selectedRow.Cells["Soyad"].Value.ToString(),
                selectedRow.Cells["Mail"].Value.ToString(),
                selectedRow.Cells["ToplamBorc"].Value.ToString(), emailList);

            // Detay formunu gösteriyoruz
            detailsForm.ShowDialog();
        }
        private void btnMail_Click(object sender, EventArgs e)
        {
            if (ekran.SelectedCells.Count > 0)
            {
                // Seçili hücrenin bulunduğu satırın indeksi
                int rowIndex = ekran.SelectedCells[0].RowIndex;

                // Seçili satırın bilgilerini al
                DataGridViewRow selectedRow = ekran.Rows[rowIndex];

                string[] emailList = new string[ekran.Rows.Count];
                for (int i = 0; i < ekran.Rows.Count; i++)
                {
                    // Her satırın Mail hücresinden değeri al ve diziye ekle
                    if (ekran.Rows[i].Cells["Mail"].Value != null)
                    {
                        emailList[i] = ekran.Rows[i].Cells["Mail"].Value.ToString();
                    }
                    else
                    {
                        emailList[i] = ""; // Eğer Mail hücresi boşsa, diziye boş bir değer ekleyebilirsiniz
                    }
                }
                OpenDetailsForm(selectedRow, emailList);
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "DataGridExport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridToPdf(ekran, saveFileDialog.FileName);
            }
        }
        private void ExportDataGridToPdf(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(document, fs);

                    document.Open();

                    PdfPTable table = new PdfPTable(dataGridView.Columns.Count);
                    table.WidthPercentage = 100;

                    // Add Headers
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        table.AddCell(cell);
                    }

                    // Add Data
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString()));
                            table.AddCell(pdfCell);
                        }
                    }

                    document.Add(table);
                    document.Close();

                    MessageBox.Show("PDF file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListMenu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            DataTable sorgu = _blList.TariheGore(dt1, dt2);
            if (sorgu != null)
            {
                ekran.DataSource = sorgu;
            }
        
        }
    }
}
