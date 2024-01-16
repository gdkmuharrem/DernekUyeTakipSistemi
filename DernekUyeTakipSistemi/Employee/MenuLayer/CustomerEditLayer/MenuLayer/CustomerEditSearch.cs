using BusinessLayer;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace DernekUyeTakipSistemi.Employee.MenuLayer.CustomerEditLayer.MenuLayer
{
    public partial class CustomerEditSearch : Form
    {
        public CustomerEditSearch()
        {
            InitializeComponent();
            txt1.KeyPress += new KeyPressEventHandler(txt1_KeyPress);
            txt2.KeyPress += new KeyPressEventHandler(txt2_KeyPress);
        }
        private void rbTc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTc.Checked)
            {
                txt1.Text = null;
                txt2.Text = null;
                lb1.Visible = true;
                lb2.Visible = false;
                txt1.Visible = true;
                txt2.Visible = false;
                lb1.Text = "Tc No";
                lb2.Text = null;
                txt1.MaxLength = 11;
            }
        }
        private void rbAdSoyad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdSoyad.Checked)
            {
                txt1.Text = null;
                txt2.Text = null;
                lb1.Visible = true;
                lb2.Visible = true;
                txt1.Visible = true;
                txt2.Visible = true;
                lb1.Text = "Ad";
                lb2.Text = "Soyad";
                txt1.MaxLength = 15;
                txt2.MaxLength = 15;
            }
        }
        private void rbTel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTel.Checked)
            {
                txt1.Text = null;
                txt2.Text = null;
                lb1.Visible = true;
                lb2.Visible = false;
                txt1.Visible = true;
                txt2.Visible = false;
                lb1.Text = "Tel No";
                txt1.MaxLength = 15;
            }
        }
        private void rbMail_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMail.Checked)
            {
                txt1.Text = null;
                txt2.Text = null;
                lb1.Visible = true;
                lb2.Visible = false;
                txt1.Visible = true;
                txt2.Visible = false;
                lb1.Text = "Mail";
                txt1.MaxLength = 28;
            }
        }
        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbTc.Checked || rbTel.Checked)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
            if (rbAdSoyad.Checked)
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                {
                    e.Handled = true;
                }
            }
        }
        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbAdSoyad.Checked)
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                {
                    e.Handled = true;
                }
            }
        }
        private void imlec(int position)
        {
            txt1.SelectionStart = position;
            txt1.Focus();
        }
        private int eskiuzunluk = 0;
        private int KontrolEt()
        {
            string email = txt1.Text;

            if (IsValidEmail(email))
            {
                txt1.ForeColor = Color.Black;
                return 1;
            }
            else
            {
                txt1.ForeColor = Color.Red;
                return 0;
            }
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (rbTel.Checked)
            {
                string text = txt1.Text.Replace("(", "").Replace(")", "").Replace(" ", "");
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
                    txt1.Text = formattedNumber.ToString();
                    txt1.SelectionStart = txt1.Text.Length;
                }
                if (yeniuzunluk < eskiuzunluk)
                {
                    if (text.Length == 3)
                    {
                        imlec(4);
                    }
                    if (text.Length == 0)
                    {
                        txt1.Text = string.Empty;
                    }
                }
                eskiuzunluk = yeniuzunluk;
            }
            if (rbMail.Checked)
            {
                KontrolEt();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbTc.Checked)
            {
                CustomerEditMenu CustomerEditMenu = Application.OpenForms["CustomerEditMenu"] as CustomerEditMenu;
                CustomerEditMenu.TcArama(txt1.Text);
                this.Close();
            }
            if (rbAdSoyad.Checked)
            {
                CustomerEditMenu CustomerEditMenu = Application.OpenForms["CustomerEditMenu"] as CustomerEditMenu;
                CustomerEditMenu.AdSoyadArama(txt1.Text, txt2.Text);
                this.Close();
            }
            if (rbTel.Checked)
            {
                CustomerEditMenu CustomerEditMenu = Application.OpenForms["CustomerEditMenu"] as CustomerEditMenu;
                CustomerEditMenu.TelArama(txt1.Text);
                this.Close();
            }
            if (rbMail.Checked)
            {
                CustomerEditMenu CustomerEditMenu = Application.OpenForms["CustomerEditMenu"] as CustomerEditMenu;
                CustomerEditMenu.MailArama(txt1.Text);
                this.Close();
            }
        }
    }
}
