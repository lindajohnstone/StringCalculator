using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string srcData)
        {
            return IsEmpty(srcData) ? 0 : Calculate(srcData);
        }

        private static bool IsEmpty(string s) 
        {
            return s == "";
        }

        private static int Calculate(string numbers)
        {
            if(numbers.StartsWith("//["))
            {
                return Calculate(numbers.Substring(numbers.IndexOf("\n")), numbers.Substring(3, (numbers.IndexOf("]")-3)));
            }
            if (numbers.StartsWith("/"))
            {
                return Calculate(numbers.Substring(4), numbers.Substring(2, 1));
            }
            return Calculate(numbers.Replace("\n", ","), ",");
        }

        private static int Calculate(string numbers, string delimiter)
        {
            return Calculate(numbers.Split(delimiter));
        }

        private static int Calculate(string[] nums)
        {
            IEnumerable<int> numbers = ParseAllToInt(nums);
            ValidateNegativeNumber(numbers);
            var lowNumbers = numbers.Where(x => x < 1000);
            return lowNumbers.Sum();
        }

        private static IEnumerable<int> ParseAllToInt(string[] nums)
        {
            return nums.Select(int.Parse);
        }

        private static void ValidateNegativeNumber(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0);
            if (negativeNumbers.Count() > 0) throw new ArgumentException(
                String.Concat("Negatives not allowed: ", String.Join(", ", negativeNumbers)));
        }
    }
}