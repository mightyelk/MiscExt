using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MightyElk.MiscExt
{
    public static class TimeSpanExt
    {
        public static string ToHumanReadable(this TimeSpan ts)
        {
            StringBuilder sb = new StringBuilder();
            if (ts.Days == 1)
                sb.Append($"{ts.Days} day,");
            else if (ts.Days > 1)
                sb.Append($"{ts.Days} days,");

            if (ts.Hours == 1)
                sb.Append($"{ts.Hours} hour,");
            else if (ts.Hours > 1)
                sb.Append($"{ts.Hours} hours,");

            if (ts.Minutes == 1)
                sb.Append($"{ts.Minutes} minute,");
            else if (ts.Minutes > 1)
                sb.Append($"{ts.Minutes} minutes,");

            if (ts.Seconds == 1)
                sb.Append($"{ts.Seconds} second,");
            else if (ts.Seconds > 1)
                sb.Append($"{ts.Seconds} seconds,");

            if (sb.Length > 1)
                sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }


        /// <summary>
        /// returns a TimeSpan divided by divisor, smallest timepart is seconds which get not divided.
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="divisor">divide by this</param>
        /// <returns></returns>
        public static TimeSpan DivideBy(this TimeSpan ts, int divisor)
        {
            var ret = new TimeSpan(
                ts.Days / divisor,
                ts.Hours / divisor,
                ts.Minutes / divisor,
                ts.Seconds
                );
            return ret;

        }
    }
}
