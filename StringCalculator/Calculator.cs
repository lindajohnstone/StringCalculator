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
            var value = numbers.Split(",");
            var numberList = new List<int>();
            foreach (var number in value)
            {
                numberList.Add(int.Parse(number));
            }
            return numberList.Sum();
        }
    }
}