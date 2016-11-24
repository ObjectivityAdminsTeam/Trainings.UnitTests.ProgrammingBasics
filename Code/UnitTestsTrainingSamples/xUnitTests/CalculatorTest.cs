namespace xUnitTests
{
    using System;
    using Xunit;

    public class CalculatorTest : IDisposable
    {
        public CalculatorTest()
        {
            // We will setup everything here - executes before each test
        }

        [Fact]
        public void Given_FirstNumberIs5_When_Add6_Then_ResultIs11()
        {
            // Code of unit test
        }

        public void Dispose()
        {
            // Cleaning actions - executes after each test
        }
    }
}
