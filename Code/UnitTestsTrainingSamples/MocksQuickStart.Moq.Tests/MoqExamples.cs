using System;

namespace MocksQuickStart.Moq.Tests
{
    using System.Diagnostics;
    using global::Moq;
    using Xunit;

    public class MoqExamples
    {
        [Fact]
        public void SimpleMocks()
        {
            // Creation
            var serviceMock = new Mock<ICurrencyProviderService>();

            // Setup
            serviceMock.Setup(x => x.Status).Returns(ServiceStatus.Online);
            serviceMock.Setup(x => x.IsCurrencyAvailable(string.Empty)).Returns(true);
            serviceMock.Setup(x => x.GetExchangeRate("USD")).Throws<CurrencyNotSupportedException>();

            // Usage
            decimal eurExchangeRate = serviceMock.Object.GetExchangeRate("EUR");

            // Assert
            Assert.Equal(ServiceStatus.Online, serviceMock.Object.Status);
            Assert.True(serviceMock.Object.IsCurrencyAvailable(string.Empty));
            // Assert.True(serviceMock.Object.IsCurrencyAvailable("USD"));
            Assert.Equal(0, eurExchangeRate);
            Assert.Throws<CurrencyNotSupportedException>(() => serviceMock.Object.GetExchangeRate("USD"));
        }

        [Fact]
        public void MatchingArguments()
        {
            var serviceMock = new Mock<ICurrencyProviderService>();

            // Any string
            serviceMock.Setup(x => x.IsCurrencyAvailable(It.IsAny<string>())).Returns(false);

            // 3 letters string
            serviceMock.Setup(x => x.IsCurrencyAvailable(It.Is<string>(currencyCode => currencyCode.Length == 3)))
                .Returns(true);

            // Specific code - USD and EUR
            serviceMock.Setup(x => x.GetExchangeRate("USD")).Returns(3.8039m);
            serviceMock.Setup(x => x.GetExchangeRate("EUR")).Returns(4.3010m);

            // 3 upcase letters - Regex
            serviceMock.Setup(x => x.IsCurrencyAvailable(It.IsRegex("[A-Z]{3}"))).Returns(true);

            // Assert
            Assert.Equal(3.8039m, serviceMock.Object.GetExchangeRate("USD"));
            Assert.True(serviceMock.Object.IsCurrencyAvailable("USD")); // Different setup with mock - for short names true
            Assert.False(serviceMock.Object.IsCurrencyAvailable("LongName")); // For longer false
        }

        [Fact]
        public void SetupingProperties()
        {
            var serviceMock = new Mock<ICurrencyProviderService>();

            // Setup property for tracking value
            // serviceMock.SetupProperty(x => x.Status); // Without this line test will fail because mock will ignore assigned value

            serviceMock.Object.Status = ServiceStatus.Offline;

            Assert.Equal(ServiceStatus.Offline, serviceMock.Object.Status);

            // Setup property for tracking value with default value
            // serviceMock.SetupProperty(x => x.Status, ServiceStatus.Offline);

            // Setup all properties
            // serviceMock.SetupAllProperties();
        }

        [Fact]
        public void Verification()
        {
            var serviceMock = new Mock<ICurrencyProviderService>();

            // GetExchangeRate("USD") has been executed
            serviceMock.Verify(x => x.GetExchangeRate("USD"));

            // GetExchangeRate("USD") has not been executed
            serviceMock.Verify(x => x.GetExchangeRate("USD"), Times.Never);

            // GetExchangeRate("USD") has been executed only once
            serviceMock.Verify(x => x.GetExchangeRate("USD"), Times.Once);

            // GetExchangeRate(with argument validated by regex) has been executed
            serviceMock.Verify(x => x.GetExchangeRate(It.IsRegex("[A-Z]{3}")));

            // Getter has been invocated
            serviceMock.VerifyGet(x => x.Status);

            // Setter has been invocated - we do not care about value
            serviceMock.VerifySet(x => x.Status = It.IsAny<ServiceStatus>());

            // Setter has been invocated with specific value
            serviceMock.VerifySet(x => x.Status = ServiceStatus.Online);
        }

        // Run as debun and show Output from Debug
        [Fact]
        public void Callback()
        {
            var serviceMock = new Mock<ICurrencyProviderService>();

            int gbpRateChecks = 0;

            // Execute some code when method is executed
            serviceMock.Setup(x => x.GetExchangeRate("GBP"))
                .Callback(() => gbpRateChecks++);

            // Execute execute code before or / and after returning value from function 
            serviceMock.Setup(x => x.GetExchangeRate("USD"))
                .Callback(() => Debug.WriteLine("Call before returns"))
                .Returns(10)
                .Callback(() => Debug.WriteLine("Call after returns"));

            // And also use arguments that have been passed to function
            serviceMock.Setup(x => x.GetExchangeRate("EUR"))
                .Callback((string currencyCode) => Debug.WriteLine($"Call before returns - {currencyCode}"))
                .Returns(20)
                .Callback((string currencyCode) => Debug.WriteLine($"Call after returns - {currencyCode}"));


            Assert.Equal(10, serviceMock.Object.GetExchangeRate("USD")); // Show debug console
            Assert.Equal(20, serviceMock.Object.GetExchangeRate("EUR"));
            // Assert.Equal(0, serviceMock.Object.GetExchangeRate("GBP")); // Uncomment and show why test is failing
            Assert.Equal(0, gbpRateChecks);
        }
    }
}
