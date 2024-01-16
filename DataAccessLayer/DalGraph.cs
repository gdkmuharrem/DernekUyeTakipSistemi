using DataAccessLayer.DbConnections;
using System;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    public class DalGraph
    {
        private DbQuery _query;
        public DalGraph()
        {
            _query = new DbQuery();
        }
        public DataTable JustYil(string AidatYil)
        { // TblOdemeler.OdemeMiktar,
            string sorgu = string.Format("SELECT TblOdemeler.BorcMiktar, TblAidat.AidatTutar, TblAidat.AidatAy FROM TblOdemeler INNER JOIN TblAidat ON TblOdemeler.AidatID = TblAidat.AidatID WHERE TblAidat.AidatYil = @AidatYil");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(AidatYil);
            return _query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable JustAy(string AidatAy)
        {
            string sorgu = string.Format("SELECT TblOdemeler.BorcMiktar, TblAidat.AidatTutar, TblAidat.AidatYil FROM TblOdemeler INNER JOIN TblAidat ON TblOdemeler.AidatID = TblAidat.AidatID WHERE TblAidat.AidatAy = @AidatAy");
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@AidatAy", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(AidatAy);
            return _query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable YilandAy(string AidatYil, string AidatAy)
        {
            string sorgu = @"
                SELECT TblOdemeler.BorcMiktar, TblOdemeler.OdemeMiktar, TblAidat.AidatTutar, TblUser.Ad, TblUser.Soyad
                FROM (TblUser
                    INNER JOIN TblOdemeler ON TblUser.Tc_No = TblOdemeler.Tc_No)
                    INNER JOIN TblAidat ON TblOdemeler.AidatID = TblAidat.AidatID
                WHERE TblAidat.AidatYil = @AidatYil AND TblAidat.AidatAy = @AidatAy";

            OleDbParameter[] oleParameters = new OleDbParameter[2];
            oleParameters[0] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameters[1] = new OleDbParameter("@AidatAy", OleDbType.WChar);
            oleParameters[0].Value = Convert.ToString(AidatYil);
            oleParameters[1].Value = Convert.ToString(AidatAy);

            return _query.SelectQuery1(sorgu, oleParameters);
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
        public DataTable IleGoreKSayi(int IlID)
        {
            string sorgu = @"SELECT Il.IlAdi AS IlAdi,
                            COUNT(TblUser.Tc_No) AS KullaniciSayisi
                     FROM Il INNER JOIN TblUser ON Il.IlID = TblUser.IlID
                     WHERE Il.IlID = @IlID
                     GROUP BY Il.IlAdi";
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@IlID", OleDbType.Integer);
            oleParameters[0].Value = IlID;

            return _query.SelectQuery1(sorgu, oleParameters);
        }
        public DataTable IlceyeGoreKSayi(int IlceID)
        {
            string sorgu = @"SELECT IlIlce.IlceAdi AS IlceAdi,
                            COUNT(TblUser.Tc_No) AS KullaniciSayisi
                     FROM IlIlce INNER JOIN TblUser ON IlIlce.IlceID = TblUser.IlceID
                     WHERE IlIlce.IlceID = @IlceID
                     GROUP BY IlIlce.IlceAdi";
            OleDbParameter[] oleParameters = new OleDbParameter[1];
            oleParameters[0] = new OleDbParameter("@IlceID", OleDbType.Integer);
            oleParameters[0].Value = IlceID;

            return _query.SelectQuery1(sorgu, oleParameters);
        }
    }
}
