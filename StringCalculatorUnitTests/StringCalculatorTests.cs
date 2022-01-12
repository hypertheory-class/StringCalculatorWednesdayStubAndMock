
using Xunit;

// Instructions: https://osherove.com/tdd-kata-1

namespace StringCalculatorUnitTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void CalculatorReturnsZeroForEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }
    }
}
