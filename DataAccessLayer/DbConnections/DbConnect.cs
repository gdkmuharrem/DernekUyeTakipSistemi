using System.Data.OleDb;

namespace DataAccessLayer.DbConnections
{
    public class DbConnect
    {
        public OleDbConnection baglanti;
        public DbConnect()
        {
            baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DernekTakipDataBase.accdb;");
        }
    }
}