using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class BlUserLogin
    {
        private DalUserLogin _dalUserLogin;
        private DalUser _dalUser;
        public BlUserLogin()
        {
            _dalUserLogin = new DalUserLogin();
            _dalUser = new DalUser();
        }
        public EntityTblUserLogin getSorgu(string kullaniciAd, string sifre)
        {
            EntityTblUserLogin kullaniciGirisi = new EntityTblUserLogin();
            DataTable dataTable = new DataTable();

            dataTable = _dalUserLogin.SearchKullaniciAdiveSifre(kullaniciAd, sifre);

            foreach (DataRow dr in dataTable.Rows)
            {
                kullaniciGirisi.kullaniciAd = dr["kullaniciAd"].ToString();
                kullaniciGirisi.kullaniciSifre = dr["kullaniciSifre"].ToString();
                kullaniciGirisi.Auth = dr["Auth"].ToString();
                kullaniciGirisi.Status = dr["Status"].ToString();
            }
            return kullaniciGirisi;
        }
        public bool KullaniciAdBelirle(string Tc, string Ad)
        {
            bool onay = false;
            Random rnd = new Random(3);
            string parolasayi = rnd.Next().ToString();
            string kullaniciAd = Ad.Substring(3) + Tc.Substring(3);
            string kullaniciSifre = Ad.Substring(2) + Tc.Substring(2) + parolasayi;
            onay = _dalUserLogin.UserKullaniciAdBelirle(Tc, kullaniciAd, kullaniciSifre);
            return onay;
        }
        public string TcNoAl(string KAd)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.SearchTcNo(KAd);
            string tcNo = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                tcNo = dataTable.Rows[0]["Tc_No"].ToString();
            }
            return tcNo;
        }
        public string KAdGetir(string Tc)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.SearchKAd(Tc);
            string KAd = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                KAd = dataTable.Rows[0]["kullaniciAd"].ToString();
            }
            return KAd;
        }
        public string ParolaGetir(string Tc)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.SearchParola(Tc);
            string Parola = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Parola = dataTable.Rows[0]["kullaniciSifre"].ToString();
            }
            return Parola;
        }
        public bool KullaniciAdSifreDegistir1(string Tc_No, string KAd,string Sifre, string statu)
        {
            bool onay = false;
            onay = _dalUserLogin.UserKullaniciAdSifreDegistir1(Tc_No,KAd,Sifre,statu);
            return onay;
        }
        public bool KullaniciAdSifreDegistir2(string Tc_No, string KAd, string Sifre)
        {
            bool onay = false;
            onay = _dalUserLogin.UserKullaniciAdSifreDegistir2(Tc_No, KAd, Sifre);
            return onay;
        }
        public bool KullaniciAdDegistir1(string Tc_No, string KAd, string statu)
        {
            bool onay = false;
            onay = _dalUserLogin.UserKullaniciAdDegistir1(Tc_No, KAd, statu);
            return onay;
        }
        public bool KullaniciAdDegistir2(string Tc_No, string KAd)
        {
            bool onay = false;
            onay = _dalUserLogin.UserKullaniciAdDegistir2(Tc_No, KAd);
            return onay;
        }
        public bool SifreDegistir1(string Tc_No, string Sifre, string statu)
        {
            bool onay = false;
            onay = _dalUserLogin.UserSifreDegistir1(Tc_No, Sifre, statu);
            return onay;
        }
        public bool SifreDegistir2(string Tc_No, string Sifre)
        {
            bool onay = false;
            onay = _dalUserLogin.UserSifreDegistir2(Tc_No, Sifre);
            return onay;
        }
        public DataTable TcArama(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUser.TcArama(Tc_No);
            return dataTable;
        }
//**************************************************************************************************************\\
        public DataTable AidatBosSorgu1(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatBos1(Tc_No);
            return dataTable;
        }
        public DataTable AidatAySorgu1(string Tc_No, string Ay)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatAy1(Tc_No, Ay);
            return dataTable;
        }
        public DataTable AidatYilSorgu1(string Tc_No, string Yil)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatYil1(Tc_No, Yil);
            return dataTable;
        }
        public DataTable AidatYilAySorgu1(string Tc_No, string Yil, string Ay)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatYilAy1(Tc_No, Yil, Ay);
            return dataTable;
        }
        public DataTable AidatBosSorgu2(string Tc_No, bool OdemeDurum)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatBos2(Tc_No,OdemeDurum);
            return dataTable;
        }
        public DataTable AidatAySorgu2(string Tc_No, string Ay, bool OdemeDurum)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatAy2(Tc_No, Ay, OdemeDurum);
            return dataTable;
        }
        public DataTable AidatYilSorgu2(string Tc_No, string Yil, bool OdemeDurum)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatYil2(Tc_No, Yil, OdemeDurum);
            return dataTable;
        }
        public DataTable AidatYilAySorgu2(string Tc_No, string Yil, string Ay, bool OdemeDurum)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalUserLogin.AidatYilAy2(Tc_No, Yil, Ay, OdemeDurum);
            return dataTable;
        }
//**************************************************************************************************************\\
    }
}