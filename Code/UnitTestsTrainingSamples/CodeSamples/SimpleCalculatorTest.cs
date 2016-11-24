namespace CodeSamples
{
    using xUnitQuickStart;
    using Xunit;

    public class SimpleCalculatorTest
    {
        [Fact]
        public void Given_0IsNeutralElement_When_RightAdditionOfOtherNumberAddition_Then_ResultIsOtherNumber()
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act
            var result = calculator.Addition(0, 10);

            // Assert
            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)] // Failure
        [InlineData(3)]
        [InlineData(5)]
        public void Given_NumberIsOdd_When_CheckingIfOdd_Then_ResultIsTrue(int number)
        {
            // Arrange
            var calculator = new SimpleCalculator();

            // Act
            var isOdd = calculator.IsOdd(number);

            // Assert
            Assert.True(isOdd);
        }
    }
}