using System;
using System.ComponentModel;
using System.Reflection;

namespace BlazorBJ.Client.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum en)
        {
            if (en == null)
            {
                return "<none selected>";
            }

            try
            {
                var field = en.GetType().GetField(en.ToString());
                if (field == null)
                {
                    return en.ToString();
                }

                var attributes = (DisplayNameAttribute[])field.GetCustomAttributes(typeof(DisplayNameAttribute), false);

                if (attributes.Length > 0)
                {
                    return attributes[0].DisplayName;
                }
                else
                {
                    return en.ToString();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return en.ToString();
            }
        }

        public static string GetDisplayDescription(this Enum en)
        {
            if (en == null)
                return "<none selected>";

            try
            {
                FieldInfo field = en.GetType().GetField(en.ToString());

                if (field == null)
                    return en.ToString();

                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return en.ToString();
            }
            catch
            {
                return en.ToString();
            }
        }
    }
}