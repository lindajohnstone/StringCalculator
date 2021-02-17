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
            var expected = 0;
            // act
            var result = Calculator.Add("");
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Step_2()
        {
            // arrange
            var expected = 1;
            // act
            var result = Calculator.Add("1");
            // assert
            Assert.Equal(expected, result);
        }
    }
}
