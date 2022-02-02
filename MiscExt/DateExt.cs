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


        /// <summary>
        /// Checks wether the time part of a datetime is in a period defined by two timespans.
        /// </summary>
        /// <param name=""></param>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <returns></returns>
        public static bool IsTimeBetween(this DateTime dt, TimeSpan timeFrom, TimeSpan timeTo)
        {
            long fromTicks = timeFrom.Ticks;
            long toTicks = timeTo.Ticks;
            long checkTicks = dt.TimeOfDay.Ticks;


            //is the span going over midnight?
            bool overflow = timeFrom > timeTo;

            if (overflow)
                fromTicks -= TimeSpan.FromDays(1).Ticks;

            



            //too late
            if (checkTicks > toTicks)
                return false;

            //too soon
            if (checkTicks < fromTicks)
                return false;


            return true;



        }

    }
}
