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
                if (diff.TotalSeconds < 120)
                {
                    return "1 minute ago";
                }

                // Less than 1 hour ago
                if (diff.TotalSeconds < 3600)
                {
                    return $"{Math.Floor(diff.TotalSeconds / 60)} minutes ago";
                }

                // Less than 2 hours ago
                if (diff.TotalSeconds < 7200)
                {
                    return "1 hour ago";
                }

                // Any other number of hours (up to 24 hours ago, but will always be within the current day)
                if (diff.TotalSeconds < 86400)
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

            // Within this week
            //var weekStart = now.StartOfWeek();
            //if (weekStart.Subtract(dateTime).Days < 7)
            //{
            //    return "";
            //}

            // Last week


            // Within the current month

            // Last month


            // Within the current year

            // Last year


            // x number of years



            // Failsafe
            return dateTime.ToString(CultureInfo.InvariantCulture);
        }
    }
}
