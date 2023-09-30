using System.Globalization;

namespace Entities.Utilities;

public static class DateTimeExt
{
    public static string ToShortDate(this DateTime dateTime)
    {
        try
        {
            if (dateTime == null)
                return "";

            PersianCalendar pc = new PersianCalendar();
            string persianDate =
                $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
            return persianDate;
        }
        catch
        {
            return "";
        }
    }

    public static string ToShortTime(this DateTime dateTime)
    {
        try
        {
            if (dateTime == null)
                return "";

            PersianCalendar pc = new PersianCalendar();
            string persianDate =
                $"{pc.GetHour(dateTime)}:{pc.GetMinute(dateTime)}:{pc.GetSecond(dateTime)}";
            return persianDate;
        }
        catch
        {
            return "";
        }
    }

    public static string ToShortDateTime(this DateTime dateTime)
    {
        return ToShortDate(dateTime) + " - " + ToShortTime(dateTime);
    }

    public static DateTime EndOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
    }

    public static DateTime StartOfDay(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
    }
}