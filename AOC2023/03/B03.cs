using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._03
{
    internal class B03
    {
        static int maxIndex;
        static int gearCount = 0;
        public static long start()
        {
            long sum = 0;
            List<string> engine = new();
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"03\Input03.txt")))
            {
                engine.Add(Line);
            }
            maxIndex = engine.First().Length - 1;
            for (int LineNumber = 0; LineNumber < engine.Count; LineNumber++)
            {
                string Line = engine[LineNumber];
                var engines = Regex.Matches(Line, @"\*+");
                foreach (Match e in engines)
                {
                    gearCount++;
                    int index = e.Index;
                    List<int> gearNumbers = new();
                    outputSize d;

                    ReplaceNumber(getNumber(Line, index - 1,out _),gearNumbers);
                    ReplaceNumber(getNumber(Line, index + 1, out _), gearNumbers);

                    if (LineNumber != 0)
                    {
                        ReplaceNumber(getNumber(engine[LineNumber -1], index - 1,out d), gearNumbers);
                        if(d == outputSize.none)
                        {

                            
                            ReplaceNumber(getNumber(engine[LineNumber - 1], index,out d), gearNumbers);
                            if (d == outputSize.none)
                            {
                                ReplaceNumber(getNumber(engine[LineNumber - 1], index + 1, out _), gearNumbers);
                            }
                        }
                        else if (d == outputSize.hit)
                        {
                           if( !Regex.Match(engine[LineNumber - 1][index].ToString(), @"[0-9]+").Success)
                            {
                                ReplaceNumber(getNumber(engine[LineNumber - 1], index + 1, out _), gearNumbers);
                            }
                           
                        }
                    }
                    if (LineNumber + 1 < engine.Count)
                    {
                        ReplaceNumber(getNumber(engine[LineNumber + 1], index - 1, out d), gearNumbers);
                        if (d == outputSize.none)
                        {


                            ReplaceNumber(getNumber(engine[LineNumber + 1], index, out d), gearNumbers);
                            if (d == outputSize.none)
                            {
                                ReplaceNumber(getNumber(engine[LineNumber + 1], index + 1, out _), gearNumbers);
                            }
                        }
                        else if (d == outputSize.hit)
                        {
                            if (!Regex.Match(engine[LineNumber + 1][index].ToString(), @"[0-9]+").Success)
                            {
                                ReplaceNumber(getNumber(engine[LineNumber + 1], index + 1, out _), gearNumbers);
                            }

                        }
                    }
                    if (gearNumbers.Count == 2)
                    {
                        int i1 = gearNumbers.First();
                        int i2 = gearNumbers.Last();
                        sum += i1 * i2;
                    }
                }
            }
            Console.WriteLine("B03  " +  sum);
            return sum;

        }
        public static void ReplaceNumber(string n, List<int> gearNumbers)
        {
            if(n == "") { return; } /*
            string changed = engine[LineNumber].Replace(n, new string('.', n.Count()));
            engine[LineNumber] = changed;*/
            gearNumbers.Add(int.Parse(n));
        }
        public static string getNumber(string line, int index,out outputSize d )
        {
            int lenght = 1;
            bool change = false;
            string part;

            d = outputSize.none;
            while (true)
            {
                change = false;
                part = line.Substring(index, lenght);
                if (part.StartsWith("0") | part.StartsWith("1") | part.StartsWith("2") | part.StartsWith("3") | part.StartsWith("4") | part.StartsWith("5") | part.StartsWith("6") | part.StartsWith("7") | part.StartsWith("8") | part.StartsWith("9"))
                {
                    if (index != 0)
                    {
                        index--;
                        lenght++;
                        change = true;
                       
                    }

                }
                if (part.EndsWith("0") | part.EndsWith("1") | part.EndsWith("2") | part.EndsWith("3") | part.EndsWith("4") | part.EndsWith("5") | part.EndsWith("6") | part.EndsWith("7") | part.EndsWith("8") | part.EndsWith("9"))
                {
                    if (index + lenght <= maxIndex)
                    {
                        lenght++;
                        change = true;
                        
                    }
                }
                if (!change) { break; }
            }
            string number = Regex.Match(part, @"[0-9]+").Value;
            if(number != "" && outputSize.none == d)
            { d = outputSize.hit; }
            return number;


        }
        public enum outputSize
        {
            none,
            hit
        }
    }
}
