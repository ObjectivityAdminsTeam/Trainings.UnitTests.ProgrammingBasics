namespace BestPractices.Tests.A_Consistent.Correct
{
    using System;
    using AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterTimeOfDayProviderTest
    {
        [Fact]
        public void Given_HourIs11_When_CheckTimeOfDay_Then_Morning()
        {
            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(2016, 5, 10, 11, 5, 13));
            var provider = new BetterTimeOfDayProvider(dateTimeProviderMock.Object);

            // Act
            var timeOfDay = provider.TimeOfDay;

            // Assert
            Assert.Equal(TimeOfDay.Morning, timeOfDay);
        }
    }
}
