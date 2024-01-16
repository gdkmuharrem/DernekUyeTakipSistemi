using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.ListLayer.ListMenu
{
    public partial class MailPage : Form
    {
        private string email, konu, icerik1;
        private string[] emailList;
        public MailPage()
        {
            InitializeComponent();
        }
        public void SetDetails(string a, string b, string c, string d, string[] emailListe)
        {
            emailList = emailListe;
            email = c;
            konu = "Borc Bilgisi Hk.";
            icerik1 = "Sayın (" + a + " " + b + "),\r\n\r\nGEDİK DERNEK TAKİP SİSTEMİMİZDE Kayıtlı Hesabınızda" +
                "\r\nToplam (" + d + ")TL  borcunuz bulunmaktadır." +
                "\r\nLütfen son ödeme tarihi geçmeden borçlarınızı ÖDEYİNİZ! " +
                "\r\nAksi durumda hakkınızda yasal işlem başlatılacaktır.\r\n\r\n" +
                "\r\nİyi Günler Dileriz, " +
                "\r\nGedik Dernek Takip Sistemi İnsan Kaynakları.";
            radioButton2.Checked = true;
            txtPosta.Visible = true;
            txtPosta.Text = email;
            txtKonu.Text = konu;
            txtIcerik.Text = icerik1;
        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtPosta.Visible = false;
                txtKonu.Text = "Kullanıcılara Gönderilecek Mail Konusunu Belirtiniz.";
                txtIcerik.Text = "Kullanıcılara Gönderilecek Mail İçeriğini Bu alana yazınız.\r\nGedik Dernek Takip Sistemi,\r\nİnsan Kaynakları";
            }
        }
        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtPosta.Visible = true;
                txtPosta.Text = email;
                txtKonu.Text = konu;
                txtIcerik.Text = icerik1;
            }
        }
        private void btnGonder_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // E-posta konu ve içeriğini alın
                string subject = txtKonu.Text;
                string body = txtIcerik.Text;

                // Her bir e-posta adresi için döngü
                foreach (string toEmail in emailList)
                {
                    // E-postayı gönder
                    if (IsValidEmail(toEmail))
                    {
                        SendEmail(toEmail, subject, body);
                        // E-posta gönderildikten sonra isteğe bağlı olarak başarı mesajı gösterebilirsiniz
                        MessageBox.Show("E-posta başarıyla gönderildi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz e-posta adresi: " + toEmail, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Tüm e-postalar gönderildikten sonra isteğe bağlı olarak bir başarı mesajı gösterebilir veya başka eylemler gerçekleştirebilirsiniz
                MessageBox.Show("Tüm e-postalar başarıyla gönderildi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton2.Checked)
            {
                // Text kutularından e-posta detaylarını al
                string toEmail = txtPosta.Text;
                string subject = txtKonu.Text;
                string body = txtIcerik.Text;

                // E-posta adresinin geçerli olup olmadığını kontrol et
                if (IsValidEmail(toEmail))
                {
                    // E-postayı gönder
                    SendEmail(toEmail, subject, body);

                    // İsteğe bağlı olarak, e-posta gönderildikten sonra başarı mesajı gösterebilir veya başka eylemler gerçekleştirebilirsiniz
                    MessageBox.Show("E-posta başarıyla gönderildi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Geçersiz e-posta adresi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void SendEmail(string to, string subject, string body)
        {
            // SMTP sunucu detaylarınız ile değiştirin
            string smtpServer = "smtp-mail.outlook.com";
            int smtpPort = 587;
            string smtpUsername = "gedikdrnk.69@hotmail.com";
            string smtpPassword = "15975365469asd+";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(smtpUsername);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
