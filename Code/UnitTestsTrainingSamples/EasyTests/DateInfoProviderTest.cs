namespace EasyTests
{
    using System;
    using Moq;
    using Xunit;

    public class DateInfoProviderTest
    {
        [Fact]
        public void Given_DateIsIn2016Year_When_GetYear_Then_Return2016()
        {
            // Arrange
            const int ExpectedYear = 2016;
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(
               new DateTime(ExpectedYear, 10, 1));
            var provider = new DateInfoProvider(dateTimeProviderMock.Object);

            // Act
            int currentYear = provider.Year;

            // Assert
            Assert.Equal(ExpectedYear, currentYear);
        }

    }
}
