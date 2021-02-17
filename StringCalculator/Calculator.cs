using System;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string srcData)
        {
            if (srcData != "")
            {
                var number = Int32.TryParse(srcData, out var num);
                return num;
            }
            return 0;
        }
    }
}