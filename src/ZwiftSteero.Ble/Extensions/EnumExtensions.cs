using System;
using System.Collections.Generic;

namespace ZwiftSteero.Ble.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetUniqueFlags<T>(this T flags) where T : Enum 
        {
            foreach (Enum value in Enum.GetValues(flags.GetType()))
            {
                if (flags.HasFlag(value))
                {
                    yield return (T)value;
                }
            }
        }
    }
}
