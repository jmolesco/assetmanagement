using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AM.Core.Helper.Extensions
{
    public static class EnumExtension
    {

        public static List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                values.Add(new EnumValue()
                {
                    Name    = GetName(Enum.GetName(typeof(T), itemType)),
                    Value   = (int)itemType
                });
            }
            return values;
        }

        public static string GetName(string name)
        {
            if (name.HasValue() == true)
            {
                var regex = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);


                return regex.Replace(name, " ");
            }

            return null;
        }

        public class EnumValue
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

    }
}
