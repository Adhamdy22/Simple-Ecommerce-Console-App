using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Managers
{
    public static class Mapper
    {
        public static IEnumerable<T> Map<T>(this DataTable table) where T : class,new ()
        {
            for(int i=0;i<table.Rows.Count;i++)
            {
                T obj=new T();
                PropertyInfo [] info=obj.GetType().GetProperties();
                foreach(PropertyInfo pi in info)
                {
                    pi.SetValue(obj, table.Rows[i][pi.Name]);
                }
            }

            return null;
        }

        public static IEnumerable<T> MapWithAutoMapper<T>(this DataTable table, IMapper mapper) where T : class, new()
        {
            List<T> result = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                // Map the DataRow to an instance of T
                T obj = mapper.Map<T>(row);
                result.Add(obj);
            }

            return result;
        }







    }
}
