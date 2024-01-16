using System;
using System.Data;
using System.Data.OleDb;

namespace DataAccessLayer.DbConnections
{
    public class DbQuery : DbConnect
    {
        private OleDbDataAdapter dataAdapter;
        public DbQuery()
        {
            dataAdapter = new OleDbDataAdapter();
        }
        private OleDbConnection openConnection()
        {
            if (baglanti.State == ConnectionState.Closed || baglanti.State == ConnectionState.Broken)
            {
                baglanti.Open();
            }
            return baglanti;
        }
        public DataTable SelectQuery1(String _query, OleDbParameter[] oleDbParameters)
        {
            OleDbCommand mySelectCommand = new OleDbCommand();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            dataTable = null;
            try
            {
                mySelectCommand.Connection = openConnection();
                mySelectCommand.CommandText = _query;
                mySelectCommand.Parameters.AddRange(oleDbParameters);
                dataAdapter.SelectCommand = mySelectCommand;
                dataAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Hata Kodu: " + e.ErrorCode);
                Console.WriteLine("Hata Mesajı: " + e.Message);
                Console.WriteLine("Hata Stack Trace: " + e.StackTrace);
                foreach (OleDbError error in e.Errors)
                {
                    Console.WriteLine("Hata: " + error.Message);
                }
                return null;
            }
            finally
            {
                baglanti.Close();
            }
            return dataTable;
        }
        public DataTable SelectQuery2(String _query)
        {
            OleDbCommand mySelectCommand = new OleDbCommand();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            dataTable = null;

            try
            {
                mySelectCommand.Connection = openConnection();
                mySelectCommand.CommandText = _query;
                dataAdapter.SelectCommand = null;
                dataAdapter.SelectCommand = mySelectCommand;
                dataAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Hata Kodu: " + e.ErrorCode);
                Console.WriteLine("Hata Mesajı: " + e.Message);
                Console.WriteLine("Hata Stack Trace: " + e.StackTrace);
                foreach (OleDbError error in e.Errors)
                {
                    Console.WriteLine("Hata: " + error.Message);
                }
                return null;
            }
            finally
            {
                baglanti.Close();
            }
            return dataTable;
        }
        public bool InsertQuery1(String _query, OleDbParameter[] oleDbParameters)
        {
            OleDbCommand myCommand = new OleDbCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(oleDbParameters);
                dataAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Hata Kodu: " + e.ErrorCode);
                Console.WriteLine("Hata Mesajı: " + e.Message);
                Console.WriteLine("Hata Stack Trace: " + e.StackTrace);
                foreach (OleDbError error in e.Errors)
                {
                    Console.WriteLine("Hata: " + error.Message);
                }
                return false;
            }
            finally
            {
                baglanti.Close();
            }
            return true;
        }
        public bool UpdateQuery1(String _query, OleDbParameter[] oleDbParameters)
        {
            OleDbCommand myCommand = new OleDbCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(oleDbParameters);
                dataAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Hata Kodu: " + e.ErrorCode);
                Console.WriteLine("Hata Mesajı: " + e.Message);
                Console.WriteLine("Hata Stack Trace: " + e.StackTrace);
                foreach (OleDbError error in e.Errors)
                {
                    Console.WriteLine("Hata: " + error.Message);
                }
                return false;
            }
            finally
            {
                baglanti.Close();
            }
            return true;
        }
        public bool DeleteQuery1(String _query, OleDbParameter[] oleDbParameters)
        {
            OleDbCommand myCommand = new OleDbCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(oleDbParameters);
                dataAdapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Hata Kodu: " + e.ErrorCode);
                Console.WriteLine("Hata Mesajı: " + e.Message);
                Console.WriteLine("Hata Stack Trace: " + e.StackTrace);
                foreach (OleDbError error in e.Errors)
                {
                    Console.WriteLine("Hata: " + error.Message);
                }
                return false;
            }
            finally
            {
                baglanti.Close();
            }
            return true;
        }
    }
}