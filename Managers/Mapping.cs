using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class Mapping<T>:Profile
    {
        
            public Mapping()
            {
                CreateMap<DataRow, T>()
                    .ConstructUsing(row => Activator.CreateInstance<T>())
                    .AfterMap((row, dest) => MapDataRowToObject(row, dest));
            }
            private void MapDataRowToObject(DataRow row, T dest)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (row.Table.Columns.Contains(prop.Name))
                    {
                        var value = row[prop.Name];
                        if (value != DBNull.Value)
                        {
                            prop.SetValue(dest, Convert.ChangeType(value, prop.PropertyType));
                        }
                    }
                }
            }
        }
    }

