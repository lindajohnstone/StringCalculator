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
            
            return Calculate(numbers.Split(","));
            // var value = numbers.Split(",");
            //  var numberList = new List<int>();
            //  foreach (var number in value)
            //  {
            //      numberList.Add(int.Parse(number));
            //  }
            //  return numberList.Sum(); 
        }

        private static int Calculate(string[] nums)
        {
            int firstNumber = int.Parse(nums[0]);
            var secondNumber = nums.Count() >= 2 ? int.Parse(nums[1]) : 0;
            var thirdNumber = nums.Count() == 3 ? int.Parse(nums[2]) : 0;
            return firstNumber + secondNumber + thirdNumber;
        }
    }
}