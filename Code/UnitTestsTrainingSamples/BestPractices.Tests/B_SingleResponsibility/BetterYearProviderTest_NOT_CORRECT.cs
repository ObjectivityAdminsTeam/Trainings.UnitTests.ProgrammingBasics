namespace BestPractices.Tests.B_SingleResponsibility
{
    using System;
    using AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterYearProviderTest_NOT_CORRECT
    {
        // One or multiple asserts?
        // It is hard to get strict information what failed in this test
        [Fact]
        public void Given_DateIn2016_When_CheckYearAndNextYear_Then_2016And2017()
        {
            // Arrange
            const int ExpectedYear = 2016;
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(ExpectedYear, 5, 10, 11, 5, 13));
            var yearProvider = new BetterYearProvider(dateTimeProviderMock.Object);

            // Act
            int currentYear = yearProvider.CurrentYear;
            int nextYear = yearProvider.NextYear;

            // Assert
            Assert.Equal(ExpectedYear, currentYear);
            Assert.Equal(ExpectedYear + 1, nextYear);
        }
    }
}
