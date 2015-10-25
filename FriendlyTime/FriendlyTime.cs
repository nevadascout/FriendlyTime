namespace FriendlyTime
{
    using System;
    using System.Globalization;

    public static class FriendlyTime
    {
        /// <summary>
        /// Converts a datetime object into a human readable format such as "1 hour ago", "Yesterday", etc
        /// </summary>
        public static string ToFriendlyDateTime(this DateTime dateTime)
        {
            var now = DateTime.Now;

            // Work out difference
            var diff = now.Subtract(dateTime);

            // Are we in the same day?
            if (dateTime.Date == DateTime.Today)
            {
                // Less than one minute ago
                if (diff.TotalSeconds < 60)
                {
                    return "Just now";
                }

                // Less than 2 minutes ago
                if (diff.TotalMinutes < 2)
                {
                    return "1 minute ago";
                }

                // Less than 1 hour ago
                if (diff.TotalHours < 1)
                {
                    return $"{Math.Floor(diff.TotalSeconds / 60)} minutes ago";
                }

                // Less than 2 hours ago
                if (diff.TotalHours < 2)
                {
                    return "1 hour ago";
                }

                // Any other number of hours (up to 24 hours ago, but will always be within the current day)
                if (diff.TotalHours < 24)
                {
                    return $"{Math.Floor(diff.TotalSeconds / 3600)} hours ago";
                }
            }

            // Is it yesterday?
            if (dateTime.Date == DateTime.Today.AddDays(-1))
            {
                return "Yesterday";
            }

            // Otherwise, it's days, weeks, months or years
            var currentWeekStart = now.StartOfWeek();
            var lastWeekStart = currentWeekStart.AddDays(-7);

            // Within this week
            if (dateTime >= currentWeekStart && dateTime < now)
            {
                var weekDiff = dateTime.Subtract(currentWeekStart);

                if (weekDiff.Days < 7)
                {
                    return $"{weekDiff.Days} days ago";
                }
            }

            // Last week
            if (dateTime >= lastWeekStart && dateTime < currentWeekStart)
            {
                return "Last week";
            }
            
            // Within the current month
            if (dateTime.Month == now.Month && dateTime.Year == now.Year)
            {
                return $"{Math.Ceiling(diff.TotalDays / 7)} weeks ago";
            }

            // Last month
            if (dateTime.Month == now.AddMonths(-1).Month && dateTime.Year == now.Year)
            {
                return "Last month";
            }
            
            // Within the current year
            if (dateTime.Year == now.Year && dateTime < now)
            {
                if (dateTime.Month <= now.Month)
                {
                    var monthDiff = now.Month - dateTime.Month;

                    return $"{monthDiff} months ago";
                }
            }

            // Last year
            if (dateTime.Year == now.AddYears(-1).Year)
            {
                return "Last year";
            }


            // TODO -- x number of years



            // Failsafe
            return dateTime.ToLongDateString();
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt)
        {
            var diff = dt.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}
