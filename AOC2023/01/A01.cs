using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._01
{
    internal class A01
    {
        public static int start()
        {
                
            int sum = 0;
            foreach(string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\.." ,@"01\InputA01.txt"))) 
            {
                var Matches = Regex.Matches(Line, "[0-9]{1}");

                string firstValue = Matches.First().Value;
                string LastValue = Matches.Last().Value;
                sum += int.Parse(firstValue + LastValue);

            }
            Console.WriteLine($"A1  {sum}");
            return sum;
        }
    }
}
