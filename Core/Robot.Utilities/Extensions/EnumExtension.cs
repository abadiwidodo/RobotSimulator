using System;
using System.Linq;

namespace Robot.Utilities.Extensions
{
    public static class EnumExtension
    {
        public static bool IsValidEnum<TEnum>(this string value) where TEnum : struct
        {
            return Enum.GetNames(typeof(TEnum)).Any(x => String.Equals(x, value, StringComparison.CurrentCultureIgnoreCase));
        }

        public static T ToEnum<T>(this string value) where T : struct
        {
            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : default(T);
        }

        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }

        public static bool TryParse<TEnum>(Object value, ref TEnum returnValue) where TEnum : struct
        {
            if (!typeof(TEnum).IsSubclassOf(typeof(Enum)))
            {
                throw new ArgumentException("TEnum must be an enumeration type.");
            }

            try
            {
                TEnum parsedValued = (TEnum)Enum.Parse(typeof(TEnum), value.ToString(), true);
                if (Enum.IsDefined(typeof(TEnum), parsedValued))
                {
                    returnValue = parsedValued;
                    return true;
                }
            }
            catch { }

            return false;
        }
    }
}
