using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DernekUyeTakipSistemi.Customer.MenuLayer
{
    public partial class CustomerDues : Form
    {
        BlUserLogin _blUserLogin;
        public static string Tc_no { get; set; }
        private bool uygulamaKapatildi = false;
        public CustomerDues()
        {
            InitializeComponent();
            cbOdeme.SelectedItem = "Tümü";
            _blUserLogin = new BlUserLogin();
        }
        private void ekran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = ekran.Rows[e.RowIndex];
                cbYil.SelectedItem = selectedRow.Cells["AidatYil"].Value.ToString();
                int ayNumarasi = Convert.ToInt32(selectedRow.Cells["AidatAy"].Value);

                // Ay isimlerini içeren bir dizi oluştur
                string[] ayIsimleri = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

                // Ay numarasına karşılık gelen ay ismini bul
                string seciliAy = ayIsimleri[ayNumarasi - 1];

                // Combobox'ta göster
                cbAy.SelectedItem = seciliAy;
            }
        }
        private void ekran_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Örneğin, SonOdemeTarih sütunu 5. sütun, OdemeDurum sütunu ise 3. sütun ise
                int sonOdemeTarihIndex = ekran.Columns["SonOdemeTarih"].Index;
                int odemeDurumIndex = ekran.Columns["OdemeDurum"].Index;

                if (e.ColumnIndex == sonOdemeTarihIndex || e.ColumnIndex == odemeDurumIndex)
                {
                    // Son ödeme tarihi değerini al
                    DateTime sonOdemeTarih = Convert.ToDateTime(ekran.Rows[e.RowIndex].Cells[sonOdemeTarihIndex].Value);

                    // Odeme durumu değerini al
                    bool odemeDurum = Convert.ToBoolean(ekran.Rows[e.RowIndex].Cells[odemeDurumIndex].Value);

                    // Günümüz tarihini al
                    DateTime simdikiTarih = DateTime.Now;

                    // Eğer son ödeme tarihi geçmiş ve ödeme durumu false ise, satırın arka plan rengini kırmızı yap
                    if (sonOdemeTarih < simdikiTarih && !odemeDurum)
                    {
                        ekran.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    // Eğer ödeme durumu true ise, satırın arka plan rengini yeşil yap
                    else if (odemeDurum)
                    {
                        ekran.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    // Eğer son ödeme tarihine 5 gün kala ise, satırın arka plan rengini sarı yap
                    else if ((sonOdemeTarih - simdikiTarih).Days <= 5)
                    {
                        ekran.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cbYil.SelectedItem = null;
            cbAy.SelectedItem = null;
            cbOdeme.SelectedItem = "Tümü";
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            string itemSelect = (string)cbOdeme.SelectedItem;
            if (cbYil.SelectedItem != null && cbAy.SelectedItem != null && itemSelect == "Tümü")
            {
                string Yil = cbYil.SelectedItem.ToString();
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                ekran.DataSource = _blUserLogin.AidatYilAySorgu1(Tc_no, Yil, Ay);
            }
            if (cbYil.SelectedItem != null && cbAy.SelectedItem != null && itemSelect == "Ödenmiş")
            {
                string Yil = cbYil.SelectedItem.ToString();
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                bool OdemeDurum = true;
                ekran.DataSource = _blUserLogin.AidatYilAySorgu2(Tc_no, Yil, Ay, OdemeDurum);
            }
            if (cbYil.SelectedItem != null && cbAy.SelectedItem != null && itemSelect == "Ödenmemiş")
            {
                string Yil = cbYil.SelectedItem.ToString();
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                bool OdemeDurum = false;
                ekran.DataSource = _blUserLogin.AidatYilAySorgu2(Tc_no, Yil, Ay, OdemeDurum);
            }
            //**************************************************************************************************************\\
            if (cbYil.SelectedItem != null && cbAy.SelectedItem == null && itemSelect == "Tümü")
            {
                string Yil = cbYil.SelectedItem.ToString();
                ekran.DataSource = _blUserLogin.AidatYilSorgu1(Tc_no, Yil);
            }
            if (cbYil.SelectedItem != null && cbAy.SelectedItem == null && itemSelect == "Ödenmiş")
            {
                string Yil = cbYil.SelectedItem.ToString();
                bool OdemeDurum = true;
                ekran.DataSource = _blUserLogin.AidatYilSorgu2(Tc_no, Yil, OdemeDurum);
            }
            if (cbYil.SelectedItem != null && cbAy.SelectedItem == null && itemSelect == "Ödenmemiş")
            {
                string Yil = cbYil.SelectedItem.ToString();
                bool OdemeDurum = false;
                ekran.DataSource = _blUserLogin.AidatYilSorgu2(Tc_no, Yil, OdemeDurum);
            }
            //**************************************************************************************************************\\
            if (cbYil.SelectedItem == null && cbAy.SelectedItem != null && itemSelect == "Tümü")
            {
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                ekran.DataSource = _blUserLogin.AidatAySorgu1(Tc_no, Ay);
            }
            if (cbYil.SelectedItem == null && cbAy.SelectedItem != null && itemSelect == "Ödenmiş")
            {
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                bool OdemeDurum = true;
                ekran.DataSource = _blUserLogin.AidatAySorgu2(Tc_no, Ay, OdemeDurum);
            }
            if (cbYil.SelectedItem == null && cbAy.SelectedItem != null && itemSelect == "Ödenmemiş")
            {
                string ay = cbAy.SelectedItem.ToString();
                int AyNumarasi = cbAy.Items.IndexOf(ay) + 1;
                string Ay = AyNumarasi < 10 ? "0" + AyNumarasi.ToString() : AyNumarasi.ToString();
                bool OdemeDurum = false;
                ekran.DataSource = _blUserLogin.AidatAySorgu2(Tc_no, Ay, OdemeDurum);
            }
            //**************************************************************************************************************\\
            if (cbYil.SelectedItem == null && cbAy.SelectedItem == null && itemSelect == "Tümü")
            {
                ekran.DataSource = _blUserLogin.AidatBosSorgu1(Tc_no);
            }
            if (cbYil.SelectedItem == null && cbAy.SelectedItem == null && itemSelect == "Ödenmiş")
            {
                bool OdemeDurum = true;
                ekran.DataSource = _blUserLogin.AidatBosSorgu2(Tc_no, OdemeDurum);
            }
            if (cbYil.SelectedItem == null && cbAy.SelectedItem == null && itemSelect == "Ödenmemiş")
            {
                bool OdemeDurum = false;
                ekran.DataSource = _blUserLogin.AidatBosSorgu2(Tc_no, OdemeDurum);
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            uygulamaKapatildi = true;
            this.Close();
            CMenu cMenu = Application.OpenForms["CMenu"] as CMenu;
            cMenu?.Show();
        }
        private void CustomerDues_FormClosing(object sender, FormClosingEventArgs e)
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
