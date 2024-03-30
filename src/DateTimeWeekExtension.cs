using System.Diagnostics.Contracts;
using System.Globalization;
using System;
using Soenneker.Enums.UnitOfTime;

namespace Soenneker.Extensions.DateTime.Week;

/// <summary>
/// Provides extension methods for <see cref="System.DateTime"/> to perform operations based on week intervals.
/// </summary>
public static class DateTimeWeekExtension
{
    /// <summary>
    /// Adjusts the specified DateTime to the start of the current week.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the first moment (00:00:00) of the week of the original DateTime.</returns>
    /// <remarks>
    /// The start of the week is determined based on the system's culture settings, which typically consider Sunday or Monday as the first day of the week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfWeek(this System.DateTime datetime)
    {
        return datetime.ToStartOf(UnitOfTime.Week);
    }

    /// <summary>
    /// Adjusts the specified DateTime to the end of the current week.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the last moment (23:59:59.9999999) of the week of the original DateTime.</returns>
    /// <remarks>
    /// The end of the week is one tick before the start of the following week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToEndOfWeek(this System.DateTime datetime)
    {
        return datetime.ToEndOf(UnitOfTime.Week);
    }

    /// <summary>
    /// Adjusts the specified DateTime to the start of the next week, represented in UTC.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the first moment of the next week.</returns>
    /// <remarks>
    /// The method calculates the start of the next week without performing any timezone conversion.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfNextWeek(this System.DateTime datetime)
    {
        var result = datetime.ToStartOfWeek().AddDays(7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified DateTime to the start of the previous week.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the first moment of the previous week.</returns>
    /// <remarks>
    /// This method calculates the start of the previous week without adjusting for timezone differences.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfPreviousWeek(this System.DateTime datetime)
    {
        var result = datetime.ToStartOfWeek().AddDays(-7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified DateTime to the end of the previous week.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the last moment of the week preceding the current week.</returns>
    /// <remarks>
    /// This method subtracts 7 days from the current end of the week to find the end of the previous week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToEndOfNextWeek(this System.DateTime datetime)
    {
        var result = datetime.ToEndOfWeek().AddDays(7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified DateTime to the end of the previous week.
    /// </summary>
    /// <param name="datetime">The DateTime instance to be adjusted.</param>
    /// <returns>A new DateTime instance set to the last moment of the week preceding the current week.</returns>
    /// <remarks>
    /// This method finds the end of the current week and then subtracts 7 days to align with the end of the previous week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToEndOfPreviousWeek(this System.DateTime datetime)
    {
        var result = datetime.ToEndOfWeek().AddDays(-7);
        return result;
    }

    /// <summary>
    /// Converts the specified UTC DateTime to a specific timezone, adjusts it to the start of the current week in that timezone, and then converts it back to UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The timezone to consider for the conversion.</param>
    /// <returns>A new DateTime instance in UTC, representing the start of the current week in the specified timezone.</returns>
    /// <remarks>
    /// This method is useful for aligning dates with the beginning of the week in different timezones.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToTz(tzInfo).ToStartOfWeek().ToUtc(tzInfo);
        return result;
    }

    /// <summary>
    /// Converts the specified UTC DateTime to a specific timezone, adjusts it to the start of the next week in that timezone, and then converts it back to UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The timezone to consider for the conversion.</param>
    /// <returns>A new DateTime instance in UTC, representing the start of the next week in the specified timezone.</returns>
    /// <remarks>
    /// This method facilitates scheduling and time-based operations that require alignment with week boundaries across different timezones.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfNextTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfTzWeek(tzInfo).AddDays(7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified UTC DateTime to the start of the previous week according to a specific timezone, and represents the result in UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The timezone to consider for the adjustment.</param>
    /// <returns>A new DateTime instance in UTC, representing the start of the week preceding the current week in the specified timezone.</returns>
    /// <remarks>
    /// This method calculates the start of the previous week by subtracting 7 days from the start of the current timezone-adjusted week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToStartOfPreviousTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToStartOfTzWeek(tzInfo).AddDays(-7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified UTC DateTime to the very last moment of the current week according to a specific timezone, and represents the result in UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The timezone to consider for the adjustment.</param>
    /// <returns>A new DateTime instance in UTC, representing the last moment of the current week in the specified timezone.</returns>
    /// <remarks>
    /// This method finds the start of the next week in the specified timezone and subtracts one tick to align with the very end of the current week.
    /// </remarks>
    [Pure]
    public static System.DateTime ToEndOfTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToTz(tzInfo).ToEndOfWeek().ToUtc(tzInfo);
        return result;
    }

    /// <summary>
    /// Adjusts the specified UTC DateTime to the very last moment of the previous week according to a specific timezone, then converts it back to UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The target timezone information.</param>
    /// <returns>A DateTime instance in UTC, representing the last moment of the previous week in the specified timezone.</returns>
    [Pure]
    public static System.DateTime ToEndOfPreviousTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime result = utcNow.ToEndOfTzWeek(tzInfo).AddDays(-7);
        return result;
    }

    /// <summary>
    /// Adjusts the specified UTC DateTime to the very last moment of the next week according to a specific timezone, then converts it back to UTC.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The target timezone information.</param>
    /// <returns>A DateTime instance in UTC, representing the last moment of the next week in the specified timezone.</returns>
    [Pure]
    public static System.DateTime ToEndOfNextTzWeek(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime end = utcNow.ToEndOfTzWeek(tzInfo).AddDays(7);
        return end;
    }

    /// <summary>
    /// Converts the specified UTC DateTime to a given timezone and returns the ISO week number of that DateTime.
    /// </summary>
    /// <param name="utcNow">The current UTC DateTime.</param>
    /// <param name="tzInfo">The timezone to convert the DateTime into.</param>
    /// <returns>The ISO week number in the specified timezone.</returns>
    [Pure]
    public static int ToTzWeekNumber(this System.DateTime utcNow, System.TimeZoneInfo tzInfo)
    {
        System.DateTime eastern = utcNow.ToTz(tzInfo);
        int result = ToUtcWeekNumber(eastern);
        return result;
    }

    /// <summary>
    /// Returns the ISO week number of the specified DateTime, considered to be in UTC.
    /// </summary>
    /// <param name="dateTime">The DateTime to calculate the week number for.</param>
    /// <returns>The ISO week number for the given DateTime.</returns>
    [Pure]
    public static int ToUtcWeekNumber(this System.DateTime dateTime)
    {
        Calendar cal = CultureInfo.InvariantCulture.Calendar;
        int result = cal.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return result;
    }
}
