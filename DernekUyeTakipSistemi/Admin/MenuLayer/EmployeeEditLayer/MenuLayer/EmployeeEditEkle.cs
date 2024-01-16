using BusinessLayer;
using DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.EmployeeEditMenu;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Admin.MenuLayer.EmployeeEditLayer.MenuLayer
{
    public partial class EmployeeEditEkle : Form
    {
        BlEmployee _blEmployee;
        public EmployeeEditEkle()
        {
            InitializeComponent();
            _blEmployee = new BlEmployee();
            txtTc.MaxLength = 11;
            txtAd.MaxLength = 15;
            txtSoyad.MaxLength = 15;
            txtTel.MaxLength = 15;
            txtmail.MaxLength = 60;
            txtAdres.MaxLength = 60;
            this.AcceptButton = btnEkle;
            FillIl();
        }
        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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
        private void txtmail_TextChanged(object sender, EventArgs e)
        {
            KontrolEt();
        }
        private int KontrolEt()
        {
            string email = txtmail.Text;

            if (IsValidEmail(email))
            {
                txtmail.ForeColor = Color.Black;
                return 1;
            }
            else
            {
                txtmail.ForeColor = Color.Red;
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
            cmil.DataSource = _blEmployee.IlSorgu();
            cmil.DisplayMember = "IlAdi";
            cmil.ValueMember = "IlID";
            cmil.SelectedIndex = -1;
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
            cmilce.DataSource = _blEmployee.IlceSorgu(ilId);
            cmilce.DisplayMember = "IlceAdi";
            cmilce.ValueMember = "IlceID";
            cmilce.SelectedIndex = -1;
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
        private bool KontrolleriGecerliMi()
        {
            if (txtTc.Text.Length != 11)
            {
                MessageBox.Show("Lütfen T.C Kimlik Numaranızı Kontrol Ediniz.");
                return false;
            }

            if (txtAd.Text.Length <= 2 || txtSoyad.Text.Length <= 2)
            {
                MessageBox.Show("Lütfen Gerçek Adınızı ve Soyadınızı Giriniz.");
                return false;
            }

            if (cmCins.SelectedIndex == -1 || cmKan.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Cinsiyetinizi ve Kan Grubunuzu Seçtiğinizden Emin olunuz.");
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
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!KontrolleriGecerliMi())
            {
                return;
            }

            string cinsiyet = cmCins.SelectedItem?.ToString() ?? string.Empty;
            string kanGrubu = cmKan.SelectedItem?.ToString() ?? string.Empty;
            int ilID = cmil.SelectedIndex >= 0 ? Convert.ToInt32(cmil.SelectedValue) : -1;
            int ilceID = cmilce.SelectedIndex >= 0 ? Convert.ToInt32(cmilce.SelectedValue) : -1;

            bool insertSonuc = _blEmployee.EklemeSorgu(txtTc.Text, txtAd.Text, txtSoyad.Text, cinsiyet, kanGrubu, txtTel.Text, txtmail.Text, txtAdres.Text, ilID, ilceID);

            if (insertSonuc)
            {
                _blEmployee.KullaniciAdBelirle(txtTc.Text, txtAd.Text);
                MessageBox.Show("Kayıt Başarılı!");
                EmployeeEditMenu.EmployeeEditMenu empMenu = Application.OpenForms["EmployeeEditMenu"] as EmployeeEditMenu.EmployeeEditMenu;
                empMenu.goster();
            }
            else
            {
                MessageBox.Show("Kayıt gerçekleşirken bir hata oluştu.");
            }
        }
    }
}
