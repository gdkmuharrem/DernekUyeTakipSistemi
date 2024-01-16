using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class BlAidat
    {
        private DalAidat _dalAidat;
        public BlAidat()
        {
            _dalAidat = new DalAidat();
        }
        public DataTable TabloSorgu()
        {
            DataTable dataTable = _dalAidat.AidatTablo();
            return dataTable;
        }
        public bool EklemeSorgu(int AidatID, string AidatYil, string AidatAy, int AidatTutar)
        {
            bool onay = false;
            onay = _dalAidat.AidatEkle(AidatID, AidatYil, AidatAy, AidatTutar);
            return onay;
        }
        public bool SilmeSorgu(int AidatID)
        {
            bool onay = false;
            onay = _dalAidat.AidatSil(AidatID);
            return onay;
        }
        public bool GuncellemeSorgu(int AidatID, string AidatYil, string AidatAy, int AidatTutar)
        {
            bool onay = false;
            onay = _dalAidat.AidatGuncelle(AidatID, AidatYil, AidatAy, AidatTutar);
            return onay;
        }
        public DataTable AidatOdeme1(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme1(Tc_No);
            return dataTable;
        }
        public DataTable AidatOdeme2(string Tc_No, string yil)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme2(Tc_No,yil);
            return dataTable;
        }
        public DataTable AidatOdeme3(string Tc_No, string yil, string ay)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme3(Tc_No,yil,ay);
            return dataTable;
        }
        public DataTable AidatOdeme4()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme4();
            return dataTable;
        }
        public DataTable AidatOdeme5(string yil)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme5(yil);
            return dataTable;
        }
        public DataTable AidatOdeme6(string yil, string ay)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.AidatOdeme6(yil, ay);
            return dataTable;
        }
        public DataTable TcSorgu()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalAidat.TcQuery();
            return dataTable;
        }
        public bool BorcEkle(string Tc_No, int AidatID, int OdemeMiktar)
        {
            bool onay = false;
            onay = _dalAidat.BorcEkleQuery(Tc_No,AidatID,OdemeMiktar);
            return onay;
        }
        public bool BorcGuncelle(string Tc_No, int AidatID, int YeniMiktar)
        {
            bool onay = false;
            onay = _dalAidat.BorcGuncelleQuery(Tc_No,AidatID,YeniMiktar);
            return onay;
        }
    }
}
