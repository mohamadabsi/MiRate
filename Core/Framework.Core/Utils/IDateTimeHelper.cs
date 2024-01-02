// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeHelper.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework.Core.Utils
{
    public interface IDateTimeHelper
    {
        DateTime CurrentDate { get; }
        string CurrentDateString { get; }
        string[] DaysInArabic { get; }
        string GetGregoreanDateString(DateTime date, string dateFormat = "dd/MM/yyyy");
        string CalculateAge(DateTime dateOfBirth, out int years);
        double CalculateDateRangesTotalYears(List<DateRange> ranges);
        DateTime? ChangeUmAlQuraDate(DateTime hijri, int? plusDays, int? subtractDays, string format = null);
        double GetAverageMonthDifference(DateTime startDate, DateTime endDate);
        DateTime GetCurrentUmAlQuraDate();
        string GetCurrentUmAlQuraDateString(string dateFormat = "dd/MM/yyyy");
        List<DateTime> GetDateRange(DateTime date1, DateTime date2, List<DateTime> exceptionDays = null);
        int GetMonthDifference(DateTime startDate, DateTime endDate);
        string[] GetMonthNames(Calendar calendar);
        string[] GetMonthNames(Calendar calendar, CultureInfo culture);
        string[] GetMonthsNumbers();
        List<TimeSpan> GetTimeRange(TimeSpan time1, TimeSpan time2, int minutesPerHour = 30);
        DateTime GetUmAlQuraDate(DateTime date);
        string GetUmAlQuraDateString(DateTime date, string dateFormat = "dd/MM/yyyy");
        string GetUmmAlquraMonthName(int month);
        List<string> GetYearsRange(int min, int max);
        string GregToHijri(string greg, string format);
        string HijriToGreg(string hijri, string format);
        DateTime? HijriToGregDate(string hijri, string format);
        bool IsGregorian(string gregStr, string dateFormat = null);
        bool IsUmAlqura(string hijriDateStr, string dateFormat = null);
        DateTime Max(DateTime date1, DateTime date2);
        TimeSpan Max(TimeSpan time1, TimeSpan time2);
        DateTime Min(DateTime date1, DateTime date2);
        TimeSpan Min(TimeSpan time1, TimeSpan time2);
        DateTime? ParseGregorianDate(string gregStr, string dateFormat = null);
        DateTime? ParseUmAlquraDate(string hijriDateStr, string dateFormat = null);
    }
}