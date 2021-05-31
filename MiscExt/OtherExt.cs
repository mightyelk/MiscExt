using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections
{
    public static class OtherExt
    {

        /// <summary>
        /// Returns if List<T> contains any of the searched items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="search">items to look for</param>
        /// <returns></returns>
        public static bool ContainsAny<T>(this List<T> list, T[] search)
        {
            for (int i = 0; i < search.Length; i++)
                if (list.Contains(search[i]))
                    return true;

            return false;
        }
    }
}
