using System;

namespace CommonExtensionMethods
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// DateTime extension to determine if the extended date time is between a certain time.
        /// </summary>
        /// <param name="input">The DateTime to compare against.</param>
        /// <param name="rangeBeginning">The DateTime that the range begins.</param>
        /// <param name="rangeEnding">The DateTime that the range ends.</param>
        /// <returns cref="bool">True - input is between the range, False - input is not between the range.</returns>
        public static bool Between(this DateTime input, DateTime rangeBeginning, DateTime rangeEnding)
        {
            return input.Ticks >= rangeBeginning.Ticks && input.Ticks <= rangeEnding.Ticks;
        }

        /// <summary>
        /// DateTime extension to determine if the extended date time is a working day.
        /// A standard work week is a week that does not include Saturday or Sunday.
        /// </summary>
        /// <param name="input">The DateTime to compare against</param>
        /// <returns cref="bool">True if the day falls on the weekday, false if it falls on the weekend.</returns>
        public static bool IsWorkingDay(this DateTime input)
        {
            return input.DayOfWeek != DayOfWeek.Saturday && input.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// DateTime extension to determine if the extended date time is a weekend.
        /// </summary>
        /// <param name="input">The DateTime to compare against</param>
        /// <returns cref="bool">True - the DateTime falls on a weekend, False - the DateTime falls during the week.</returns>
        public static bool IsWeekend(this DateTime input)
        {
            return input.DayOfWeek == DayOfWeek.Saturday || input.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Readable times for users
        /// This is used when exact time isn't necessary
        /// </summary>
        /// <param name="input">The DateTime to compare against</param>
        /// <returns cref="string">time ago in a readable format.</returns>
        public static string ToReadableTime(this DateTime input)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - input.Ticks);
            double delta = ts.TotalSeconds;
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}