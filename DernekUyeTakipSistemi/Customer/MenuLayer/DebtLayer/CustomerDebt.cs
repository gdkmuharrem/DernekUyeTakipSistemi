using BusinessLayer;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Customer.MenuLayer
{
    public partial class CustomerDebt : Form
    {
        BlUser _blUser;
        public static string Tc_No { get; set; }
        private bool uygulamaKapatildi = false;
        public CustomerDebt()
        {
            InitializeComponent();
            _blUser = new BlUser();
            goster();
        }
        private void ekran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                cbYil.SelectedItem = selectedRow.Cells["AidatYil"].Value.ToString();
                int ay = Convert.ToInt32(selectedRow.Cells["AidatAy"].Value);
                if (ay < 10) { ay = ay - 1; string ayNo = '0' + ay.ToString();cbAy.SelectedIndex = Convert.ToInt32(ayNo); }
                if (ay >= 10) { ay = ay - 1; cbAy.SelectedIndex = ay; }
            }
        }
        private void ekran_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int sonOdemeTarihIndex = dataGridView1.Columns["SonOdemeTarih"].Index;

                if (e.ColumnIndex == sonOdemeTarihIndex)
                {
                    DateTime sonOdemeTarih = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[sonOdemeTarihIndex].Value);
                    DateTime simdikiTarih = DateTime.Now.Date;
                    if (sonOdemeTarih < simdikiTarih)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if ((sonOdemeTarih - simdikiTarih).Days <= 5)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            uygulamaKapatildi = true;
            this.Close();
            CMenu cMenu = Application.OpenForms["CMenu"] as CMenu;
            cMenu?.Show();
        }
        public void goster()
        {
            dataGridView1.DataSource = _blUser.BorcGetirBos(Tc_No);
            dataGridView1.Refresh();
            ToplamBorcGuncelle();
        }
        private void BorcMenu_Load(object sender, EventArgs e)
        {
            goster();
        }
        private void Hangisi()
        {
            if (cbYil.SelectedIndex == -1 && cbAy.SelectedIndex == -1)
            {
                goster();
            }
            if (cbYil.SelectedIndex != -1 && cbAy.SelectedIndex == -1)
            {
                ToplamBorcGuncelle();
            }
            if (cbYil.SelectedIndex == -1 && cbAy.SelectedIndex != -1)
            {
                ToplamBorcGuncelle();
            }
            if (cbYil.SelectedIndex != -1 && cbAy.SelectedIndex != -1)
            {
                string yil = cbYil.Text;
                string Ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(Ay) + 1;
                string ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                dataGridView1.DataSource = _blUser.BorcGetirYilAy(Tc_No, yil, ay);
                ToplamBorcGuncelle();
                string borc = txtBorc.Text;
                txtTutar.Text = borc;
            }
        }
        private void cbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hangisi();
        }
        private void cbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hangisi();
        }
        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (cbYil.SelectedIndex == -1 && cbAy.SelectedIndex == -1)
            {
                goster();
            }
            if (cbYil.SelectedIndex != -1 && cbAy.SelectedIndex == -1)
            {
                goster();
                cbYil.SelectedIndex = -1;
            }
            if (cbYil.SelectedIndex == -1 && cbAy.SelectedIndex != -1)
            {
                goster();
                cbAy.SelectedIndex = -1;
            }
            if (cbAy.SelectedIndex != -1 && cbAy.SelectedIndex != -1)
            {
                int tutar = Convert.ToInt32(txtTutar.Text);
                if (tutar >= 1)
                {
                    string yil = cbYil.Text;
                    string Ay = cbAy.SelectedItem.ToString();
                    int AyNumarasi = cbAy.Items.IndexOf(Ay) + 1;
                    string ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                    bool updateSonuc = false;
                    updateSonuc = _blUser.TutarGuncelle(Tc_No, yil, ay, tutar);
                    if (updateSonuc)
                    {
                        MessageBox.Show("Borç Ödeme İşlemi Başarılı.");
                        goster();
                        cbYil.SelectedIndex = -1;
                        cbAy.SelectedIndex = -1;
                        txtTutar.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Borç Ödeme İşlemi Başarısız.");
                        goster();
                        cbYil.SelectedIndex = -1;
                        cbAy.SelectedIndex = -1;
                    }
                }
                if (tutar == 0)
                {
                    goster();
                    cbYil.SelectedIndex = -1;
                    cbAy.SelectedIndex = -1;
                }
            }
        }
        private void ToplamBorcGuncelle()
        {
            int toplamBorc = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int borcMiktar;
                if (row.Cells["BorcMiktar"].Value != null && int.TryParse(row.Cells["BorcMiktar"].Value.ToString(), out borcMiktar))
                {
                    toplamBorc += borcMiktar;
                }
                else
                {
                    MessageBox.Show("BorcMiktar sütunu geçersiz bir değer içeriyor.");
                }
            }
            txtBorc.Text = toplamBorc.ToString();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cbYil.SelectedIndex = -1;
            cbAy.SelectedIndex = -1;
            txtTutar.Text = null;
        }
        private void CustomerDebt_FormClosing(object sender, FormClosingEventArgs e)
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
