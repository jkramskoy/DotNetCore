using System;
using System.Numerics;
using Humanizer;


namespace Number_ToWords
{
    public static class Ext
    {
        public static string ToWords(this BigInteger bi)
        {
            string result = "";

            if ((bi / 1000000000000000000) > 0) {
                result += ToWords((bi - (bi % 1000000000000000000)) / 1000000000000000000) + " quintillion ";
                bi %= 1000000000000000000;

            }
            if ((bi / 1000000000000000) > 0) {
                result += ToWords((bi - (bi % 1000000000000000)) / 1000000000000000) + " quadrillion ";
                bi %= 1000000000000000;
            }
            if ((bi / 1000000000000) > 0) {
                result += ToWords((bi - (bi % 1000000000000)) / 1000000000000) + " trillion ";
                bi %= 1000000000000;
            }
            if ((bi / 1000000000) > 0)
            {
                result += ToWords((bi - (bi % 1000000000)) / 1000000000) + " billion ";
                bi %= 1000000000;
            }
            if ((bi / 1000000) > 0)
            {
                result += ToWords((bi - (bi % 1000000)) / 1000000) + " million ";
                bi %= 1000000;
            }
            if ((bi / 1000) > 0)
            {
                result += ToWords((bi - (bi % 1000)) / 1000) + " thousand ";
                bi %= 1000;
            }
            if ((bi / 100) > 0)
            {
                result += ToWords((bi - (bi % 100)) / 100) + " hundred ";
                bi %= 100;
            }
            if (bi > 0)
            {
                if (result != "")
                    result += "and ";
                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


                if (bi < 20)
                    result += unitsMap[(uint)bi];
                else
                {
                    result += tensMap[(uint)bi / 10];
                    if ((bi % 10) > 0)
                        result += "-" + unitsMap[(uint)bi % 10];
                }

            }

            return result;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            
            var number =BigInteger.Parse("18456000000000000000");
            
            Console.WriteLine(number.ToWords());

            var anotherNumber = new BigInteger(18000000);
            Console.WriteLine(anotherNumber.ToWords());

        }
    }
}
