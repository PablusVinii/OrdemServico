using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory
{
    public abstract class PropertyAttributeCollector
    {
        public static List<object> GetValues<T1,T2>(T1 obj)
        {
            var values = new List<object>();
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                values.AddRange(property.GetCustomAttributes(typeof(T2), true));
            }

            return values;
        }
    }
}
