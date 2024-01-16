using System;
using System.Data;
using System.Data.OleDb;
using DataAccessLayer.DbConnections;

namespace DataAccessLayer
{
    public class DalUser
    {
        private DbQuery query;
        public DalUser()
        {
            query = new DbQuery();
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
        public DataTable KullaniciTablo(string Auth)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet, TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres, TblUser.IlID, TblUser.IlceID " +
                                         "FROM TblUser " +
                                         "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                                         "WHERE TblUserLogin.Auth = '{0}' " +
                                         "ORDER BY TblUser.Tc_No", Auth);
            return query.SelectQuery2(sorgu);
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
            return query.SelectQuery1(sorgu,oleParameters);
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
        public DataTable AdGetir(string Tc_No)
        {
            string sorgu = string.Format("SELECT Ad FROM TblUser WHERE Tc_No=@Tc_No");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(Tc_No);
            return query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable BorcGetirBos(string Tc_No)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, O.BorcMiktar, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID =" +
                " A.AidatID) WHERE O.Tc_No = @tcNo and O.OdemeDurum = @odeme";

            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = false;

            return query.SelectQuery1(sorgu, oleParameter); ;
        }
        public DataTable BorcGetirYilAy(string Tc_No, string Yil, string Ay)
        {
            string sorgu = "SELECT A.AidatAy, A.AidatYil, O.BorcMiktar, O.SonOdemeTarih FROM (TblOdemeler O INNER JOIN TblAidat A ON O.AidatID = A.AidatID)" +
                " WHERE O.Tc_No = @tcNo and O.OdemeDurum = @odeme and A.AidatYil = @yil and A.AidatAy = @ay";

            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@tcNo", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@odeme", OleDbType.Boolean);
            oleParameter[2] = new OleDbParameter("@yil", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@ay", OleDbType.WChar);
            oleParameter[0].Value = Tc_No;
            oleParameter[1].Value = false;
            oleParameter[2].Value = Yil;
            oleParameter[3].Value = Ay;

            return query.SelectQuery1(sorgu, oleParameter); ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; 
        }
        public int GetAidatID(string Yil, string Ay)
        {
            string sorgu = "SELECT AidatID FROM TblAidat WHERE AidatYil = @Yil AND AidatAy = @Ay";

            OleDbParameter[] oleDbParameters = new OleDbParameter[2];
            oleDbParameters[0] = new OleDbParameter("@Yil", OleDbType.WChar);
            oleDbParameters[1] = new OleDbParameter("@Ay", OleDbType.WChar);
            oleDbParameters[0].Value = Convert.ToString(Yil);
            oleDbParameters[1].Value = Convert.ToString(Ay);
            DataTable resultTable = query.SelectQuery1(sorgu, oleDbParameters);

            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                int aidatID = Convert.ToInt32(resultTable.Rows[0]["AidatID"]);
                return aidatID;
            }
            else
            {
                return -1;
            }
        }
        public bool TutarGuncelle(string Tc_No, string Yil, string Ay, int tutar)
        {
            int aidatId = GetAidatID(Yil, Ay);
            if (aidatId != -1)
            {
                string sorgu = "UPDATE TblOdemeler SET BorcMiktar = 0, OdemeDurum = true, OdemeMiktar = @tutar, OdemeTarih =@Gunumuz WHERE Tc_No = @Tc_No AND AidatID = @AidatID";
                OleDbParameter[] oleParameters = new OleDbParameter[4];
                oleParameters[0] = new OleDbParameter("@tutar", OleDbType.Integer);
                oleParameters[1] = new OleDbParameter("@Gunumuz", OleDbType.Date);
                oleParameters[2] = new OleDbParameter("@Tc_No", OleDbType.WChar);
                oleParameters[3] = new OleDbParameter("@AidatID", OleDbType.Integer);
                oleParameters[0].Value = tutar;
                oleParameters[1].Value = DateTime.Now.Date;
                oleParameters[2].Value = Tc_No;
                oleParameters[3].Value = aidatId;
                return query.UpdateQuery1(sorgu, oleParameters);
            }
            else
            {
                return false;
            }
        }
    }
}