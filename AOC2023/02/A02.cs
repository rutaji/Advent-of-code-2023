using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._02
{
    internal class A02
    {
        public static int start()
        {
            int sum= 0;
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"02\Input02.txt")))
            {
                string[] rounds = Line.Split(';');
                int gameId = int.Parse(Regex.Matches(rounds[0], "Game ([0-9]*)").First().Groups[1].Value);
                Game game = new Game( gameId);
                foreach(var r in rounds)
                {
                    var matches = Regex.Matches(r," ([0-9]*) (blue|red|green),*");
                    Dictionary<colors,int> round= new();
                    foreach(Match m in matches) 
                    {
                        string color = m.Groups[2].Value;
                        int number = int.Parse( m.Groups[1].Value);
                        round.Add(Enum.Parse<colors>(color), number);
                    }
                    game.Rounds.Add(round);
                    
                }
                if (game.IsPossible()) 
                {
                    sum += game.id;
                }

            }
            Console.WriteLine(sum);
            return sum;
        }
    }
    public class Game 
    {
        public int id;
        public List<Dictionary<colors, int>> Rounds = new();

        public Game(int id) { this.id = id; }

        public bool IsPossible()
        {
            foreach(var r in Rounds)
            {
                if ((r.ContainsKey(colors.blue) && r[colors.blue] > 14 )|| (r.ContainsKey(colors.green) && r[colors.green] > 13 )|| (r.ContainsKey(colors.red) && r[colors.red] > 12))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetLowest()
        {
            Dictionary<colors, int> lowest = new();


            foreach (var r in Rounds) 
            {
                foreach(KeyValuePair<colors,int> kp in r) 
                {
                    if (!lowest.ContainsKey(kp.Key) || lowest[kp.Key] < kp.Value) 
                    {
                        lowest[kp.Key] = kp.Value;
                    }
                }
            }
            int sum = 1;
            foreach (KeyValuePair<colors, int> kp in lowest) 
            {
                sum *= kp.Value;
            }
            return sum;
        }

    }
    public enum colors 
    {
        blue,
        green,
        red

    }
}
