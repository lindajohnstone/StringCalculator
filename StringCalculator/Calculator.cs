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
            List<int> numList = ValidateNegativeNumbers(numbers);
            ThrowsException(numList);
            return numbers.Sum();
        }
        private static IEnumerable<int> ParseAllToInt(string[] nums)
        {
            return nums.Select(int.Parse);
            //return ValidateNegativeNumber(nums.Select(int.Parse));
        }

        private static List<int> ValidateNegativeNumbers(IEnumerable<int> numbers)
        {
            var numList = new List<int>();
            foreach (var number in numbers)
            {
                if (number < 0) numList.Add(number);
            }
            return numList;
        }

        private static void ThrowsException(List<int> numList)
        {
            if (numList.Count > 0)
            {
                var message = "Negatives not allowed: ";
                message = String.Concat(message, String.Join(", ", numList));
                throw new ArgumentException(message);
            }
        }

        private static IEnumerable<int> ValidateNegativeNumber(IEnumerable<int> number)
        {
            if(number.Any(x => x < 0)) throw new ArgumentException("Negatives not allowed: -1, -3");
            return number;
        }
    }
}