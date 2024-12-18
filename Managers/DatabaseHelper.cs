using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class DatabaseHelper
    {
        private string connectionstring;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;

        private bool disposedValue = false;

        public DatabaseHelper(string connectionstring)
        {
            connectionstring = ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString;
            conn = new SqlConnection(connectionstring);
            cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
        }

        public void Open()
        {
            conn.Open();
        }
        public void Close()
        {
            conn.Close();
        }

        // Insert , Delete , Update
        // Return Number of Rows Affected
        //  Connected Mode
        public int ExecuteNonQuery(string storedprocedure, Dictionary<string, object> _param = null)
        {
            try
            {
                // تأكد من فتح الاتصال قبل التنفيذ
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.CommandText = storedprocedure;
                cmd.Parameters.Clear();

                if (_param != null && _param.Count > 0)
                {
                    foreach (KeyValuePair<string, object> kvp in _param)
                    {
                        SqlParameter parameter = new SqlParameter
                        {
                            ParameterName = kvp.Key,
                            Value = kvp.Value
                        };
                        cmd.Parameters.Add(parameter);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // التعامل مع الخطأ
                Console.WriteLine("An error occurred: " + ex.Message);
                return 0;
            }
            finally
            {
                // غلق الاتصال بعد الانتهاء من التنفيذ
                conn.Close();
            }
        }


        // Select Only
        // Return Table of Columns and Rows
        //  Disconnected Mode
        public DataSet ExecuteQuery(string storedprocedure, Dictionary<string, object> _param = null)
        {
            DataSet d = new DataSet();
            cmd.CommandText = storedprocedure;
            cmd.Parameters.Clear();
            if (_param != null && _param.Count > 0)
            {
                foreach (KeyValuePair<string, object> kvp in _param)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = kvp.Key;
                    parameter.Value = kvp.Value;
                    cmd.Parameters.Add(parameter);

                }

            }
            adapter.Fill(d);
            return d;


        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (conn != null)
                    {
                        Close();
                        conn.Dispose();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DatabaseHelper()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
