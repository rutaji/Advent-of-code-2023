using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._03
{
    internal class A03
    {
        public static int maxIndex;
        public static int start() 
        {
            int sum = 0;
            List<string> engine = new();
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"03\Input03.txt"))) 
            {
                engine.Add(Line);
            }
            maxIndex = engine.First().Length-1;
            for (int LineNumber = 0; LineNumber < engine.Count; LineNumber++ )
            {
                string Line = engine[LineNumber];
                var matches = Regex.Matches(Line, @"[0-9]+");
                foreach (Match match in matches)
                {
                    bool HasPartAnywhere = false;
                    HasPartAnywhere = HasPart(match.Index, match.Length,Line) ? true : HasPartAnywhere;
                    if (LineNumber != 0)
                    {
                        HasPartAnywhere = HasPart(match.Index, match.Length, engine[LineNumber - 1]) ? true : HasPartAnywhere;
                    }
                    if(LineNumber +1 < engine.Count) 
                    {
                        HasPartAnywhere = HasPart(match.Index, match.Length, engine[LineNumber + 1]) ? true : HasPartAnywhere;
                    }
                    if (HasPartAnywhere) 
                    {
                        sum += int.Parse(match.Value);
                    }

                }

            }

            Console.WriteLine(sum);
            return sum;
        }

        public static bool HasPart(int Index,int lenght,string Line)
        {
            int EndIndex = Index + lenght+1;
            Index--;
            if(Index < 0) { Index = 0; }
            if(EndIndex > maxIndex) {EndIndex = maxIndex; }

            string check = Line.Substring(Index, EndIndex - Index);
            return Regex.Match(check, @"[^.0-9]").Success;

        }
    }
}
