namespace FriendlyTime.Test
{
    using System;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class HappyPath
    {
        [TestMethod]
        public void JustNow()
        {
            var dateTime = DateTime.Now;
            
            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Just now");
        }

        [TestMethod]
        public void LessThanOneMinuteAgo()
        {
            var dateTime = DateTime.Now.AddSeconds(-30);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Just now");
        }

        [TestMethod]
        public void LessThanTwoMinutesAgo()
        {
            var dateTime = DateTime.Now.AddMinutes(-1);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("1 minute ago");
        }

        [TestMethod]
        public void LessThanOneHourAgo()
        {
            var dateTime = DateTime.Now.AddMinutes(-3);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("3 minutes ago");
        }

        [TestMethod]
        public void LessThanTwoHoursAgo()
        {
            var dateTime = DateTime.Now.AddHours(-1);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("1 hour ago");
        }

        [TestMethod]
        public void LessThanOneDayAgo()
        {
            var dateTime = DateTime.Now.AddHours(-5);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("5 hours ago");
        }

        [TestMethod]
        public void Yesterday()
        {
            var dateTime = DateTime.Now.AddDays(-1);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Yesterday");
        }

        [TestMethod]
        public void WithinTheCurrentWeek()
        {
            var dateTime = DateTime.Now.AddDays(-3);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("3 days ago");
        }

        [TestMethod]
        public void LastWeek()
        {
            var dateTime = DateTime.Now.AddDays(-7);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Last week");
        }

        [TestMethod]
        public void WithinTheCurrentMonth()
        {
            var dateTime = DateTime.Now.AddDays(-14);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("2 weeks ago");
        }

        [TestMethod]
        public void WithinTheLastMonth()
        {
            var dateTime = DateTime.Now.AddDays(-30);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Last month");
        }

        [TestMethod]
        public void WithinTheCurrentYear()
        {
            var dateTime1 = DateTime.Now.AddMonths(-6);

            var result1 = dateTime1.ToFriendlyDateTime();

            result1.Should().Be("6 months ago");
        }

        [TestMethod]
        public void WithinTheLastYear()
        {
            var dateTime = DateTime.Now.AddYears(-1);

            var result = dateTime.ToFriendlyDateTime();

            result.Should().Be("Last year");
        }
    }
}
