using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MightyElk.MiscExt
{
    public static class ICollectionExt
    {
        public static T AddAndReturn<T>(this ICollection<T> list, T item)
        {
            list.Add(item);
            return item;
        }
    }
}
