using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MightyElk.MiscExt
{
    public static class DateExt
    {
        /// <summary>
        /// Returns the week of the year.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetWeek(this DateTime date)
        {
            CultureInfo ci = new CultureInfo("de-de");
            Calendar cal = ci.Calendar;
            CalendarWeekRule cwr = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDow = ci.DateTimeFormat.FirstDayOfWeek;

            return cal.GetWeekOfYear(date, cwr, firstDow);
            
        }


    }
}
