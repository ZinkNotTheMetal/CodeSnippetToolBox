using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonExtensionMethods
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts Enumeration type into a dictionary of strings as keys and values as ints
        /// </summary>
        /// <param name="t">Enum type</param>
        /// <returns cref="Dictionary{TKey,TValue}">Enum Value is key (as string), Enum Value is value of int</returns>
        public static IDictionary<string, int> EnumToDictionary(this Type t)
        {
            if (t == null) throw new NullReferenceException();
            if (!t.IsEnum) throw new InvalidCastException("object is not an Enumeration");

            string[] names = Enum.GetNames(t);
            Array values = Enum.GetValues(t);

            return (from i in Enumerable.Range(0, names.Length)
                    select new { Key = names[i], Value = (int)values.GetValue(i) })
                        .ToDictionary(k => k.Key, k => k.Value);
        }

        /// <summary>
        /// Enumeration of all values to a list
        /// </summary>
        /// <typeparam name="T">This needs to be the type of the enumeration</typeparam>
        /// <param name="enumeration">the extended Enum</param>
        /// <example>
        /// var result = typeof(Enum).EnumToList<Enum/>();
        /// </example>
        /// <returns>List of all elements in the enumeration</returns>
        public static List<T> EnumToList<T>(this Type enumeration)
        {
            if (enumeration == null) throw new NullReferenceException();
            if (!enumeration.IsEnum) throw new InvalidCastException("object is not an Enumeration");
            if (typeof(T) != enumeration) throw new InvalidCastException("Types do not match, T and typeof(enum) must match");

            Array enumValuesArray = Enum.GetValues(enumeration);
            List<T> enumValList = new List<T>(enumValuesArray.Length);

            foreach (int val in enumValuesArray)
            {
                enumValList.Add((T)Enum.Parse(enumeration, val.ToString()));
            }

            return enumValList;
        }
    }
}
