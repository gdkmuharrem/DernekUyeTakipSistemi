using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class BlUser
    {
        private DalUser _dalUser;
        public BlUser() 
        {
            _dalUser = new DalUser();
        }
        public DataTable IlSorgu()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.IlCekme();
            return dataTable;
        }
        public DataTable IlceSorgu(int ilID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.IlceCekme(ilID);
            return dataTable;
        }
        public DataTable TabloSorgu(string Auth)
        {
            DataTable dataTable = _dalUser.KullaniciTablo(Auth);
            return dataTable;
        }
        public bool EklemeSorgu(string Tc_No, string Ad, string Soyad, string Cinsiyet, string Kan_Grup, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            bool onay = false;
            onay = _dalUser.KullaniciEkle(Tc_No, Ad, Soyad, Cinsiyet, Kan_Grup, Telefon, Mail, Adres, IlID, IlceID);

            return onay;
        }
        public bool SilmeSorgu(string Tc_No)
        {
            bool onay = false;
            onay = _dalUser.KullaniciSil(Tc_No);

            return onay;
        }
        public bool GuncellemeSorgu(string Tc_No, string Ad, string Soyad, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            bool onay = false;
            onay = _dalUser.KullaniciGuncelle(Tc_No, Ad, Soyad, Telefon, Mail, Adres, IlID, IlceID);
            return onay;
        }
        public DataTable TcArama(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.TcArama(Tc_No);
            return dataTable;
        }
        public DataTable AdSoyadArama(string Ad, string Soyad)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.AdSoyadArama(Ad,Soyad);
            return dataTable;
        }
        public DataTable TelArama(string Tel)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.TelArama(Tel);
            return dataTable;
        }
        public DataTable MailArama(string Mail)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.MailArama(Mail);
            return dataTable;
        }
        public string AdGetir(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.AdGetir(Tc_No);
            string Ad = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Ad = dataTable.Rows[0]["Ad"].ToString();
            }
            return Ad;
        }
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\\
        public DataTable BorcGetirBos(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.BorcGetirBos(Tc_No);
            return dataTable;
        }
        public DataTable BorcGetirYilAy(string Tc_No, string Yil, string Ay)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.BorcGetirYilAy(Tc_No, Yil, Ay);
            return dataTable;
        }
        public bool TutarGuncelle(string Tc_No, string Yil, string Ay, int tutar)
        {
            bool updatesonuc = false;
            updatesonuc = _dalUser.TutarGuncelle(Tc_No, Yil, Ay, tutar);
            return updatesonuc;
        }
    }
}