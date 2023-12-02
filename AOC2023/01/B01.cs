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

            int sum = 0;
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"01\InputA01.txt")))
            {
                var Matches = Regex.Matches(Line, "one|four|five|six|seven|[0-9]");
                var BonusMatches = Regex.Matches(Line, "nine|two|three"); 
                var EightMatches = Regex.Matches(Line, "eight");

                string firstValue = Matches.First().Value;
                string LastValue;

                if (Matches.Count != 0)
                {
                    LastValue = Matches.Last().Value;
                    if (BonusMatches.Count != 0)
                    {
                        LastValue = Matches.Last().Index > BonusMatches.Last().Index ? Matches.Last().Value : BonusMatches.Last().Value;
                    }
                    if (EightMatches.Count != 0)
                    {
                        LastValue = Matches.Last().Index > EightMatches.Last().Index ? Matches.Last().Value : EightMatches.Last().Value;
                    }
                }
                else 
                {
                    if(BonusMatches.Count != 0) 
                    {
                        LastValue = BonusMatches.Last().Value;
                        if (EightMatches.Count != 0)
                        {
                            LastValue = BonusMatches.Last().Index > EightMatches.Last().Index ? BonusMatches.Last().Value : EightMatches.Last().Value;
                        }
                    }
                    else 
                    {
                        LastValue = EightMatches.Last().Value;
                    }
                }

                int Toadd = int.Parse(GetNumber(firstValue) + GetNumber(LastValue));
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
