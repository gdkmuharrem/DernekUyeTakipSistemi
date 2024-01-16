using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.DuesLayer.MenuLayer
{
    public partial class SetDues : Form
    {
        BlAidat _blAidat;
        public SetDues()
        {
            InitializeComponent();
            _blAidat = new BlAidat();
        }
        private void AidatBelirle_Load(object sender, EventArgs e)
        {
            goster();
            this.Height = eskiUzunluk;
        }
        public void goster()
        {
            tablo.DataSource = _blAidat.TabloSorgu();
            tablo.AutoResizeColumns();
        }
        private void cbEkle_CheckedChanged(object sender, EventArgs e)
        {
            Secildi();
        }
        private void cbDuzenle_CheckedChanged(object sender, EventArgs e)
        {
            Secildi();
        }
        private void cbSil_CheckedChanged(object sender, EventArgs e)
        {
            Secildi();
        }
        public int eskiUzunluk = 300; public int yeniUzunluk = 515;
        private void Secildi()
        {
            if (cbEkle.Checked && !cbDuzenle.Checked && !cbSil.Checked)
            {
                gbEkle.Visible = true;
                gbDuzenle.Visible = false;
                gbSil.Visible = false;
                this.Height = yeniUzunluk;
            }
            if (!cbEkle.Checked && cbDuzenle.Checked && !cbSil.Checked)
            {
                gbEkle.Visible = false;
                gbDuzenle.Visible = true;
                gbSil.Visible = false;
                this.Height = yeniUzunluk;
            }
            if (!cbEkle.Checked && !cbDuzenle.Checked && cbSil.Checked)
            {
                gbEkle.Visible = false;
                gbDuzenle.Visible = false;
                gbSil.Visible = true;
                this.Height = yeniUzunluk;
            }
            if (cbEkle.Checked && cbDuzenle.Checked && !cbSil.Checked)
            {
                gbEkle.Visible = true;
                gbDuzenle.Visible = true;
                gbSil.Visible = false;
                this.Height = yeniUzunluk;
            }
            if (cbEkle.Checked && !cbDuzenle.Checked && cbSil.Checked)
            {
                gbEkle.Visible = true;
                gbDuzenle.Visible = false;
                gbSil.Visible = true;
                this.Height = yeniUzunluk;
            }
            if (!cbEkle.Checked && cbDuzenle.Checked && cbSil.Checked)
            {
                gbEkle.Visible = false;
                gbDuzenle.Visible = true;
                gbSil.Visible = true;
                this.Height = yeniUzunluk;
            }
            if (cbEkle.Checked && cbDuzenle.Checked && cbSil.Checked)
            {
                gbEkle.Visible = true;
                gbDuzenle.Visible = true;
                gbSil.Visible = true;
                this.Height = yeniUzunluk;
            }
            if (!cbEkle.Checked && !cbDuzenle.Checked && !cbSil.Checked)
            {
                gbEkle.Visible = false;
                gbDuzenle.Visible = false;
                gbSil.Visible = false;
                this.Height = eskiUzunluk;
            }
        }
        public int kimlik;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmEkleYil != null && cmEkleAy != null && txtEkleTutar != null)
            {
                string yil = cmEkleYil.Text;
                string ay = cmEkleAy.SelectedItem.ToString();
                int tutar;
                if (txtEkleTutar.Text != "")
                {
                    tutar = Convert.ToInt32(txtEkleTutar.Text);
                }
                else
                {
                    MessageBox.Show("Lütfen tutar bilgisi giriniz.");
                    return;
                }
                string yilNumarasi = yil.Substring(2);
                int ayNumarasi = cmEkleAy.Items.IndexOf(ay) + 1;
                string duzenlenmisAyNumarasi = ayNumarasi < 10 ? "0" + ayNumarasi.ToString() : ayNumarasi.ToString();

                string ayyil = yilNumarasi + duzenlenmisAyNumarasi;
                kimlik = Convert.ToInt32(ayyil);

                bool insertsonuc = _blAidat.EklemeSorgu(kimlik, yil, duzenlenmisAyNumarasi, tutar);
                if (insertsonuc)
                {
                    MessageBox.Show("Kayıt Başarılı !");
                    goster();
                    BorcAtama(tutar);
                }
                else
                {
                    MessageBox.Show("Kayıt Başarısız !!!");
                }
            }
            else if (cmEkleYil == null)
            {
                MessageBox.Show("Lütfen Yıl Seçiniz.");
            }
            else if (cmEkleAy == null)
            {
                MessageBox.Show("Lütfen Ay Seçiniz.");
            }
            else if (txtEkleTutar == null)
            {
                MessageBox.Show("Lütfen tutar Giriniz.");
            }
            else
            {
                MessageBox.Show("Belirlenemeyen bir hata oluştu.");
            }
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (txtDuzenleTutar.Text != null)
            {
                string yil = cmDuzenleYil.Text;
                string ay = cmDuzenleAy.SelectedItem.ToString();
                int tutar = Convert.ToInt32(txtDuzenleTutar.Text);

                string yilNumarasi = yil.Substring(2);
                int ayNumarasi = cmDuzenleAy.Items.IndexOf(ay) + 1;
                string duzenlenmisAyNumarasi = ayNumarasi < 10 ? "0" + ayNumarasi.ToString() : ayNumarasi.ToString();

                string ayyil = yilNumarasi + duzenlenmisAyNumarasi;
                kimlik = Convert.ToInt32(ayyil);

                bool updatesonuc = _blAidat.GuncellemeSorgu(kimlik, yil, duzenlenmisAyNumarasi, tutar);
                if (updatesonuc)
                {
                    MessageBox.Show("Güncelleme Başarılı.");
                    goster();
                    BorcGuncelleme(tutar);
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tutar giriniz.");
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (cmSilYil != null && cmSilAy != null)
            {
                string yil = cmSilYil.Text;
                string ay = cmSilAy.SelectedItem.ToString();
                string yilNumarasi = yil.Substring(2);
                int ayNumarasi = cmSilAy.Items.IndexOf(ay) + 1;
                string duzenlenmisAyNumarasi = ayNumarasi < 10 ? "0" + ayNumarasi.ToString() : ayNumarasi.ToString();

                string ayyil = yilNumarasi + duzenlenmisAyNumarasi;
                kimlik = Convert.ToInt32(ayyil);

                bool insertsonuc = _blAidat.SilmeSorgu(kimlik);
                if (insertsonuc)
                {
                    MessageBox.Show("Silme Başarılı !");
                    goster();
                }
                else
                {
                    MessageBox.Show("Silme Başarısız !!!");
                }
            }
            else
            {
                MessageBox.Show("Belirlenemeyen bir hata oluştu.");
            }
        }
        public void BorcAtama(int tutar)
        {
            DataTable dataTable = new DataTable();
            dataTable = _blAidat.TcSorgu();
            if (dataTable.Columns.Contains("Tc_No") && dataTable.Columns["Tc_No"].DataType == typeof(string))
            {
                List<string> Tcler = new List<string>();

                foreach (DataRow row in dataTable.Rows)
                {
                    string value = row.Field<string>("Tc_No");
                    Tcler.Add(value);
                }
                foreach (string Tc_No in Tcler)
                {
                    _blAidat.BorcEkle(Tc_No, kimlik, tutar);
                }
            }
        }
        public void BorcGuncelleme(int tutar)
        {
            DataTable dataTable = new DataTable();
            dataTable = _blAidat.TcSorgu();
            if (dataTable.Columns.Contains("Tc_No") && dataTable.Columns["Tc_No"].DataType == typeof(string))
            {
                List<string> Tcler2 = new List<string>();

                foreach (DataRow row in dataTable.Rows)
                {
                    string value = row.Field<string>("Tc_No");
                    Tcler2.Add(value);
                }
                foreach (string Tc_No in Tcler2)
                {
                    _blAidat.BorcGuncelle(Tc_No, kimlik, tutar);
                }
            }
        }
        public string SecilenID; public string SecilenYil; public string SecilenAy; public string SecilenTutar;
        private void tablo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = tablo.Rows[e.RowIndex];
                if (tablo.Columns.Contains("AidatID"))
                {
                    int aidatIDColumnIndex = tablo.Columns["AidatID"].Index;
                    object aidatIDValue = selectedRow.Cells[aidatIDColumnIndex].Value;

                    int aidatYilColumnIndex = tablo.Columns["AidatYil"].Index;
                    object aidatYilValue = selectedRow.Cells[aidatYilColumnIndex].Value;

                    int aidatAyColumnIndex = tablo.Columns["AidatAy"].Index;
                    object aidatAyValue = selectedRow.Cells[aidatAyColumnIndex].Value;

                    int aidatTutarColumnIndex = tablo.Columns["AidatTutar"].Index;
                    object aidatTutarValue = selectedRow.Cells[aidatTutarColumnIndex].Value;

                    SecilenID = aidatIDValue.ToString();
                    SecilenYil = aidatYilValue.ToString();
                    SecilenAy = aidatAyValue.ToString();
                    SecilenTutar = aidatTutarValue.ToString();

                    int ay = Convert.ToInt32(SecilenAy) - 1;

                    //SİLME İŞLEMİ İÇİN GEREKLİ ATAMALAR.
                    cmSilYil.Text = SecilenYil;
                    cmSilAy.SelectedIndex = ay;

                    //GUNCELLEME İÇİN GEREKLİ ATAMALAR.
                    cmDuzenleYil.Text = SecilenYil;
                    cmDuzenleAy.SelectedIndex = ay;
                    txtDuzenleTutar.Text = SecilenTutar;
                }
            }
        }
    }
}
