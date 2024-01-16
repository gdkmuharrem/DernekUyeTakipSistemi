using DataAccessLayer.DbConnections;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer
{
    public class DalList
    {
        private DbQuery _query;
        public DalList()
        {
            _query = new DbQuery();
        }
        public DataTable IlCekme()
        {
            string sorgu = string.Format("Select IlID,IlAdi FROM Il ORDER BY IlID");
            return _query.SelectQuery2(sorgu);
        }
        public DataTable IlceCekme(int ilID)
        {
            string sorgu = string.Format("Select IlceID,IlceAdi FROM IlIlce WHERE IlID = @IlID ORDER BY IlceID");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@IlID", OleDbType.Integer);
            oleParameter[0].Value = ilID;

            return _query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable KanSorgu1()
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet," +
                " TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres " +
                "FROM TblUser " +
                "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                "WHERE TblUserLogin.Status = 'A' AND TblUserLogin.Auth = '2'");
            return _query.SelectQuery2(sorgu);
        }
        public DataTable KanSorgu2(string Grup)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet," +
                " TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres " +
                "FROM TblUser " +
                "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                "WHERE TblUserLogin.Status = 'A' AND TblUserLogin.Auth = '2' AND TblUser.Kan_Grup = @Grup");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Grup", OleDbType.VarChar);
            oleParameter[0].Value = Grup;

            return _query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable StatuSorgu1()
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet," +
                " TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres " +
                "FROM TblUser " +
                "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                "WHERE TblUserLogin.Auth = '2'");
            return _query.SelectQuery2(sorgu);
        }
        public DataTable StatuSorgu2(string Statu)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Cinsiyet," +
                " TblUser.Kan_Grup, TblUser.Telefon, TblUser.Mail, TblUser.Adres " +
                "FROM TblUser " +
                "INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No " +
                "WHERE TblUserLogin.Status = @Statu AND TblUserLogin.Auth = '2'");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Statu", OleDbType.VarChar);
            oleParameter[0].Value = Statu;

            return _query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable BorcSorgu1()
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Telefon," +
                " TblUser.Mail, SUM(TblOdemeler.BorcMiktar) AS ToplamBorc FROM ((TblUser INNER JOIN TblUserLogin" +
                " ON TblUser.Tc_No = TblUserLogin.Tc_No) INNER JOIN TblOdemeler ON TblUser.Tc_No = TblOdemeler.Tc_No)" +
                " WHERE TblUserLogin.Auth = '2' GROUP BY TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Telefon, TblUser.Mail");
            return _query.SelectQuery2(sorgu);
        }
        public DataTable BorcSorgu2(bool borcBilgi)
        {
            if (borcBilgi)
            {
                string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Telefon, TblUser.Mail," +
                    " SUM(IIf(IsNull(TblOdemeler.BorcMiktar), 0, TblOdemeler.BorcMiktar)) AS ToplamBorc FROM " +
                    "(TblUser INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No) LEFT JOIN TblOdemeler ON TblUser.Tc_No " +
                    "= TblOdemeler.Tc_No WHERE TblUserLogin.Auth = '2' GROUP BY TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Telefon," +
                    " TblUser.Mail HAVING SUM(IIf(IsNull(TblOdemeler.BorcMiktar), 0, TblOdemeler.BorcMiktar)) > 0");
                return _query.SelectQuery2(sorgu);
            }
            else
            {
                string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblUser.Telefon," +
                    " TblUser.Mail, "+"SUM(IIf(IsNull(TblOdemeler.BorcMiktar), 0, TblOdemeler.BorcMiktar))" +
                    " AS ToplamBorc FROM" + " (TblUser INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No)" +
                    " LEFT JOIN TblOdemeler ON TblUser.Tc_No" +" = TblOdemeler.Tc_No WHERE TblUserLogin.Auth = '2' GROUP BY TblUser.Tc_No," +
                    " TblUser.Ad, TblUser.Soyad, TblUser.Telefon," +
                    " TblUser.Mail HAVING SUM(IIf(IsNull(TblOdemeler.BorcMiktar), 0, TblOdemeler.BorcMiktar))" +
                    " = 0 OR SUM(TblOdemeler.BorcMiktar)" +" IS NULL");
                OleDbParameter[] oleParameter = new OleDbParameter[1];
                oleParameter[0] = new OleDbParameter("@BorcBilgi", OleDbType.Boolean);
                oleParameter[0].Value = borcBilgi;

                return _query.SelectQuery1(sorgu, oleParameter);
            }
        }
        public DataTable IlIlceTablo(int IlID)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, " +
                "TblUser.Cinsiyet, TblUser.Kan_Grup," +
                " TblUser.Telefon, TblUser.Mail, TblUser.Adres FROM TblUser" +
                " INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No WHERE TblUserLogin.Status " +
                "= 'A' AND TblUserLogin.Auth = '2' AND TblUser.IlID = @Il");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Il", OleDbType.Integer);
            oleParameter[0].Value = IlID;

            return _query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable TariheGore(DateTime dt1, DateTime dt2)
        {
            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad, TblOdemeler.OdemeTarih FROM " +
                "(TblUser INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No) INNER JOIN TblOdemeler ON TblUser.Tc_No = " +
                "TblOdemeler.Tc_No WHERE TblUserLogin.Status = 'A' AND TblUserLogin.Auth = '2' AND TblOdemeler.OdemeDurum" +
                " = true AND TblOdemeler.OdemeTarih " +">= @dt1 AND TblOdemeler.OdemeTarih <= @dt2");
            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@dt1", OleDbType.Date);
            oleParameter[1] = new OleDbParameter("@dt2", OleDbType.Date);
            oleParameter[0].Value = dt1;
            oleParameter[1].Value = dt2;
            return _query.SelectQuery1(sorgu, oleParameter);
        }
    }
}