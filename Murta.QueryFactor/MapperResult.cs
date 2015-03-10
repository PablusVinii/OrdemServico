using Murta.QueryFactory.Annotations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory.Dapper
{
    public static class MapperResult
    {
        public static IEnumerable<T> Mapper<T>(this IEnumerable<dynamic> result)
        {
            foreach (IDictionary<string, object> row in result)
            {
                var obj = Utils.GetGenericInstance<T>();
                var properties = obj.GetType().GetProperties();
                int indexProperty = 0;
                var setupedRows = SetupDictionary(row, (object)obj, ref indexProperty);

                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttribute<ColumnAttribute>();
                    ColumnAttribute annotation = (ColumnAttribute)attribute;
                    object value = new object();

                    if (annotation.IsObject)
                    {
                        var propertyObjectInstancce = (object)property.GetValue(obj, null);
                        var sonProperties = propertyObjectInstancce.GetType().GetProperties();

                        foreach (var sonProperty in sonProperties)
                        {
                            value = GetPropertyValue(sonProperty, setupedRows);
                            sonProperty.SetValue(propertyObjectInstancce, value);
                        }
                    }
                    else
                    {
                        value = GetPropertyValue(property, setupedRows);
                        property.SetValue(obj, value);
                    }

                }

                yield return obj;
            }
        }

        private static IDictionary<string, object> SetupDictionary(IDictionary<string, object> row, object obj, ref int index)
        {
            dynamic rowCustomizedKeys = new ExpandoObject();
            List<KeyValuePair<string, object>> list = row.ToList();
            var properties = obj.GetType().GetProperties();
            var tableName = obj.GetType().GetCustomAttribute<TableAttribute>();

            for (int i = 0; i < properties.Length; i++)
            {
                var attribute = properties[i].GetCustomAttribute<ColumnAttribute>();
                if (!attribute.IsObject)
                {
                    ((IDictionary<string, object>)rowCustomizedKeys).Add(tableName.NameTable + "_" + attribute.NameColumn, list[index].Value);
                    index++;
                }
                else
                {
                    var propertyObjectInstancce = (object)properties[i].GetValue(obj, null);
                    foreach (var recursiveResult in SetupDictionary(row, propertyObjectInstancce, ref index))
                    {
                        if (!((IDictionary<string, object>)rowCustomizedKeys).ContainsKey(recursiveResult.Key))
                        {
                            ((IDictionary<string, object>)rowCustomizedKeys).Add(recursiveResult);
                        }
                    }
                }
            }

            return (IDictionary<string, object>)rowCustomizedKeys;
        }

        private static object GetPropertyValue(PropertyInfo property, IDictionary<string, object> row)
        {
            var attribute = property.GetCustomAttribute<ColumnAttribute>();
            string nameReflectedType = property.ReflectedType.GetCustomAttribute<TableAttribute>().NameTable;
            var columnName = attribute.NameColumn;
            var key = nameReflectedType + "_" + columnName;
            return row[key];
        }
    }
}
