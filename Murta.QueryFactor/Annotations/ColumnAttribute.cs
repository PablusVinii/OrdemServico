using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public string NameColumn { get; set; }
        public bool IsObject { get; set; }
        public bool IsSerial { get; set; }
        public bool IsForeignKey { get; set; }
        public string ForeignKeyName { get; set; }
        public bool IsUsedInsertOrUpdateOperation { get; set; }
        public Type Type { get; set; }
        public string NameObjectProperty { get; set; }        
    }

    public class ColumnAttributeCollector : PropertyAttributeCollector
    {
        public static List<ColumnAttribute> GetValues<T>(T obj)
        {
            List<object> objectList = GetValues<T, ColumnAttribute>(obj);
            List<ColumnAttribute> columns = new List<ColumnAttribute>();

            foreach (var item in objectList)
            {
                if (!((ColumnAttribute)item).IsObject)
                {
                    columns.Add((ColumnAttribute)item);   
                }
                else
                {
                    var type = ((ColumnAttribute)item).Type;

                    var sonObject = obj.GetType().GetProperty(((ColumnAttribute)item).NameObjectProperty);

                    var propertyObjectInstancce = (object)sonObject.GetValue(obj, null);

                    var tableName = propertyObjectInstancce.GetType().GetCustomAttribute<TableAttribute>();

                    var sonObjectCollumns = typeof(ColumnAttributeCollector)
                                 .GetMethod("GetValues")
                                 .MakeGenericMethod(type)
                                 .Invoke(new ColumnAttributeCollector(), new object[] { propertyObjectInstancce });

                    foreach (var soc in (IEnumerable<ColumnAttribute>)sonObjectCollumns)
                    {
                        if (soc.NameColumn.IndexOf(".") == -1)                        
                            soc.NameColumn = tableName.NameTable + "." + soc.NameColumn;

                        columns.Add(soc);
                    }
                }
            }

            return columns;
        }
    }
}
