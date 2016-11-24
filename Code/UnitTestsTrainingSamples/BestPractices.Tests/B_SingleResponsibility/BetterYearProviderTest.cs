namespace BestPractices.Tests.B_SingleResponsibility
{
    using System;
    using AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterYearProviderTest
    {
        private const int ExpectedYear = 2016;
        private readonly BetterYearProvider yearProvider;

        // In xUnit ctor can setup 
        public BetterYearProviderTest()
        {
            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(ExpectedYear, 5, 10, 11, 5, 13));
            this.yearProvider = new BetterYearProvider(dateTimeProviderMock.Object);
        }

        // Now it is clear whe test has failed - ONE ASSERT PER TEST
        [Fact]
        public void Given_DateIn2016_When_CheckYear_Then_YearMustBe2016()
        {
            // Act & assert
            Assert.Equal(ExpectedYear, this.yearProvider.CurrentYear);
        }

        [Fact]
        public void Given_DateIn2016_When_CheckNextYear_Then_YearMustBe2017()
        {
            // Act & assert
            Assert.Equal(ExpectedYear + 1, this.yearProvider.NextYear);
        }

    }
}
