namespace BestPractices.Tests.A_Consistent.Correct
{
    using System;
    using AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterYearProviderTest
    {
        [Fact]
        public void Given_DateIn2016_When_CheckingYear_Then_2016()
        {
            // Arrange
            const int ExpectedYear = 2016;
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(ExpectedYear, 10, 1));
            var provider = new BetterYearProvider(dateTimeProviderMock.Object);

            // Act
            int currentYear = provider.CurrentYear;

            // Assert
            Assert.Equal(ExpectedYear, currentYear);
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(2012)]
        [InlineData(2016)]
        [InlineData(2100)] // Failure
        public void Given_YearIsLeap_When_CheckingIfIsLeap_Then_ReturnsTrue(int leapYear)
        {
            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(leapYear, 1, 1));
            var provider = new BetterYearProvider(dateTimeProviderMock.Object);

            // Act
            bool isLeapYear = provider.IsLeap;

            // Assert
            Assert.True(isLeapYear);
        }
    }
}
