using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioViewer.Model
{
    public static class ExtensionMethods
    {
        public static bool NotYetImplemented<T>(this T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return true;
            
            return typeof(T).GetField(value.ToString()).IsDefined(typeof(NYIAttribute), false);
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
