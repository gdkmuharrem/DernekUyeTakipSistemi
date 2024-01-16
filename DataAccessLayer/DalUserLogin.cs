using System;
using System.Data.OleDb;
using System.Data;
using DataAccessLayer.DbConnections;
using System.Security.Policy;

namespace DataAccessLayer
{
    public class DalUserLogin
    {
        private DbQuery query;
        public DalUserLogin()
        {
            query = new DbQuery();
        }
        public DataTable SearchKullaniciAdiveSifre(string kullaniciAdi, string sifre)
        {
            string sorgu = string.Format("Select kullaniciAd, kullaniciSifre, Auth, Status from TblUserLogin where kullaniciAd = @ad and kullaniciSifre = @sifre");
            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@ad", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@sifre", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@Auth", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@Status", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(kullaniciAdi);
            oleParameter[1].Value = Convert.ToString(sifre);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable SearchTcNo(string kullaniciAdi)
        {
            string sorgu = string.Format("Select Tc_No from TblUserLogin where kullaniciAd = @ad");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@ad", OleDbType.WChar);
            oleParameter[0].Value = Convert.ToString(kullaniciAdi);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable SearchKAd(string Tc_No)
        {
            string sorgu = "Select kullaniciAd from TblUserLogin where Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.VarChar);
            oleParameter[0].Value = Tc_No;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable SearchParola(string Tc)
        {
            string sorgu = string.Format("Select kullaniciSifre from TblUserLogin where Tc_No = @Tc");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Tc", OleDbType.WChar);
            oleParameter[0].Value = Convert.ToString(Tc);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public bool UserKullaniciAdBelirle(string Tc,string kullaniciAd, string parola)
        {
            string _query = string.Format("INSERT INTO TblUserLogin (Tc_No,kullaniciAd,kullaniciSifre,Auth) VALUES (@Tc_No, @KullaniciAd, @Sifre, @Auth)");
            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@kullaniciAd", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@kullaniciSifre", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@Auth", OleDbType.WChar);
            oleParameter[0].Value = Convert.ToString(Tc);
            oleParameter[1].Value = Convert.ToString(kullaniciAd);
            oleParameter[2].Value = Convert.ToString(parola);
            oleParameter[3].Value = Convert.ToString("2");

            return query.InsertQuery1(_query, oleParameter);
        }
        public bool UserKullaniciAdSifreDegistir1(string Tc_No, string KAd, string Sifre, string Statu)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciAd = @KAd, kullaniciSifre = @Sifre, Status=@Statu WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@KAd", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Sifre", OleDbType.VarChar);
            oleParameter[2] = new OleDbParameter("@Statu", OleDbType.VarChar);
            oleParameter[3] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = KAd;
            oleParameter[1].Value = Sifre;
            oleParameter[2].Value = Statu;
            oleParameter[3].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        public bool UserKullaniciAdSifreDegistir2(string Tc_No, string KAd, string Sifre)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciAd = @KAd, kullaniciSifre = @Sifre WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@KAd", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Sifre", OleDbType.VarChar);
            oleParameter[2] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = KAd;
            oleParameter[1].Value = Sifre;
            oleParameter[2].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        public bool UserKullaniciAdDegistir1(string Tc_No, string KAd, string statu)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciAd = @KAd, Status=@Statu WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@KAd", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Statu", OleDbType.VarChar);
            oleParameter[2] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = KAd;
            oleParameter[1].Value = statu;
            oleParameter[2].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        public bool UserKullaniciAdDegistir2(string Tc_No, string KAd)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciAd = @KAd WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@KAd", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = KAd;
            oleParameter[1].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        public bool UserSifreDegistir1(string Tc_No, string Sifre, string statu)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciSifre = @Sifre, Status=@Statu WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@Sifre", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Statu", OleDbType.VarChar);
            oleParameter[2] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = Sifre;
            oleParameter[1].Value = statu;
            oleParameter[2].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        public bool UserSifreDegistir2(string Tc_No, string Sifre)
        {
            string _query = "UPDATE TblUserLogin SET kullaniciSifre = @Sifre WHERE Tc_No = @Tc_No";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@Sifre", OleDbType.VarChar);
            oleParameter[1] = new OleDbParameter("@Tc_No", OleDbType.VarChar);

            oleParameter[0].Value = Sifre;
            oleParameter[1].Value = Tc_No;

            return query.UpdateQuery1(_query, oleParameter);
        }
        //**************************************************************************************************************\\
        public DataTable AidatBos1(string Tc_No)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo";

            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[0].Value = Tc_No;

            return query.SelectQuery1(sorgu, oleParameter); ;
        }
        public DataTable AidatAy1(string Tc_No, string Ay)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatAy = @ay";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@ay", OleDbType.WChar);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Ay;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatYil1(string Tc_No, string Yil)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatYil = @yil";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@yil", OleDbType.WChar);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Yil;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatYilAy1(string Tc_No, string Yil, string Ay)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatYil = @yil and A.AidatAy = @ay";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@yil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@ay", OleDbType.WChar);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Yil;
            oleParameter[2].Value = Ay;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatBos2(string Tc_No, bool OdemeDurum)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and O.OdemeDurum = @odeme";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = OdemeDurum;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatAy2(string Tc_No, string Ay, bool OdemeDurum)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatAy = @ay and O.OdemeDurum = @odeme";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@ay", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Ay;
            oleParameter[2].Value = OdemeDurum;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatYil2(string Tc_No, string Yil, bool OdemeDurum)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatYil = @yil and O.OdemeDurum = @odeme";

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@yil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Yil;
            oleParameter[2].Value = OdemeDurum;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatYilAy2(string Tc_No, string Yil, string Ay, bool OdemeDurum)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, A.AidatTutar, O.OdemeDurum, O.OdemeTarih, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID) WHERE O.Tc_No = @tcNo and A.AidatYil = @yil and A.AidatAy = @ay and O.OdemeDurum = @odeme";

            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@yil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@ay", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = Yil;
            oleParameter[2].Value = Ay;
            oleParameter[3].Value = OdemeDurum;

            return query.SelectQuery1(sorgu, oleParameter);
        }
    }
}
