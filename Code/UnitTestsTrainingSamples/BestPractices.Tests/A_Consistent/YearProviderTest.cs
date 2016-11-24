namespace BestPractices.Tests.A_Consistent
{
    using StartPoint;
    using Xunit;

    public class YearProviderTest
    {
        [Fact]
        public void Given_CurrentDate_When_CheckYear_Then_2016_DONT_DO_THAT()
        {
            // Arrange
            const int ExpectedYear = 2016;
            var provider = new YearProvider();

            // Act
            int currentYear = provider.CurrentYear;

            // Assert
            Assert.Equal(ExpectedYear, currentYear);
        }
    }
}
