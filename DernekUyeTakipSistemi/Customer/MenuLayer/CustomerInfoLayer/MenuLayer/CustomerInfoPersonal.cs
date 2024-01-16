using BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Customer.MenuLayer.CustomerInfoLayer.MenuLayer
{
    public partial class CustomerInfoPersonal : Form
    {
        public string Tc_no;
        BlUser _blUser;
        BlUserLogin _blUserLogin;
        DataTable dt;
        public CustomerInfoPersonal()
        {
            InitializeComponent();
            _blUser = new BlUser();
            _blUserLogin = new BlUserLogin();
            dt = new DataTable();
            txtTc.MaxLength = 11;
            txtAd.MaxLength = 15;
            txtSoyad.MaxLength = 15;
            txtTel.MaxLength = 15;
            txtMail.MaxLength = 60;
            txtAdres.MaxLength = 60;
            FillIl();
        }
        public void TcGetir(string tc)
        {
            Tc_no = tc;
            FormGuncelle();
        }
        private void ClearForm()
        {
            // Formdaki tüm kontrol değerlerini temizleme işlemi
            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }
        private void FormGuncelle()
        {
            dt = _blUserLogin.TcArama(Tc_no);
            if (dt.Rows.Count > 0)
            {
                txtTc.Text = dt.Rows[0]["Tc_No"].ToString();
                txtAd.Text = dt.Rows[0]["Ad"].ToString();
                txtSoyad.Text = dt.Rows[0]["Soyad"].ToString();
                cmCins.Text = dt.Rows[0]["Cinsiyet"].ToString();
                cmKan.Text = dt.Rows[0]["Kan_Grup"].ToString();
                txtTel.Text = dt.Rows[0]["Telefon"].ToString();
                txtMail.Text = dt.Rows[0]["Mail"].ToString();
                txtAdres.Text = dt.Rows[0]["Adres"].ToString();
                cmil.SelectedValue = dt.Rows[0]["IlID"].ToString();
                cmilce.SelectedValue = dt.Rows[0]["IlceID"].ToString();
            }
            else
            {
                ClearForm();
            }
        }
        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void imlec(int position)
        {
            txtTel.SelectionStart = position;
            txtTel.Focus();
        }
        private int eskiuzunluk = 0;
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            string text = txtTel.Text.Replace("(", "").Replace(")", "").Replace(" ", "");
            StringBuilder formattedNumber = new StringBuilder();
            int yeniuzunluk = text.Length;

            if (yeniuzunluk > eskiuzunluk)
            {
                if (text.Length > 0)
                {
                    formattedNumber.Append("(" + text.Substring(0, Math.Min(3, text.Length)) + ")");
                    yeniuzunluk = text.Length;
                }
                if (text.Length > 3)
                {
                    formattedNumber.Append(" " + text.Substring(3, Math.Min(3, text.Length - 3)));
                    yeniuzunluk = text.Length;
                }
                if (text.Length > 6)
                {
                    formattedNumber.Append(" " + text.Substring(6, Math.Min(2, text.Length - 6)));
                    yeniuzunluk = text.Length;
                }
                if (text.Length > 8)
                {
                    formattedNumber.Append(" " + text.Substring(8, Math.Max(0, text.Length - 8)));
                    yeniuzunluk = text.Length;
                }
                txtTel.Text = formattedNumber.ToString();
                txtTel.SelectionStart = txtTel.Text.Length;
            }
            if (yeniuzunluk < eskiuzunluk)
            {
                if (text.Length == 3)
                {
                    imlec(4);
                }
                if (text.Length == 0)
                {
                    txtTel.Text = string.Empty;
                }
            }
            eskiuzunluk = yeniuzunluk;
        }
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            KontrolEt();
        }
        private int KontrolEt()
        {
            string email = txtMail.Text;

            if (IsValidEmail(email))
            {
                txtMail.ForeColor = Color.Black;
                return 1;
            }
            else
            {
                txtMail.ForeColor = Color.Red;
                return 0;
            }
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }
        private void FillIl()
        {
            cmil.DataSource = _blUser.IlSorgu();
            cmil.DisplayMember = "IlAdi";
            cmil.ValueMember = "IlID";
            cmil.SelectedItem = -1;
        }
        private void cmil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmil.SelectedValue != null)
            {
                DataRowView selectedRow = cmil.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    int selectedIlID = Convert.ToInt32(selectedRow["IlID"]);
                    FillIlce(selectedIlID);
                }
            }
        }
        private void FillIlce(int ilId)
        {
            cmilce.DataSource = _blUser.IlceSorgu(ilId);
            cmilce.DisplayMember = "IlceAdi";
            cmilce.ValueMember = "IlceID";
            cmilce.SelectedItem = -1;
        }
        private bool KontrolleriGecerliMi()
        {
            if (txtAd.Text.Length <= 2 || txtSoyad.Text.Length <= 2)
            {
                MessageBox.Show("Lütfen Gerçek Adınızı ve Soyadınızı Giriniz.");
                return false;
            }
            if (txtTel.Text.Length != 15)
            {
                MessageBox.Show("Lütfen Telefon numaranızı uygun formatta giriniz.");
                return false;
            }
            if (KontrolEt() != 1)
            {
                MessageBox.Show("Lütfen MAİL adresinizi uygun formatta giriniz.");
                return false;
            }
            if (cmil.SelectedIndex == -1 || cmilce.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen İl ve İlçe Seçiniz.");
                return false;
            }
            if (txtAdres.Text.Length <= 7)
            {
                MessageBox.Show("Lütfen Açık Adres Bilginizi Giriniz.");
                return false;
            }
            return true;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!KontrolleriGecerliMi())
            {
                return;
            }

            int ilID = cmil.SelectedIndex >= 0 ? Convert.ToInt32(cmil.SelectedValue) : -1;
            int ilceID = cmilce.SelectedIndex >= 0 ? Convert.ToInt32(cmilce.SelectedValue) : -1;

            bool insertSonuc = _blUser.GuncellemeSorgu(txtTc.Text, txtAd.Text, txtSoyad.Text, txtTel.Text, txtMail.Text, txtAdres.Text, ilID, ilceID);

            if (insertSonuc)
            {
                MessageBox.Show("Güncelleme Başarılı!");
                ClearForm();
                FormGuncelle();
                txtAd.Focus();
                CMenu cMenu = Application.OpenForms["CMenu"] as CMenu;
                cMenu.SetLabelText();
            }
            else
            {
                MessageBox.Show("Kayıt gerçekleşirken bir hata oluştu.");
            }
        }
    }
}
