using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory.Annotations
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class WhereClauseAttribute: Attribute
    {
        public string NameColumn { get; set; }
        public int ID { get; set; }
    }

    public class WhereClauseAttributeCollector : PropertyAttributeCollector
    {
        public static List<WhereClauseAttribute> GetValues<T>(T obj)
        {
            List<object> objectList = GetValues<T, WhereClauseAttribute>(obj);
            List<WhereClauseAttribute> clauses = new List<WhereClauseAttribute>();

            foreach (var item in objectList)	      
		        clauses.Add((WhereClauseAttribute)item);

            clauses.OrderBy(x => x.ID);
            return clauses;
        }
    }
}
