using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class BlGraph
    {
        private DalGraph _dalGraph;
        public BlGraph()
        {
            _dalGraph = new DalGraph();
        }
        public DataTable JustYil(string AidatYil)
        {
            DataTable dataTable = _dalGraph.JustYil(AidatYil);
            return dataTable;
        }
        public DataTable JustAy(string AidatAy)
        {
            DataTable dataTable = _dalGraph.JustAy(AidatAy);
            return dataTable;
        }
        public DataTable YilandAy(string AidatYil, string AidatAy)
        {
            DataTable dataTable = _dalGraph.YilandAy(AidatYil, AidatAy);
            return dataTable;
        }
        public DataTable IlSorgu()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalGraph.IlCekme();
            return dataTable;
        }
        public DataTable IlceSorgu(int ilID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalGraph.IlceCekme(ilID);
            return dataTable;
        }
        public DataTable IleGoreKSayi(int ilID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalGraph.IleGoreKSayi(ilID);
            return dataTable;
        }
        public DataTable IlceyeGoreKSayi(int ilceID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalGraph.IlceyeGoreKSayi(ilceID);
            return dataTable;
        }
    }
}
