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
            return numbers.Sum();
        }
        private static IEnumerable<int> ParseAllToInt(string[] nums)
        {
            return ValidateNegativeNumber(nums.Select(int.Parse));
        }

        private static IEnumerable<int> ValidateNegativeNumber(IEnumerable<int> number)
        {
            if(number.Any(x => x < 0)) throw new ArgumentException(number.Aggregate("Negatives not allowed:",
                (message, number) => number < 0 ? message + $" {number}," : message).Trim(','));
            return number;
        }
    }
}