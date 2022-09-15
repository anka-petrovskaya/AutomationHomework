using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class EnumHelper
    {
        public static string GetDescr(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description;
        }
    }
}