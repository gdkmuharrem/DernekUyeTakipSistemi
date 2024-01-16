using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class BlList
    {
        private DalList _dalList;
        public BlList()
        {
            _dalList = new DalList();
        }
        public DataTable IlSorgu()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.IlCekme();
            return dataTable;
        }
        public DataTable IlceSorgu(int ilID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.IlceCekme(ilID);
            return dataTable;
        }
        public DataTable KanSorgu1()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.KanSorgu1();
            return dataTable;
        }
        public DataTable KanSorgu2(string Grup)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.KanSorgu2(Grup);
            return dataTable;
        }
        public DataTable StatuSorgu1()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.StatuSorgu1();
            return dataTable;
        }
        public DataTable StatuSorgu2(string Statu)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.StatuSorgu2(Statu);
            return dataTable;
        }
        public DataTable BorcSorgu1()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.BorcSorgu1();
            return dataTable;
        }
        public DataTable BorcSorgu2(bool borcBilgi)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.BorcSorgu2(borcBilgi);
            return dataTable;
        }
        public DataTable IlIlceTablo(int IlId)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.IlIlceTablo(IlId);
            return dataTable;
        }
        public DataTable TariheGore(DateTime dt1, DateTime dt2)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalList.TariheGore(dt1,dt2);
            return dataTable;
        }
    }
}
