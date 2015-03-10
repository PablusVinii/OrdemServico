using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.QueryFactory
{
    internal static class Utils
    {
        public static T GetGenericInstance<T>()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            return obj;
        }

        public static bool HasLowerCase(string str)
        {
            return !string.IsNullOrEmpty(str) && str.Any(c => char.IsLower(c));
        }
    }
}
