namespace xUnitQuickStart.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    [Collection("Simple Calculator")]
    [Trait("Category", "Simple Calculator")]
    public class SimpleCalculatorTest
    {
        [Fact(DisplayName = "0 as left sum argument will not change result")]
        [Trait("Feature", "Addition")]
        public void Given_0AsLeftNeutralElement_When_Addition_Then_ResultIsValueOfOtherNumber()
        {
            // Arrange
            const int NonNeutralNumber = 10;
            var calculator = new SimpleCalculator();

            // Act
            int result = calculator.Addition(0, NonNeutralNumber);

            // Assert
            Assert.Equal(NonNeutralNumber, result);
        }

        [Fact(DisplayName = "Adding numbert which sume is bigger than Int scope will throw OverflowException")]
        [Trait("Feature", "Addition")]
        public void Given_TwoBigValuesThatSumIsBiggerThanInt_When_Addition_Then_OverflowException()
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act & assert
            Assert.Throws<OverflowException>(() => calculator.Addition(int.MaxValue - 1, 10));
        }

        [Fact(Skip = "This test is skipped right now.", DisplayName = "0 as right sum argument will not change result")]
        [Trait("Feature", "Addition")]
        public void Given_0AsRightNeutralElement_When_Addition_Then_ResultIsValueOfOtherNumber()
        {
            // Arrange
            const int NonNeutralNumber = 10;
            var calculator = new SimpleCalculator();

            // Act
            int result = calculator.Addition(NonNeutralNumber, 0);

            // Assert
            Assert.Equal(NonNeutralNumber, result);
        }

        [Theory(DisplayName = "IsOdd check for provided number should be true")]
        [Trait("Feature", "IsOdd")]
        [InlineData(1)]
        [InlineData(2)] // Failure
        [InlineData(3)]
        [InlineData(5)]
        public void Given_OddNumber_When_CheckIfOf_When_Return_True(int number)
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act
            bool isOdd = calculator.IsOdd(number);

            // Assert
            Assert.True(isOdd);
        }

        [Theory(DisplayName = "Summing two numbers will provide correct result")]
        [Trait("Feature", "Addition")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 6, 9)]
        [InlineData(5, 0, 5)]
        [InlineData(0, 5, 5)]
        public void Given_TwoNumbersFromScenario_When_Addition_Then_ReturnValueSameAsInScenarion(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act
            int actualResult = calculator.Addition(a, b);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory(DisplayName = "Summing two numbers will provide correct result")]
        [Trait("Feature", "Addition")]
        [MemberData("DataForAdditionTest_NormalCases", MemberType = typeof(DataProvider))]
        public void Given_TwoNumbersFromScenario_When_Addition_Then_ReturnValueSameAsInScenarion_MemberData(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act
            int actualResult = calculator.Addition(a, b);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        private static class DataProvider
        {
            public static IEnumerable<object[]> DataForAdditionTest_NormalCases()
            {
                return new List<object[]>
                {
                    new object[] {1, 1, 2},
                    new object[] {2, 3, 5},
                    new object[] {3, 6, 9},
                    new object[] {5, 0, 5},
                    new object[] {0, 5, 5},
                };
            }
        }
    }
}