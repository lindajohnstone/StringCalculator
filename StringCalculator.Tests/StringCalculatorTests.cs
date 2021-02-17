using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Step_1_Returns_Zero_If_Parameter_Is_Empty_String()
        {
            // arrange
            var calculator = new Calculator();
            var expected = 0;
            // act
            var result = calculator.Add("");
            // assert
            Assert.Equal(expected, result);
        }
    }
}
