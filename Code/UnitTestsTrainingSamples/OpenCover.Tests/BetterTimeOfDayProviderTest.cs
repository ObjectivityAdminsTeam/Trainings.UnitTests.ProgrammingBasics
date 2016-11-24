namespace OpenCover.Tests
{
    using System;
    using BestPractices;
    using BestPractices.AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterTimeOfDayProviderTest
    {
        [Fact]
        public void TimeOfDay_Time11_Morning()
        {
            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(2016, 5, 10, 11, 5, 13));
            var provider = new BetterTimeOfDayProvider(dateTimeProviderMock.Object);

            // Act
            TimeOfDay timeOfDay = provider.TimeOfDay;

            // Assert
            Assert.Equal(TimeOfDay.Morning, timeOfDay);
        }
    }
}
