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
        public void Step_2_single_number_returns_that_number()
        {
            // arrange
            var expected = 1;
            // act
            var result = Calculator.Add("1");
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Two_numbers_return_the_sum_of_the_numbers()
        {
            // arrange 
            var expected = 3;
            // act
            var result = Calculator.Add("1,2");
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Any_amount_of_numbers_returns_the_sum_of_those_numbers()
        {
            var expected = 6;
            var result = Calculator.Add("1,2,3");
            Assert.Equal(expected, result);
        }
        [Fact]
        public void New_line_breaks_and_commas_should_be_interchangeable_between_numbers()
        {
            var expected = 6;
            var result = Calculator.Add("1,2\n3");
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Support_single_character_delimiter()
        {
            Assert.Equal(3, Calculator.Add("//;\n1;2"));
        }
    }
}
