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
    }
}
