namespace OpenCover.Tests
{
    using System;
    using BestPractices.AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterYearProviderTest
    {
        [Fact]
        public void Given_DateIsIn2016Year_When_GetYear_Then_Return2016()
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
    }
}
