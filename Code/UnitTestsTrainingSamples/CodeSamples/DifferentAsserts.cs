namespace CodeSamples
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class DifferentAsserts
    {
        [Fact]
        public void AssertTypes()
        {
            var collection = new List<int>();
            
            // Item is not equal to provided
            Assert.NotEqual(10, 15);

            // Float comparison with defined precision
            Assert.Equal(10.0f, 10.201f, 5);

            // Is false
            Assert.False(false);
            
            // Is true - can be expression
            Assert.True(10 < 15);

            // Check null
            Assert.Null(null);
            Assert.NotNull(new object());

            // String ends as we expected
            Assert.EndsWith("ExpectedEnding", "myStringExpectedEnding");

            // We can check also type of object
            Assert.IsType<List<int>>(collection);

            // Check that exception has been thrown
            Assert.Throws<NullReferenceException>(() => collection.Add(10));
            
            // All items in range 10 and 100
            Assert.All(collection, i => Assert.InRange(i, 10, 100));

            // Collection contains element with value 10
            Assert.Contains(10, collection);

            // Collection is empty
            Assert.Empty(collection);
        }
    }
}
