using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class BaseManager<T> where T : class
    {
        private DatabaseHelper dbHelper;

        public BaseManager()
        {
            dbHelper= new DatabaseHelper("DB");
        }

        public virtual int Add(T obj)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                // Skip ID if it's not used in the stored procedure for add
                if (prop.Name == "ID") continue;

                // Ensure only primitive types, strings, and decimals are included
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(decimal))
                {
                    // Map property names to stored procedure parameter names if necessary
                    string parameterName = prop.Name == "CustomerID" ? "@customer_id" : "@" + prop.Name;
                    parameters.Add(parameterName, prop.GetValue(obj) ?? DBNull.Value);
                }
            }

            // Print parameters for debugging
            foreach (var param in parameters)
            {
                Console.WriteLine($"Parameter: {param.Key}, Value: {param.Value}");
            }

            dbHelper.Open();
            int rows = dbHelper.ExecuteNonQuery($"spAdd{typeof(T).Name}s", parameters);
            dbHelper.Close();
            return rows;
        }




        public virtual int Remove(int id)
        {
            dbHelper.Open();
            int rows = dbHelper.ExecuteNonQuery($"spDelete{typeof(T).Name}", new Dictionary<string, object>
            {
                {"@id", id}
            });
            dbHelper.Close();
            return rows;
        }

        public virtual int Update(int id, T obj)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            PropertyInfo[] props = obj.GetType().GetProperties();

            // Add ID parameter first
            parameters.Add("@id", id);

            foreach (PropertyInfo prop in props)
            {
                // Skip ID and customer_id if it's not updated
                if (prop.Name == "ID" || prop.Name == "CustomerID"  || prop.Name == "Address") continue;

                // Ensure only primitive types, strings, and decimals are included
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(decimal))
                {
                    // Map property names to stored procedure parameter names
                    string parameterName = "@" + prop.Name.ToLower();
                    parameters.Add(parameterName, prop.GetValue(obj) ?? DBNull.Value);
                }
            }

            // Print parameters for debugging
            foreach (var param in parameters)
            {
                Console.WriteLine($"Parameter: {param.Key}, Value: {param.Value}");
            }

            dbHelper.Open();
            int rows = dbHelper.ExecuteNonQuery($"spUpdate{typeof(T).Name}", parameters);
            dbHelper.Close();
            return rows;
        }






        public virtual T GetById(int id)
        {
            T obj = Activator.CreateInstance<T>();
            dbHelper.Open();
            DataSet ds = dbHelper.ExecuteQuery($"spGet{typeof(T).Name}ById", new Dictionary<string, object>
            {
                {"@id", id}
            });
            dbHelper.Close();

            if (ds.Tables[0].Rows.Count == 0)
                return null;  // No record found

            DataRow dataRow = ds.Tables[0].Rows[0];
            
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (dataRow.Table.Columns.Contains(prop.Name))
                {
                    prop.SetValue(obj, dataRow[prop.Name] == DBNull.Value ? null : dataRow[prop.Name]);
                }
            }

            return obj;
        }

        public virtual List<T> GetAll()
        {
            List<T> list = new List<T>();
            dbHelper.Open();
            DataSet ds = dbHelper.ExecuteQuery($"spGetAll{typeof(T).Name}s");
            dbHelper.Close();

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                T obj = Activator.CreateInstance<T>();
                PropertyInfo[] props = obj.GetType().GetProperties();

                foreach (PropertyInfo prop in props)
                {
                    if (dataRow.Table.Columns.Contains(prop.Name))
                    {
                        prop.SetValue(obj, dataRow[prop.Name] == DBNull.Value ? null : dataRow[prop.Name]);
                    }
                }
               

                list.Add(obj);
            }

            return list;
        }







    }
}
