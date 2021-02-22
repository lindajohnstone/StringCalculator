using System;
using System.Collections.Generic;
using System.Linq;

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
                return Calculate(numbers.Substring(4).Split(";"));
            }
        
            return Calculate(numbers.Replace("\n", ",").Split(","));
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