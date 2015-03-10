using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple=false)]
    public class TableAttribute:Attribute
    {
        public string NameTable { get; set; }
    }

    public static class TableAttributeManipulator
    {
        public static TableAttribute GetValue<T>(T obj)
        {
            var instance = (T)obj;
            return (TableAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(TableAttribute));
        }
    }
}
