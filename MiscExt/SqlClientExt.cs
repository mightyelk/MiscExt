using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.SqlClient
{
    public static class DBExt
    {
        /// <summary>
        /// Returns the value or default for the type if value is dbnull
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static T GetOrDefault<T>(this SqlDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);

            object value = reader[ordinal];

            if (value is T)
            {
                return (T)value;
            }

            return default(T);
        }

    }
}
