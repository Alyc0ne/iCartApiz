using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace System
{
    public class SystemDateTime
    {
        public static DateTime Now
        {
            get
            {
                DateTime MyTime = DateTime.Now;
                DateTime AsiaTimeZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(MyTime, "SE Asia Standard Time");
                return AsiaTimeZone;
            }
        }
    }

    public static partial class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt, bool LastWeek = false)
        {
            if (!LastWeek)
            {
                var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
                if (diff < 0)
                    diff += 7;
                return dt.AddDays(-diff).Date;
            }
            else
            {
                var NumWeek = GetIso8601WeekOfYear(dt);
                return FirstDateOfWeekByNumWeek(dt.Year, NumWeek, CultureInfo.CurrentCulture);
            }
        }

        public static DateTime LastDayOfWeek(this DateTime dt, bool LastWeek = false)
        {
            if (!LastWeek)
            {
                return dt.FirstDayOfWeek().AddDays(6);
            }
            else
            {
                return dt.FirstDayOfWeek(true).AddDays(6);
            }
        }

        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfBeforeMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(-1);
        }

        public static DateTime LastDayOfBeforeMonth(this DateTime dt)
        {
            //var last = month.AddDays(-1);
            return dt.FirstDayOfMonth().AddDays(-1);
        }

        public static DateTime FirstDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1);
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeekByNumWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
    }
}