using BusinessLayer;
using System;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Customer.MenuLayer.CustomerInfoLayer.MenuLayer
{
    public partial class CustomerInfoLogin : Form
    {
        int gvnlkkod;
        public string Tc_no;
        BlUserLogin _blUserLogin;
        public CustomerInfoLogin()
        {
            InitializeComponent();
            txtKAd1.MaxLength = 13;
            txtKAd2.MaxLength = 13;
            txtSifre1.MaxLength = 13;
            txtSifre2.MaxLength = 13;
            txtGuvenlik.MaxLength = 6;
            _blUserLogin = new BlUserLogin();
            this.AcceptButton = btnGuncelle;
        }
        private void UserName_Load(object sender, System.EventArgs e)
        {
            this.Size = new System.Drawing.Size(310, 105);
            GuvenlikKodYenile();
            mvctKAd.Visible = false;
            mvctParola.Visible = false;
            gbKAd.Visible = false;
            gbParola.Visible = false;
            GuvenlikKod.Visible = false;
            txtGuvenlik.Visible = false;
            lb5.Visible = false;
            btnGuncelle.Visible = false;
        }
        private void txtGuvenlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void GuvenlikKodYenile()
        {
            Random random = new Random();
            gvnlkkod = random.Next(10000, 99999);
            GuvenlikKod.Text = gvnlkkod.ToString();
        }
        public void TcAtama(string tc)
        {
            Tc_no = tc;
        }
        public void MevcutKAd()
        {
            mvctKAd.Visible = true;
            mvctKAd.Text = _blUserLogin.KAdGetir(Tc_no);
        }
        public void MevcutParola()
        {
            mvctParola.Visible = true;
            mvctParola.Text = _blUserLogin.ParolaGetir(Tc_no);
        }
        private void HangisiSecili()
        {
            if (cbKAd.Checked && !cbParola.Checked)
            {
                //Sadece kullanıcı adı seçili.
                MevcutKAd();
                mvctParola.Visible = false;
                this.Size = new System.Drawing.Size(310, 300);
                gbKAd.Visible = true;
                gbParola.Visible = false;
                GuvenlikKod.Visible = true;
                txtGuvenlik.Visible = true;
                lb5.Visible = true;
                btnGuncelle.Visible = true;
                gbKAd.Location = new System.Drawing.Point(25, 70);
                GuvenlikKod.Location = new System.Drawing.Point(159, 154);
                lb5.Location = new System.Drawing.Point(65, 183);
                txtGuvenlik.Location = new System.Drawing.Point(148, 183);
                btnGuncelle.Location = new System.Drawing.Point(207, 209);
            }
            if (!cbKAd.Checked && cbParola.Checked)
            {
                //Sadece parola seçili.
                MevcutParola();
                mvctKAd.Visible = false;
                this.Size = new System.Drawing.Size(310, 300);
                gbParola.Visible = true;
                gbKAd.Visible = false;
                GuvenlikKod.Visible = true;
                txtGuvenlik.Visible = true;
                lb5.Visible = true;
                btnGuncelle.Visible = true;
                gbParola.Location = new System.Drawing.Point(25, 70);
                GuvenlikKod.Location = new System.Drawing.Point(159, 154);
                lb5.Location = new System.Drawing.Point(65, 183);
                txtGuvenlik.Location = new System.Drawing.Point(148, 183);
                btnGuncelle.Location = new System.Drawing.Point(207, 209);
            }
            if (cbKAd.Checked && cbParola.Checked)
            {
                //İkiside seçiliyse.
                MevcutKAd();
                MevcutParola();
                this.Size = new System.Drawing.Size(310, 385);
                gbKAd.Visible = true;
                gbParola.Visible = true;
                GuvenlikKod.Visible = true;
                txtGuvenlik.Visible = true;
                lb5.Visible = true;
                btnGuncelle.Visible = true;
                gbKAd.Location = new System.Drawing.Point(25, 70);
                gbParola.Location = new System.Drawing.Point(25, 150);
                GuvenlikKod.Location = new System.Drawing.Point(159, 231);
                lb5.Location = new System.Drawing.Point(65, 263);
                txtGuvenlik.Location = new System.Drawing.Point(148, 263);
                btnGuncelle.Location = new System.Drawing.Point(208, 295);
            }
            if (!cbKAd.Checked && !cbParola.Checked)
            {
                mvctKAd.Visible = false;
                mvctParola.Visible = false;
                this.Size = new System.Drawing.Size(310, 100);
                gbKAd.Visible = false;
                gbParola.Visible = false;
                GuvenlikKod.Visible = false;
                txtGuvenlik.Visible = false;
                lb5.Visible = false;
                btnGuncelle.Visible = false;
            }
        }
        private void cbKAd_CheckedChanged(object sender, EventArgs e)
        {
            HangisiSecili();
        }
        private void cbParola_CheckedChanged(object sender, EventArgs e)
        {
            HangisiSecili();
        }
        private bool KontrollerGecerliMi()
        {
            if (cbKAd.Checked && cbParola.Checked)
            {
                if (txtKAd1.Text == txtKAd2.Text)
                {
                    if (txtSifre1.Text == txtSifre2.Text)
                    {
                        if (txtGuvenlik.Text == GuvenlikKod.Text)
                        {
                            bool onay = _blUserLogin.KullaniciAdSifreDegistir2(Tc_no, txtKAd1.Text, txtSifre1.Text);
                            return onay;
                        }
                        else
                        {
                            MessageBox.Show("Güvenlik kodunu yanlış girdiniz! \nLütfen Güvenlik kodunu kontrol ediniz.");
                            txtGuvenlik.Text = null; GuvenlikKodYenile();
                            return false;
                        }
                    }
                    else if (txtSifre1.Text != txtSifre2.Text && txtGuvenlik.Text != GuvenlikKod.Text)
                    {
                        MessageBox.Show("Güvenlik Kodu YANLIŞ! \nŞifreler Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                        txtKAd1.Text = null; txtKAd2.Text = null; txtSifre1.Text = null;
                        txtSifre2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                        txtSifre1.Text = null; txtSifre2.Text = null;
                        txtGuvenlik.Text = null; GuvenlikKodYenile();
                        return false;
                    }
                }
                else if (txtKAd1.Text != txtKAd2.Text && txtGuvenlik.Text != GuvenlikKod.Text)
                {
                    MessageBox.Show("Güvenlik Kodu YANLIŞ! \nKullanıcı Adları Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtKAd1.Text = null; txtKAd2.Text = null; txtSifre1.Text = null;
                    txtSifre2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adları Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtKAd1.Text = null; txtKAd2.Text = null; txtSifre1.Text = null;
                    txtSifre2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
            }
            if (!cbKAd.Checked && cbParola.Checked)
            {
                if (txtSifre1.Text == txtSifre2.Text)
                {
                    if (txtGuvenlik.Text == GuvenlikKod.Text)
                    {
                        bool onay = _blUserLogin.SifreDegistir2(Tc_no, txtSifre1.Text);
                        return onay;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik kodunu yanlış girdiniz! \nLütfen Güvenlik kodunu kontrol ediniz.");
                        txtGuvenlik.Text = null; GuvenlikKodYenile();
                        return false;
                    }
                }
                else if (txtSifre1.Text != txtSifre2.Text && txtGuvenlik.Text != GuvenlikKod.Text)
                {
                    MessageBox.Show("Güvenlik Kodu YANLIŞ! \nŞifreler Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtSifre1.Text = null; txtSifre2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtSifre1.Text = null; txtSifre2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
            }
            if (cbKAd.Checked && !cbParola.Checked)
            {
                if (txtKAd1.Text == txtKAd2.Text)
                {
                    if (txtGuvenlik.Text == GuvenlikKod.Text)
                    {
                        bool onay = _blUserLogin.KullaniciAdDegistir2(Tc_no, txtKAd1.Text);
                        return onay;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik kodunu yanlış girdiniz! \nLütfen Güvenlik kodunu kontrol ediniz.");
                        txtGuvenlik.Text = null; GuvenlikKodYenile();
                        return false;
                    }
                }
                else if (txtKAd1.Text != txtKAd2.Text && txtGuvenlik.Text != GuvenlikKod.Text)
                {
                    MessageBox.Show("Güvenlik Kodu YANLIŞ! \nKullanıcı Adları Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtKAd1.Text = null; txtKAd2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adları Aynı DEĞİL! \nLütfen kontrol edip yeniden deneyiniz.");
                    txtKAd1.Text = null; txtKAd2.Text = null; txtGuvenlik.Text = null; GuvenlikKodYenile();
                    return false;
                }
            }
            if (!cbKAd.Checked && !cbParola.Checked)
            {
                return false;
            }
            else { return false; }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (KontrollerGecerliMi())
            {
                //Veri tabanına veri yollanacak ve update edilecek.
                MessageBox.Show("Başarılı işlem.");
                this.Size = new System.Drawing.Size(310, 105);
                GuvenlikKodYenile();
                gbKAd.Visible = false; txtKAd1.Clear(); txtKAd2.Clear();
                gbParola.Visible = false; txtSifre1.Clear(); txtSifre2.Clear();
                GuvenlikKod.Visible = false;
                txtGuvenlik.Visible = false; txtGuvenlik.Clear();
                lb5.Visible = false;
                btnGuncelle.Visible = false;
                cbKAd.Checked = false;
                cbParola.Checked = false;
            }
        }
    }
}
