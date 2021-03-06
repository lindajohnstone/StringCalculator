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
        [Theory]
        [InlineData("//;\n1;2",3)]
        [InlineData("//%\n1%3", 4)]
        public void Support_single_character_delimiter(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }
        [Theory]
        [InlineData("-1,2,-3", "Negatives not allowed: -1, -3")]
        [InlineData("-4,2,-3", "Negatives not allowed: -4, -3")]

        public void Throws_Exception_When_Negative_Numbers_In_String(string input, string expected)
        {
            var result = Assert.Throws<ArgumentException>(() => Calculator.Add(input));
            Assert.Equal(expected, result.Message);
        }
        [Fact]
        public void Numbers_greater_or_equal_to_1000_should_be_ignored()
        {
            var expected = 2;
            var result = Calculator.Add("1000,1001,2");
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[**]\n1**2**4", 7)]
        public void Delimiters_can_be_of_any_length(string input, int expected)
        {
            var result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Substring()
        {
            var input = "//[***]\n1***2***3";
            var start = input.IndexOf("[") + 1;
            var end = input.IndexOf("]") - start;
            var newInput = "//[,]\n1,2,4";
            Assert.Equal(4, newInput.IndexOf("]"));
            Assert.Equal(2, newInput.IndexOf("["));
            Assert.Equal(2, input.IndexOf("["));
            Assert.Equal(6, input.IndexOf("]"));
            Assert.Equal("***", input.Substring(start, end));
            Assert.Equal(",", newInput.Substring(3, newInput.IndexOf("]") - 3));
        }
    }
}
