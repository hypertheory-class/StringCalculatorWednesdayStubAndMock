
using Xunit;

// Instructions: https://osherove.com/tdd-kata-1

namespace StringCalculatorUnitTests
{
    public class StringCalculatorTests
    {

        private StringCalculator _calculator;
        public StringCalculatorTests()
        {
            _calculator = new StringCalculator();
        }
        [Fact]
        public void CalculatorReturnsZeroForEmptyString()
        {

            var result = _calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("22", 22)]
        [InlineData("1080", 1080)]
        public void SingleDigits(string numbers, int expected)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("10,2", 12)]
        [InlineData("999,2", 1001)]
        public void TwoDigits(string numbers, int expected)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]

        public void UnknownNumbers(string numbers, int expected)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2\n3", 6)]


        public void NewLine(string numbers, int expected)
        {

            var result = _calculator.Add(numbers);

            Assert.Equal(expected, result);
        }
    }
}
