namespace FriendlyTime.Test
{
    using System;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProblemPath
    {
        [TestMethod]
        public void DayInFuture()
        {
            var date = DateTime.Now.AddDays(14);

            var result = date.ToFriendlyDateTime();

            //result.Should().Be("next week");
        }
    }
}
