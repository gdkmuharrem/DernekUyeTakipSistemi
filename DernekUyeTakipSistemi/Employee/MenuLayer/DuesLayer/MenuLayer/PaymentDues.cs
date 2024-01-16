using BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.DuesLayer.MenuLayer
{
    public partial class PaymentDues : Form
    {
        BlAidat _blaidat;
        public int _AidatID;
        private DataView NoView;
        private DataView OnView;
        private DataView TumView;
        private DataTable sorgu1;
        private DataTable sorgu2;
        private DataTable sorgu3;
        private DataTable sorgu4;
        private DataTable sorgu5;
        private DataTable sorgu6;
        public PaymentDues()
        {
            InitializeComponent();
            _blaidat = new BlAidat();
            txtTc.MaxLength = 11;
        }
        private void AidatOdeme_Load(object sender, EventArgs e)
        {
            rbTum.Visible = false;
            rbOk.Visible = false;
            rbNo.Visible = false;
            rbTum.Checked = false;
            dataGridView1.AutoResizeColumns();
        }
        private void Secildi()
        {
            if (!cbTum.Checked && !cbBireysel.Checked)
            {
                lbTc.Visible = false; txtTc.Visible = false; gbOdeme.Visible = false;
            }
        }
        private void cbTum_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTum.Checked)
            {
                rbTum.Visible = true;
                rbOk.Visible = true;
                rbNo.Visible = true;
                rbTum.Checked = true;
                cbBireysel.Checked = false;
                lbTc.Visible = false; txtTc.Visible = false;
                gbOdeme.Visible = true;
            }
            if (!cbTum.Checked)
            {
                rbTum.Visible = false;
                rbOk.Visible = false;
                rbNo.Visible = false;
                rbTum.Checked = false;
                cmOdemeYil.Text = null;
                cmOdemeAy.Text = null;
            }
            Secildi();
        }
        private void cbBireysel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBireysel.Checked)
            {
                cbTum.Checked = false;
                lbTc.Visible = true; txtTc.Visible = true;
                if (txtTc.Text.Length == 11)
                {
                    gbOdeme.Visible = true;
                }
                else
                {
                    cmOdemeYil.Text = null;
                    cmOdemeAy.Text = null;
                    gbOdeme.Visible = false;
                }
            }
            if (!cbTum.Checked)
            {
                txtTc.Clear();
                cmOdemeYil.Text = null;
                cmOdemeAy.Text = null;
            }
            Secildi();
        }
        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            if (txtTc.Text.Length == 11)
            {
                rbTum.Visible = true;
                rbOk.Visible = true;
                rbNo.Visible = true;
                rbTum.Checked = true;
                gbOdeme.Visible = true;
            }
            else
            {
                rbTum.Visible = false;
                rbOk.Visible = false;
                rbNo.Visible = false;
                rbTum.Checked = false;
                gbOdeme.Visible = false;
            }
        }
        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cbBireysel.Checked && cmOdemeYil.SelectedItem == null && cmOdemeAy.SelectedItem == null)
            {
                string Tc_No = txtTc.Text;
                sorgu1 = _blaidat.AidatOdeme1(Tc_No);
                dataGridView1.DataSource = sorgu1;
            }
            if (cbBireysel.Checked && cmOdemeYil.SelectedItem != null && cmOdemeAy.SelectedItem == null)
            {
                // Kişinin tc no ve yıla göre tüm aidatları.
                string Tc_No = txtTc.Text;
                string Yil = cmOdemeYil.Text;
                sorgu2 = _blaidat.AidatOdeme2(Tc_No, Yil);
                dataGridView1.DataSource = sorgu2;
            }
            if (cbBireysel.Checked && cmOdemeYil.SelectedItem != null && cmOdemeAy.SelectedItem != null)
            {
                // Kişinin Tc no, yil ve aya göre tüm aidatları
                string Tc_No = txtTc.Text;
                string Yil = cmOdemeYil.Text;
                string secilenAy = cmOdemeAy.SelectedItem.ToString();
                int ayNumarasi = cmOdemeAy.Items.IndexOf(secilenAy) + 1;
                string Ay = ayNumarasi < 10 ? "0" + ayNumarasi.ToString() : ayNumarasi.ToString();
                sorgu3 = _blaidat.AidatOdeme3(Tc_No, Yil, Ay);
                dataGridView1.DataSource = sorgu3;
            }
            if (cbTum.Checked && cmOdemeYil.SelectedItem == null && cmOdemeAy.SelectedItem == null)
            {
                // Herkesin tüm aidatları.
                sorgu4 = _blaidat.AidatOdeme4();
                dataGridView1.DataSource = sorgu4;
            }
            if (cbTum.Checked && cmOdemeYil.SelectedItem != null && cmOdemeAy.SelectedItem == null)
            {
                // Herkesin yila göre tüm aidatları.
                string Yil = cmOdemeYil.Text;
                sorgu5 = _blaidat.AidatOdeme5(Yil);
                dataGridView1.DataSource = sorgu5;
            }
            if (cbTum.Checked && cmOdemeYil.SelectedItem != null && cmOdemeAy.SelectedItem != null)
            {
                // Herkesin yila ve aya göre tüm aidatları.
                string Yil = cmOdemeYil.Text;
                string secilenAy = cmOdemeAy.SelectedItem.ToString();
                int ayNumarasi = cmOdemeAy.Items.IndexOf(secilenAy) + 1;
                string Ay = ayNumarasi < 10 ? "0" + ayNumarasi.ToString() : ayNumarasi.ToString();
                sorgu6 = _blaidat.AidatOdeme6(Yil, Ay);
                dataGridView1.DataSource = sorgu6;
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmOdemeAy.SelectedItem = null;
            cmOdemeYil.SelectedItem = null;
            cmOdemeAy.SelectedIndex = -1;
            cmOdemeYil.SelectedIndex = -1;
            sorgu1 = null;
            sorgu2 = null;
            sorgu3 = null;
            sorgu4 = null;
            sorgu5 = null;
            sorgu6 = null;
        }
        private void NoFilter(DataTable sorgu)
        {
            NoView = new DataView(sorgu);
            NoView.RowFilter = "OdemeDurum=false";
            dataGridView1.DataSource = NoView;
            dataGridView1.AutoResizeColumns();
        }
        private void OnFilter(DataTable sorgu)
        {
            OnView = new DataView(sorgu);
            OnView.RowFilter = "OdemeDurum=true";
            dataGridView1.DataSource = OnView;
            dataGridView1.AutoResizeColumns();
        }
        private void TumFilter(DataTable sorgu)
        {
            TumView = new DataView(sorgu);
            dataGridView1.DataSource = TumView;
            dataGridView1.AutoResizeColumns();
        }
        private void rbOk_CheckedChanged(object sender, EventArgs e)
        {
            if (sorgu1 != null) OnFilter(sorgu1);
            if (sorgu2 != null) OnFilter(sorgu2);
            if (sorgu3 != null) OnFilter(sorgu3);
            if (sorgu4 != null) OnFilter(sorgu4);
            if (sorgu5 != null) OnFilter(sorgu5);
            if (sorgu6 != null) OnFilter(sorgu6);
        }
        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (sorgu1 != null) NoFilter(sorgu1);
            if (sorgu2 != null) NoFilter(sorgu2);
            if (sorgu3 != null) NoFilter(sorgu3);
            if (sorgu4 != null) NoFilter(sorgu4);
            if (sorgu5 != null) NoFilter(sorgu5);
            if (sorgu6 != null) NoFilter(sorgu6);
        }
        private void rbTum_CheckedChanged(object sender, EventArgs e)
        {
            if (sorgu1 != null) TumFilter(sorgu1);
            if (sorgu2 != null) TumFilter(sorgu2);
            if (sorgu3 != null) TumFilter(sorgu3);
            if (sorgu4 != null) TumFilter(sorgu4);
            if (sorgu5 != null) TumFilter(sorgu5);
            if (sorgu6 != null) TumFilter(sorgu6);
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Örneğin, SonOdemeTarih sütunu 5. sütun, OdemeDurum sütunu ise 3. sütun ise
                int sonOdemeTarihIndex = dataGridView1.Columns["SonOdemeTarih"].Index;
                int odemeDurumIndex = dataGridView1.Columns["OdemeDurum"].Index;

                if (e.ColumnIndex == sonOdemeTarihIndex || e.ColumnIndex == odemeDurumIndex)
                {
                    // Son ödeme tarihi değerini al
                    DateTime sonOdemeTarih = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[sonOdemeTarihIndex].Value);

                    // Odeme durumu değerini al
                    bool odemeDurum = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[odemeDurumIndex].Value);

                    // Günümüz tarihini al
                    DateTime simdikiTarih = DateTime.Now;

                    // Eğer son ödeme tarihi geçmiş ve ödeme durumu false ise, satırın arka plan rengini kırmızı yap
                    if (sonOdemeTarih < simdikiTarih && !odemeDurum)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    // Eğer ödeme durumu true ise, satırın arka plan rengini yeşil yap
                    if (odemeDurum)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    // Eğer son ödeme tarihine 5 gün kala ise, satırın arka plan rengini sarı yap

                    if(sonOdemeTarih >= simdikiTarih && !odemeDurum)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
    }
}
