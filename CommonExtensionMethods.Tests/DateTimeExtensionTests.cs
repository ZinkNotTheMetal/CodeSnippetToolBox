using System;
using NUnit.Framework;

namespace CommonExtensionMethods.Tests
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        #region ReadableTime Tests

        [Test]
        public void ReadableTime_WhenNow_Should0SecondsAgo()
        {
            DateTime test = DateTime.UtcNow;
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("0 seconds ago"));
        }

        [Test]
        public void ReadableTime_WhenOneSecondAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddSeconds(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("one second ago"));
        }

        [Test]
        public void ReadableTime_WhenTenSecondsAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddSeconds(-10);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("10 seconds ago"));
        }

        [Test]
        public void ReadableTime_WhenOneMinuteAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddMinutes(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("a minute ago"));
        }

        [Test]
        public void ReadableTime_WhenFiveMinutesAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddMinutes(-5);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("5 minutes ago"));
        }

        [Test]
        public void ReadableTime_WhenOneHourAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddHours(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("an hour ago"));
        }

        [Test]
        public void ReadableTime_WhenFifteenHoursAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddHours(-15);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("15 hours ago"));
        }

        [Test]
        public void ReadableTime_WhenYesterday_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddDays(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("yesterday"));
        }

        [Test]
        public void ReadableTime_WhenTwelveDaysAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddDays(-12);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("12 days ago"));
        }

        [Test]
        public void ReadableTime_WhenOneMonthAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddMonths(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("one month ago"));
        }

        [Test]
        public void ReadableTime_WhenFourMonthsAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddMonths(-4);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("4 months ago"));
        }

        [Test]
        public void ReadableTime_WhenOneYearAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddYears(-1);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("one year ago"));
        }

        [Test]
        public void ReadableTime_WhenTwentyYearsAgo_ShouldNotBlowUpWithNullableDateTime()
        {
            DateTime test = DateTime.UtcNow.AddYears(-20);
            var result = test.ToReadableTime();

            Assert.That(result, Is.EqualTo("20 years ago"));
        }

        #endregion

        #region DateTime Between Tests

        [Test]
        public void Between_ShouldReturnFalse_WhenInputIsNotBetweenCertainDates()
        {
            var test = DateTime.MinValue;

            var isWithinLastMinute = test.Between(DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow);
            Assert.That(isWithinLastMinute, Is.False);
        }

        [Test]
        public void Between_ShouldReturnTrue_WhenInputIsBetweenCertainDates()
        {
            var test = DateTime.Now;

            var isWithinLastMinute = test.Between(DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow);
            Assert.That(isWithinLastMinute, Is.True);
        }

        #endregion

        #region IsWorkingDay Tests

        [Test]
        public void IsWorkingDay_WhenWeekday_ShouldReturnTrue()
        {
            var testDate = DateTime.Parse("04-21-2016"); //Thursday
            Assert.That(testDate.IsWorkingDay(), Is.True);
        }

        [Test]
        public void IsWorkingDay_WhenWeekend_ShouldReturnFalse()
        {
            var testDate = DateTime.Parse("04-23-2016"); //Saturday
            Assert.That(testDate.IsWorkingDay(), Is.False);
        }

        #endregion

        #region IsWeekend Tests

        [Test]
        public void IsWeekend_WhenWeekend_ShouldReturnTrue()
        {
            var testDate = DateTime.Parse("04-23-2016"); //Saturday
            Assert.That(testDate.IsWeekend(), Is.True);
        }

        [Test]
        public void IsWeekend_WhenWeekday_ShouldReturnFalse()
        {
            var testDate = DateTime.Parse("04-21-2016"); //Saturday
            Assert.That(testDate.IsWeekend(), Is.False);
        }

        #endregion
    }
}
