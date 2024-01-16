using BusinessLayer;
using DernekUyeTakipSistemi.Admin;
using DernekUyeTakipSistemi.Customer;
using DernekUyeTakipSistemi.Employee;
using EntityLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi
{
    public partial class LoginPage : Form
    {
        int gvnlkkod;
        BlUserLogin _blUserLogin;
        public LoginPage()
        {
            InitializeComponent();
            _blUserLogin = new BlUserLogin();
            txtKAd.MaxLength = 40;
            txtParola.MaxLength = 40;
            txtKod.MaxLength = 5;
        }
        private void LoginPage_Load(object sender, EventArgs e)
        {
            txtKAd.Focus();
            GuvenlikKodYenile();
        }
        private void GuvenlikKodYenile()
        {
            Random random = new Random();
            gvnlkkod = random.Next(10000, 99999);
            lblKod.Text = gvnlkkod.ToString();
        }
        private void txtKAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOnay.PerformClick();
            }
        }
        private void txtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOnay.PerformClick();
            }
        }
        private void txtKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOnay.PerformClick();
            }
        }
        private void txtKod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtKAd.Clear();
            txtParola.Clear();
            txtKod.Clear();
            GuvenlikKodYenile();
            txtKAd.Focus();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhabalar Sayın Kullanıcı, " +
                "\nDernek Takip Uygulamamıza HOŞ GELDİNİZ. " +
                "\nEkranda görmüş olduğunuz kullanıcı adı ve şifre kısımlarına " +
                "\nSize daha önceden verilmiş olan bilgileri girip " +
                "\nHemen altında bulunan Yeşil renkli onay kutusu ile GİRİŞ YAPABİLİRSİNİZ." +
                "\nEğer programdan çıkmak isterseniz Kırmızı renkli EXIT tuşuna basabilirsiniz. " +
                "\nİyi günler dilerim.");
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ClearForm()
        {
            txtKAd.Clear(); txtParola.Clear();txtKod.Clear();
            GuvenlikKodYenile();
            txtKAd.Focus();
        }
        private void btnOnay_Click(object sender, EventArgs e)
        {
            EntityTblUserLogin _usrlgn = new EntityTblUserLogin();
            _usrlgn = _blUserLogin.getSorgu(txtKAd.Text, txtParola.Text);
            try
            {
                if (_usrlgn.kullaniciAd == txtKAd.Text && _usrlgn.kullaniciSifre == txtParola.Text && _usrlgn.Status == "A")
                {
                    if (!string.IsNullOrEmpty(txtKod.Text))
                    {
                        if (gvnlkkod == Convert.ToInt32(txtKod.Text))
                        {
                            if (_usrlgn.Auth == (0).ToString())
                            {
                                AMenu adminMenu = new AMenu();
                                adminMenu.Show();
                                ClearForm();
                                this.Hide();
                            }
                            else if (_usrlgn.Auth == (1).ToString())
                            {
                                EMenu employeeMenu = new EMenu();
                                employeeMenu.TcNoAlma(_usrlgn.kullaniciAd);
                                employeeMenu.Show();
                                ClearForm();
                                this.Hide();
                            }
                            else if (_usrlgn.Auth == (2).ToString())
                            {
                                CMenu customerMenu = new CMenu();
                                customerMenu.TcNoAlma(_usrlgn.kullaniciAd);
                                customerMenu.Show();
                                ClearForm();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen Hesap Yöneticiniz İle iletişime Geçiniz!\nBir problem Oluştu.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Güvenlik Kodunu YANLIŞ Girdiniz.\nLütfen Tekrar deneyiniz.");
                            txtKod.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik Kodu boş bırakılamaz.");
                        txtKod.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(" Yanlış Kullanıcı Adı veya Şifre.\n\n Tekrar Deneyiniz!");
                    txtKAd.Clear();
                    txtParola.Clear();
                    txtKAd.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Lütfen \n\nKullanıcı adı ve şifreniz ile \n\ngiriş yapınız.");
                txtKAd.Clear();
                txtParola.Clear();
                txtKAd.Focus();
            }
            finally
            {
                GuvenlikKodYenile();
                txtKod.Clear();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult cıkıs = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "", MessageBoxButtons.YesNo);
            if (cıkıs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
