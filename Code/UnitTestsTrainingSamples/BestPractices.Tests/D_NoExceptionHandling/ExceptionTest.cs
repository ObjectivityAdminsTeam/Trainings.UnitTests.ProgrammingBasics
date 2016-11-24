namespace BestPractices.Tests.D_NoExceptionHandling
{
    using System;
    using System.Collections.Generic;
    using Xunit;


    public class ExceptionTest
    {
        // Way of doing this in MS Test
        [Fact]
        public void Given_NullNumbersList_When_ConstructingObject_Then_ArgumentNullException_DONT_DO_THAT()
        {
            // Arrange - when exception will occur in this will not be catched
            var strings = new List<string> {"a", "b", "c"};

            try
            {
                // Act - we will catch only exception from this method
                new SimpleClass(null, strings);
                
                Assert.True(false, "Exception didn't occur."); // Bad practice - you should implement extension to assert class that will check if exception occured

            }
            catch (ArgumentNullException)
            {
                // Test pass
            }
        }

        // In most case it is correct way of checking exception
        [Fact]
        public void Given_NullNumbersList_When_ConstructingObject_Then_ArgumentNullException_NotExactlyCorrect() // !!!!!!!!!!!!!
        {
            Assert.Throws<ArgumentNullException>(() => new SimpleClass(null, new List<string>()));

            /* -----------------------------------------------------------------------------------
             * Same result with following lines:
             * Assert.Throws<ArgumentNullException>(() => new SimpleClass(new List<int>(), null));
             * Assert.Throws<ArgumentNullException>(() => new SimpleClass(null, null));
             * ----------------------------------------------------------------------------------- */
        }

        [Fact]
        public void Given_NullNumbersList_When_ConstructingObject_Then_ArgumentNullException_NotExactlyCorrect2() // !!!!!!!!!!!!!
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new SimpleClass(null, new List<string>()));
            Assert.Equal("Value cannot be null.\r\nParameter name: numbers", exception.Message); // We know which exception occured
                                                                                                 // But does not work in multilanguage apps.
                                                                                                 // We should use custom exceptions
        }

        // We can try to do that in this way
        [Fact]
        public void Given_NullNumbersList_When_ConstructingObject_Then_ArgumentNullException_NotExactlyCorrect3()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new SimpleClass(null, new List<string>()));
            Assert.Equal(new ArgumentNullException("numbers").Message, exception.Message);
           
        }

        private class SimpleClass
        {
            private readonly IList<int> numbers;
            private readonly IList<string> strings;

            public SimpleClass(IList<int> numbers, IList<string> strings)
            {
                if (numbers == null)
                {
                    throw new ArgumentNullException(nameof(numbers));
                }

                if (strings == null)
                {
                    throw new ArgumentNullException(nameof(strings));
                }

                this.numbers = numbers;
                this.strings = strings;
            }
        }
    }
}
