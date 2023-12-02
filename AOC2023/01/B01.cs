using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._01
{
    internal class B01
    {
        public static int start()
        {

            string[] paterns = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine","[1-9]" };
            int sum = 0;
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"01\InputA01.txt")))
            {
                int firstIndex = int.MaxValue;
                int lastIndex = int.MinValue;
                string? firstValue = null;
                string? lastValue = null;
                foreach (string p in paterns)
                {

                    var Matches = Regex.Matches(Line,p);
                    if(Matches.Count > 0) 
                    {
                        if(Matches.First().Index < firstIndex) 
                        {
                            firstValue = Matches.First().Value;
                            firstIndex = Matches.First().Index;
                        }
                        if (Matches.Last().Index > lastIndex)
                        {
                            lastValue = Matches.Last().Value;
                            lastIndex = Matches.Last().Index;
                        }
                    }
                }
                if( firstValue == null || lastValue == null ) { throw new Exception("no number on line"); }

                int Toadd = int.Parse(GetNumber(firstValue) + GetNumber(lastValue));
                sum += Toadd;

            }
            Console.WriteLine($"B1  {sum}");
            return sum;
        }
        private static string GetNumber( string input) 
        {
            switch(input) 
            {
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "three":
                    return "3";
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "six":
                    return "6";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
                case "nine":
                    return "9";
                default:
                    return input;
            }
        }
    }
}
