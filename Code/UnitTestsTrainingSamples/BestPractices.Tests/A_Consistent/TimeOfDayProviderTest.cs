namespace BestPractices.Tests.A_Consistent
{
    using StartPoint;
    using Xunit;

    public class TimeOfDayProviderTest
    {

        [Fact]
        public void Given_CurrentTime_When_CheckTimeOfDay_Then_Monsignor_DONT_DO_THAT()
        {
            // Arrange
            var provider = new TimeOfDayProvider();

            // Act
            var timeOfDay = provider.TimeOfDay;

            // Assert
            Assert.Equal(TimeOfDay.Morning, timeOfDay);
        }
    }
}
