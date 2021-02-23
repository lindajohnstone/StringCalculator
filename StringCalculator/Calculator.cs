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
                var delimiter = Convert.ToChar(numbers.Substring(2, 1));
                return Calculate(numbers.Substring(4), delimiter);
            }
            return Calculate(numbers.Replace("\n", ","), ',');
        }

        private static int Calculate(string numbers, char delimiter)
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
            return nums.Select(int.Parse);
        }
    }
}