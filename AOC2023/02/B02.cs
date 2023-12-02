using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2023._02
{
    internal class B02
    {
        public static int start()
        {
            int sum = 0;
            foreach (string Line in File.ReadLines(Path.Combine(Environment.CurrentDirectory, @"..\..\..", @"02\Input02.txt")))
            {
                string[] rounds = Line.Split(';');
                int gameId = int.Parse(Regex.Matches(rounds[0], "Game ([0-9]*)").First().Groups[1].Value);
                Game game = new Game(gameId);
                foreach (var r in rounds)
                {
                    var matches = Regex.Matches(r, " ([0-9]*) (blue|red|green),*");
                    Dictionary<colors, int> round = new();
                    foreach (Match m in matches)
                    {
                        string color = m.Groups[2].Value;
                        int number = int.Parse(m.Groups[1].Value);
                        round.Add(Enum.Parse<colors>(color), number);
                    }
                    game.Rounds.Add(round);

                }
                sum += game.GetLowest();

            }
            Console.WriteLine(sum);
            return sum;
        }
    }
}
