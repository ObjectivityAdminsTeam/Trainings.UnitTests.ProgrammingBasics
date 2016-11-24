namespace BestPractices.Tests.C_NoConditionalLogicOrLoops
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AfterRefactoring;
    using Moq;
    using Xunit;

    public class BetterTimeOfDayProviderTest
    {
        [Fact]
        public void Given_AllHoursFromDay_When_CheckTimeOfDay_Then_CorrectResponse_DONT_DO_THAT()
        {
            var hours = Enumerable.Range(0, 23);

            foreach (var hour in hours)
            {
                // !!!!!!!!! Show what happen when there will be an error - see test result

                var dateTimeProviderMock = new Mock<IDateTimeProvider>();
                dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(2016, 5, 10, hour, 5, 13));
                var provider = new BetterTimeOfDayProvider(dateTimeProviderMock.Object);

                var timeOfDay = provider.TimeOfDay;

                TimeOfDay expectedTimeOfDay;
                switch (hour)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        expectedTimeOfDay = TimeOfDay.Night;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        expectedTimeOfDay = TimeOfDay.Morning;
                        break;
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                        expectedTimeOfDay = TimeOfDay.Afternoon;
                        break;
                    default:
                        expectedTimeOfDay = TimeOfDay.Evening;
                        break;
                }

                Assert.Equal(expectedTimeOfDay, timeOfDay);
            }
        }

        [Theory]
        [InlineData(0, TimeOfDay.Night)]
        [InlineData(1, TimeOfDay.Night)]
        [InlineData(2, TimeOfDay.Night)]
        [InlineData(3, TimeOfDay.Night)]
        [InlineData(4, TimeOfDay.Night)]
        [InlineData(5, TimeOfDay.Night)]
        [InlineData(6, TimeOfDay.Morning)]
        [InlineData(7, TimeOfDay.Morning)]
        [InlineData(8, TimeOfDay.Morning)]
        [InlineData(9, TimeOfDay.Morning)]
        [InlineData(10, TimeOfDay.Morning)]
        [InlineData(11, TimeOfDay.Morning)]
        [InlineData(12, TimeOfDay.Afternoon)]
        [InlineData(13, TimeOfDay.Afternoon)]
        [InlineData(14, TimeOfDay.Afternoon)]
        [InlineData(15, TimeOfDay.Afternoon)]
        [InlineData(16, TimeOfDay.Afternoon)]
        [InlineData(17, TimeOfDay.Afternoon)]
        [InlineData(18, TimeOfDay.Evening)]
        [InlineData(19, TimeOfDay.Evening)]
        [InlineData(20, TimeOfDay.Evening)]
        [InlineData(21, TimeOfDay.Evening)]
        [InlineData(22, TimeOfDay.Evening)]
        [InlineData(23, TimeOfDay.Evening)]

        public void Given_TimeInScenario_When_CheckTimeOfDay_Then_ResultAsInScenario(int testedHour, TimeOfDay expectedResult)
        {
            // !!!!!!!!! Show what happen when there will be an error - see test result

            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(2016, 5, 10, testedHour, 5, 13));
            var provider = new BetterTimeOfDayProvider(dateTimeProviderMock.Object);

            // Act
            var timeOfDay = provider.TimeOfDay;

            // Assert
            Assert.Equal(expectedResult, timeOfDay);
        }

        // Set up can be done in better way
        [Theory]
        [MemberData("TimeOfDayTestScenarios")]
        public void Given_TimeInScenario_When_CheckTimeOfDay_Then_ResultAsInScenario_v2(int testedHour, TimeOfDay expectedResult)
        {
            // !!!!!!!!! Show what happen when there will be an error - see test result

            // Arrange
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();
            dateTimeProviderMock.Setup(x => x.Now).Returns(new DateTime(2016, 5, 10, testedHour, 5, 13));
            var provider = new BetterTimeOfDayProvider(dateTimeProviderMock.Object);

            // Act
            var timeOfDay = provider.TimeOfDay;

            // Assert
            Assert.Equal(expectedResult, timeOfDay);
        }

        public static IEnumerable<object[]> TimeOfDayTestScenarios
        {
            get
            {
                return new List<IEnumerable<object[]>>
                {
                    Enumerable.Range(0, 6).Select(x => new object[] {x, TimeOfDay.Night}),
                    Enumerable.Range(6, 6).Select(x => new object[] {x, TimeOfDay.Morning}),
                    Enumerable.Range(12, 6).Select(x => new object[] {x, TimeOfDay.Afternoon}),
                    Enumerable.Range(18, 6).Select(x => new object[] {x, TimeOfDay.Evening}),
                }.SelectMany(x => x);

            }
        }
    }
}