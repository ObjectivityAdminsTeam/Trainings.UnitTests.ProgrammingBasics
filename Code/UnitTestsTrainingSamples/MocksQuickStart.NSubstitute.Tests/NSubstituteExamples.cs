namespace MocksQuickStart.NSubstitute.Tests
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    using global::NSubstitute;
    using global::NSubstitute.ExceptionExtensions;
    using Xunit;

    public class NSubstituteExamples
    {
        public void MultipleInterfaces()
        {
            var weirdMock = Substitute.For(
                new[] {typeof(ICurrencyProviderService), typeof(IDisposable), typeof(StringBuilder)},
                new object[] {"initialValue", 100});
        }

        [Fact]
        public void SimpleMocks()
        {
            // Creation
            var serviceMock = Substitute.For<ICurrencyProviderService>();

            // Setup
            serviceMock.Status.Returns(ServiceStatus.Online);
            serviceMock.IsCurrencyAvailable(string.Empty).Returns(true);
            serviceMock.GetExchangeRate("USD").Throws<CurrencyNotSupportedException>();

            // Usage
            decimal value = serviceMock.GetExchangeRate("EUR");

            // Assert
            Assert.Equal(ServiceStatus.Online, serviceMock.Status);
            Assert.True(serviceMock.IsCurrencyAvailable(string.Empty));
            // Assert.True(serviceMock.IsCurrencyAvailable("USD"));
            Assert.Equal(0, value);
            Assert.Throws<CurrencyNotSupportedException>(() => serviceMock.GetExchangeRate("USD"));
        }

        [Fact]
        public void MatchingArguments()
        {
            var serviceMock = Substitute.For<ICurrencyProviderService>();

            // Any string
            serviceMock.IsCurrencyAvailable(Arg.Any<string>()).Returns(false);

            // 3 letters string
            serviceMock.IsCurrencyAvailable(Arg.Is<string>(currencyCode => currencyCode.Length == 3)).Returns(true);

            // Specific code - USD and EUR
            serviceMock.GetExchangeRate("USD").Returns(3.8039m);
            serviceMock.GetExchangeRate("EUR").Returns(4.3010m, 5.0321m, 6.0123m);

            // 3 upcase letters - Regex
            serviceMock.IsCurrencyAvailable(Arg.Is<string>(x => new Regex("[A-Z]{3}").IsMatch(x))).Returns(true);

            // Assert
            Assert.Equal(3.8039m, serviceMock.GetExchangeRate("USD"));
            Assert.Equal(4.3010m, serviceMock.GetExchangeRate("EUR"));
            Assert.Equal(5.0321m, serviceMock.GetExchangeRate("EUR"));
            Assert.True(serviceMock.IsCurrencyAvailable("USD")); // Different setup with mock - for short names true
            Assert.False(serviceMock.IsCurrencyAvailable("LongName")); // For longer false
        }

        [Fact]
        public void Verification()
        {
            var serviceMock = Substitute.For<ICurrencyProviderService>();

            // GetExchangeRate("USD") has been executed
            serviceMock.Received().GetExchangeRate("USD");

            // GetExchangeRate("USD") has not been executed
            serviceMock.DidNotReceive().GetExchangeRate("USD");

            // GetExchangeRate("USD") has been executed only once
            serviceMock.Received(1).GetExchangeRate("USD");

            // GetExchangeRate(with argument validated by regex) has been executed
            serviceMock.Received().GetExchangeRate(Arg.Is<string>(x => new Regex("[A-Z]{3}").IsMatch(x)));

            // Getter has been invocated
            var temp = serviceMock.Received().Status; // temp needed by compiler

            // Setter has been invocated with specific value
            serviceMock.Received().Status = ServiceStatus.Online;
        }

        [Fact]
        public void CallbackUsage()
        {
            var serviceMock = Substitute.For<ICurrencyProviderService>();

            int gbpRateChecks = 0;
            int usdRateChecks = 0;
            // Execute some code when method is executed
            serviceMock.When(x => x.GetExchangeRate("GBP"))
                       .Do(x => gbpRateChecks++);

            // or when not void
            serviceMock.GetExchangeRate("GBP").Returns(4.01m).AndDoes(x => gbpRateChecks++);

            // Callback builder for more complex callbacks 
            serviceMock.When(x => x.GetExchangeRate("USD"))
                .Do(
                    Callback.First(x => Debug.WriteLine("First check"))
                            .Then(x => Debug.WriteLine("Second check"))
                            .ThenKeepDoing(x => Debug.WriteLine("....."))
                            .AndAlways(x => usdRateChecks++));
       
            // We can use arguments
            serviceMock.When(x => x.GetExchangeRate("EUR"))
                .Do(x => Debug.WriteLine($"Call with argument- {x[0]}"));


            serviceMock.GetExchangeRate("USD"); // Show debug console
            serviceMock.GetExchangeRate("USD");
            serviceMock.GetExchangeRate("USD");
            serviceMock.GetExchangeRate("USD");
            Assert.Equal(4, usdRateChecks);

            serviceMock.GetExchangeRate("EUR");
            
            // Assert.Equal(0, serviceMock.GetExchangeRate("GBP"));
            Assert.Equal(0, gbpRateChecks);
        }
    }
}
