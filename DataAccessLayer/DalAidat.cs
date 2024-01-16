using DataAccessLayer.DbConnections;
using System.Data.OleDb;
using System.Data;
using System;

namespace DataAccessLayer
{
    public class DalAidat
    {
        private DbQuery query;
        public DalAidat()
        {
            query = new DbQuery();
        }
        public DataTable AidatTablo()
        {
            string sorgu = "SELECT DISTINCT TblAidat.AidatID, TblAidat.AidatYil, TblAidat.AidatAy, TblAidat.AidatTutar, TblOdemeler.SonOdemeTarih FROM TblAidat LEFT JOIN TblOdemeler ON TblAidat.AidatID = TblOdemeler.AidatID ORDER BY TblAidat.AidatID\r\n";
            return query.SelectQuery2(sorgu);
        }
        public bool AidatEkle(int AidatID, string AidatYil, string AidatAy, int AidatTutar)
        {
            string sorgu = string.Format("INSERT INTO TblAidat (AidatID,AidatYil,AidatAy,AidatTutar) VALUES (@AidatID,@AidatYil,@AidatAy,@AidatTutar)");
            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@AidatID", OleDbType.Integer);
            oleParameter[1] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@AidatAy", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@AidatTutar", OleDbType.Integer);

            oleParameter[0].Value = Convert.ToString(AidatID);
            oleParameter[1].Value = Convert.ToString(AidatYil);
            oleParameter[2].Value = Convert.ToString(AidatAy);
            oleParameter[3].Value = Convert.ToString(AidatTutar);

            return query.InsertQuery1(sorgu, oleParameter);
        }
        public bool AidatSil(int AidatID)
        {
            string sorgu = string.Format("DELETE FROM TblAidat WHERE AidatID = @AidatID");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@AidatID", OleDbType.Integer);
            oleParameter[0].Value = Convert.ToString(AidatID);

            return query.DeleteQuery1(sorgu, oleParameter);
        }
        public bool AidatGuncelle(int AidatID, string AidatYil, string AidatAy, int AidatTutar)
        {
            string sorgu = string.Format("UPDATE TblAidat SET AidatID = @AidatID, AidatYil = @AidatYil, AidatAy = @AidatAy, AidatTutar = @AidatTutar WHERE AidatID = @AidatID");

            OleDbParameter[] oleParameter = new OleDbParameter[4];
            oleParameter[0] = new OleDbParameter("@AidatID", OleDbType.Integer);
            oleParameter[1] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@AidatAy", OleDbType.WChar);
            oleParameter[3] = new OleDbParameter("@AidatTutar", OleDbType.Integer);

            oleParameter[0].Value = Convert.ToString(AidatID);
            oleParameter[1].Value = Convert.ToString(AidatYil);
            oleParameter[2].Value = Convert.ToString(AidatAy);
            oleParameter[3].Value = Convert.ToString(AidatTutar);

            return query.UpdateQuery1(sorgu, oleParameter);
        }
        public DataTable AidatOdeme1(string Tc_No)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih,TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID WHERE TblUser.Tc_No = @Tc_No");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(Tc_No);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatOdeme2(string Tc_No,string yil)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih, TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID WHERE TblUser.Tc_No = @Tc_No AND TblAidat.AidatYil =@AidatYil");
            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@AidatYil", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(Tc_No);
            oleParameter[1].Value = Convert.ToString(yil);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatOdeme3(string Tc_No, string yil, string ay)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih, TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID WHERE TblUser.Tc_No = @Tc_No AND TblAidat.AidatYil =@AidatYil AND TblAidat.AidatAy=@AidatAy");
            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@AidatAy", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(Tc_No);
            oleParameter[1].Value = Convert.ToString(yil);
            oleParameter[2].Value = Convert.ToString(ay);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatOdeme4()
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih, TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID ");

            return query.SelectQuery2(sorgu);
        }
        public DataTable AidatOdeme5(string yil)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih, TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID WHERE TblAidat.AidatYil =@AidatYil");
            OleDbParameter[] oleParameter = new OleDbParameter[1];
            oleParameter[0] = new OleDbParameter("@AidatYil", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(yil);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable AidatOdeme6(string yil, string ay)
        {
            string sorgu = string.Format("SELECT TblUser.Tc_No, TblUser.Ad, TblUser.Soyad," +
                "TblAidat.AidatAy,TblAidat.AidatYil," +
                "TblOdemeler.OdemeDurum,TblOdemeler.BorcMiktar,TblOdemeler.SonOdemeTarih, TblOdemeler.OdemeTarih FROM (TblUser INNER JOIN TblOdemeler ON " +
                "TblUser.Tc_No = TblOdemeler.Tc_No) INNER JOIN TblAidat ON " +
                "TblOdemeler.AidatID = TblAidat.AidatID WHERE TblAidat.AidatYil =@AidatYil AND TblAidat.AidatAy=@AidatAy");
            OleDbParameter[] oleParameter = new OleDbParameter[2];
            oleParameter[0] = new OleDbParameter("@AidatYil", OleDbType.WChar);
            oleParameter[1] = new OleDbParameter("@AidatAy", OleDbType.WChar);

            oleParameter[0].Value = Convert.ToString(yil);
            oleParameter[1].Value = Convert.ToString(ay);

            return query.SelectQuery1(sorgu, oleParameter);
        }
        public DataTable TcQuery()
        {
            string sorgu = "SELECT TblUser.Tc_No FROM TblUser INNER JOIN TblUserLogin ON TblUser.Tc_No = TblUserLogin.Tc_No WHERE TblUserLogin.Auth = '2' AND TblUserLogin.Status = 'A'";

            return query.SelectQuery2(sorgu);
        }
        public bool BorcEkleQuery(string Tc_No, int AidatID, int OdemeMiktar)
        {
            string selectAidatQuery = "SELECT AidatAy, AidatYil FROM TblAidat WHERE AidatID = @AidatID";
            OleDbParameter[] aidatParameters = new OleDbParameter[]
            {
                new OleDbParameter("@AidatID", OleDbType.Integer) { Value = AidatID }
            };

            // Veritabanından AidatAy ve AidatYil bilgilerini al
            DataTable aidatTable = query.SelectQuery1(selectAidatQuery, aidatParameters);

            if (aidatTable != null && aidatTable.Rows.Count > 0)
            {
                // Veritabanından alınan bilgileri kullanarak SonOdemeTarih'i oluştur
                int aidatAy = Convert.ToInt32(aidatTable.Rows[0]["AidatAy"]);
                int aidatYil = Convert.ToInt32(aidatTable.Rows[0]["AidatYil"]);

                DateTime sonOdemeTarih = new DateTime(aidatYil, aidatAy, DateTime.DaysInMonth(aidatYil, aidatAy));

                // Borç ekleme sorgusu
                string _query = "INSERT INTO TblOdemeler (Tc_No, AidatID, BorcMiktar, OdemeDurum, SonOdemeTarih) " +
                                "VALUES (@Tc_No, @AidatID, @BorcMiktar, @OdemeDurum, @SonOdemeTarih)";

                OleDbParameter[] parameters = new OleDbParameter[]
                {
                    new OleDbParameter("@Tc_No", OleDbType.WChar) { Value = Tc_No },
                    new OleDbParameter("@AidatID", OleDbType.Integer) { Value = AidatID },
                    new OleDbParameter("@BorcMiktar", OleDbType.Integer) { Value = OdemeMiktar },
                    new OleDbParameter("@OdemeDurum", OleDbType.Boolean) { Value = false },
                    new OleDbParameter("@SonOdemeTarih", OleDbType.Date) { Value = sonOdemeTarih }
                };

                // Borç ekleme sorgusunu çalıştır
                return query.InsertQuery1(_query, parameters);
            }

            // AidatID'ye karşılık gelen bilgileri bulamazsak false döndür
            return false;
        }
        public bool BorcGuncelleQuery(string Tc_No, int AidatID, int YeniMiktar)
        {
            string _query = string.Format("UPDATE TblOdemeler SET BorcMiktar=@BorcMiktar WHERE Tc_No=@Tc_No AND AidatID = @AidatID");

            OleDbParameter[] oleParameter = new OleDbParameter[3];
            oleParameter[0] = new OleDbParameter("@BorcMiktar", OleDbType.Integer);
            oleParameter[1] = new OleDbParameter("@Tc_No", OleDbType.WChar);
            oleParameter[2] = new OleDbParameter("@AidatID", OleDbType.Integer);

            oleParameter[0].Value = Convert.ToString(YeniMiktar);
            oleParameter[1].Value = Convert.ToString(Tc_No);
            oleParameter[2].Value = Convert.ToString(AidatID);

            return query.UpdateQuery1(_query, oleParameter);
        }
    }
}
