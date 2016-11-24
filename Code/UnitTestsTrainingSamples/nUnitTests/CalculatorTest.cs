namespace nUnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class CalculatorTest
    {
        [SetUp]
        public void SetUp()
        {
            // We will setup everything here - executes before each test
        }

        [Test]
        public void Given_FirstNumberIs5_When_Add6_Then_ResultIs11()
        {
            // Code of unit test
        }

        [TearDown]
        public void TearDown()
        {
            // Cleaning actions - executes after each test
        }
    }
}
