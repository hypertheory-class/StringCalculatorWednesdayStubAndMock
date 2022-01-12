using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorUnitTests;

public class LoggingTests
{
    [Theory]
    [InlineData("1,2,3", "6")]
    [InlineData("1,2,3,4,5,6,7,8,9", "45")]
    public void WritesMessageToLogger(string numbers, string expected)
    {
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);

        calculator.Add(numbers);

        // Did the logger get "6" written to it's Log method?
        mockedLogger.Verify(m => m.Log(expected));
    }

    [Fact]
    public void CallsWebServiceOnException()
    {
        var handGrenade = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        handGrenade.Setup(h => h.Log(It.IsAny<string>())).Throws<LoggerException>();
        var calculator = new StringCalculator(handGrenade.Object, mockedWebService.Object);


        calculator.Add("99");

        mockedWebService.Verify(w => w.Notify("An Error Happened"));

    }

    [Fact]
    public void WebServiceNotInvokedWithNoException()
    {
        var handGrenade = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        //handGrenade.Setup(h => h.Log(It.IsAny<string>())).Throws<LoggerException>();
        var calculator = new StringCalculator(handGrenade.Object, mockedWebService.Object);

        calculator.Add("99");

        mockedWebService.Verify(m => m.Notify(It.IsAny<string>()), Times.Never);
    }
}

