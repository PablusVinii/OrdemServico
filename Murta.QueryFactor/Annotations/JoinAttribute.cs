using Murta.QueryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactor.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class JoinAttribute:Attribute
    {
        public string TypeJoin { get; set; }
        public string TableA { get; set; }
        public string FieldA { get; set; }
        public string TableB { get; set; }
        public string FieldB { get; set; }
    }

    public class JoinAttributeCollector : PropertyAttributeCollector
    {
        public static List<JoinAttribute> GetValues<T>(T obj)
        {
            List<object> objectList = GetValues<T, JoinAttribute>(obj);
            List<JoinAttribute> joins = new List<JoinAttribute>();

            foreach (var item in objectList)
                joins.Add((JoinAttribute)item);

            return joins;
        }
    }    
}
