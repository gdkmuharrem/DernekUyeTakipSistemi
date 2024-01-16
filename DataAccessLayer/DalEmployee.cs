using DataAccessLayer.DbConnections;
using System;
using System.Data;
using System.Data.OleDb;

namespace DataAccessLayer
{
    public class DalEmployee
    {
        private DbQuery query;
        public DalEmployee()
        {
            query = new DbQuery();
        }
        public DataTable KullaniciTablo(string Auth)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet, TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres, TblUser.IlID, TblUser.IlceID " +
                                         "FROM TblUser " +
                                         "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                                         "WHERE TblUserLogin.Auth = '{0}' " +
                                         "ORDER BY TblUser.Tc_No", Auth);
            return query.SelectQuery2(sorgu);
        }
        public DataTable IlCekme()
        {
            string sorgu = string.Format("Select IlID,IlAdi FROM Il ORDER BY IlID");
            return query.SelectQuery2(sorgu);
        }
        public DataTable IlceCekme(int ilID)
        {
            string sorgu = string.Format("Select IlceID,IlceAdi FROM IlIlce WHERE IlID = @IlID ORDER BY IlceID");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@IlID", OleDbType.Integer);
            oleParameter[0].Value = ilID;

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public bool EmployeeKullaniciAdBelirle(string Tc, string kullaniciAd, string parola)
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
            oleParameter[3].Value = Convert.ToString("1");

            return query.InsertQuery1(_query, oleParameter);
        }
        public bool KullaniciEkle(string Tc_No, string Ad, string Soyad, string Cinsiyet, string Kan_Grup, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            string sorgu = string.Format("INSERT INTO TblUser (Tc_No, Ad, Soyad, Cinsiyet, Kan_Grup, Telefon, Mail, Adres, IlID, IlceID) VALUES (@Tc_No, @Ad, @Soyad, @Cinsiyet, @Kan_Grup, @Telefon, @Mail, @Adres, @IlID, @IlceID)");
            OleDbParameter[] oleParameter = new OleDbParameter[10];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@Ad", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@Soyad", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@Cinsiyet", OleDbType.WChar);
            oleParameter[4] = new OleDbParameter("@Kan_Grup", OleDbType.WChar);
            oleParameter[5] = new OleDbParameter("@Telefon", OleDbType.WChar);
            oleParameter[6] = new OleDbParameter("@Mail", OleDbType.WChar);
            oleParameter[7] = new OleDbParameter("@Adres", OleDbType.WChar);
            oleParameter[8] = new OleDbParameter("@IlID", OleDbType.Integer);
            oleParameter[9] = new OleDbParameter("@IlceID", OleDbType.Integer);

            oleParameter[0].Value = Convert.ToString(Tc_No);
            oleParameter[1].Value = Convert.ToString(Ad);
            oleParameter[2].Value = Convert.ToString(Soyad);
            oleParameter[3].Value = Convert.ToString(Cinsiyet);
            oleParameter[4].Value = Convert.ToString(Kan_Grup);
            oleParameter[5].Value = Convert.ToString(Telefon);
            oleParameter[6].Value = Convert.ToString(Mail);
            oleParameter[7].Value = Convert.ToString(Adres);
            oleParameter[8].Value = IlID;
            oleParameter[9].Value = IlceID;

            return query.InsertQuery1(sorgu, oleParameter);
        }
        public bool KullaniciSil(string Tc_No)
        {
            string sorgu = string.Format("DELETE FROM TblUser WHERE Tc_No = @Tc_No");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[0].Value = Convert.ToString(Tc_No);
            return query.DeleteQuery1(sorgu, oleParameter);
        }
        public bool KullaniciGuncelle(string Tc_No, string Ad, string SoyAd, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            string sorgu = string.Format("UPDATE TblUser SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, Mail = @Mail, Adres = @Adres, IlID = @IlID, IlceID = @IlceID WHERE Tc_No = @Tc_No");

            OleDbParameter[] oleParameters = new OleDbParameter[8];
            oleParameters[0] = new OleDbParameter("@Ad", OleDbType.WChar);
            oleParameters[1] = new OleDbParameter("@Soyad", OleDbType.WChar);
            oleParameters[2] = new OleDbParameter("@Telefon", OleDbType.WChar);
            oleParameters[3] = new OleDbParameter("@Mail", OleDbType.WChar);
            oleParameters[4] = new OleDbParameter("@Adres", OleDbType.WChar);
            oleParameters[5] = new OleDbParameter("@IlID", OleDbType.Integer);
            oleParameters[6] = new OleDbParameter("@IlceID", OleDbType.Integer);
            oleParameters[7] = new OleDbParameter("@Tc_No", OleDbType.WChar);

            oleParameters[0].Value = Convert.ToString(Ad);
            oleParameters[1].Value = Convert.ToString(SoyAd);
            oleParameters[2].Value = Convert.ToString(Telefon);
            oleParameters[3].Value = Convert.ToString(Mail);
            oleParameters[4].Value = Convert.ToString(Adres);
            oleParameters[5].Value = Convert.ToString(IlID);
            oleParameters[6].Value = Convert.ToString(IlceID);
            oleParameters[7].Value = Convert.ToString(Tc_No);

            return query.UpdateQuery1(sorgu, oleParameters);
        }
        public DataTable TcArama(string Tc_No)
        {
            string sorgu = string.Format("SELECT Tc_No,Ad,Soyad,Cinsiyet,Kan_Grup,Telefon,Mail,Adres,IlID,IlceID FROM TblUser WHERE Tc_No=@Tc_No");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(Tc_No);
            return query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable AdSoyadArama(string Ad, string Soyad)
        {
            string sorgu = string.Format("SELECT Tc_No,Ad,Soyad,Cinsiyet,Kan_Grup,Telefon,Mail,Adres,IlID,IlceID FROM TblUser WHERE Ad=@Ad AND Soyad=@Soyad");
            OleDbParameter[] oleParameters = new OleDbParameter[2];
            oleParameters[0] = new OleDbParameter("@Ad", OleDbType.WChar);
            oleParameters[1] = new OleDbParameter("@Soyad", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(Ad);
            oleParameters[1].Value = Convert.ToString(Soyad);
            return query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable TelArama(string Tel)
        {
            string sorgu = string.Format("SELECT Tc_No,Ad,Soyad,Cinsiyet,Kan_Grup,Telefon,Mail,Adres,IlID,IlceID FROM TblUser WHERE Telefon=@Telefon");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@Telefon", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(Tel);
            return query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable MailArama(string Mail)
        {
            string sorgu = string.Format("SELECT Tc_No,Ad,Soyad,Cinsiyet,Kan_Grup,Telefon,Mail,Adres,IlID,IlceID FROM TblUser WHERE Mail=@Mail");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@Mail", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(Mail);
            return query.SelectQuery1(sorgu, oleParameters);
        }
    }
}
