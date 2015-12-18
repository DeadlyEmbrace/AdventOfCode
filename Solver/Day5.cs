using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Solver
{
    public class Day5
    {
        public void Day5_1()
        {
            var data = File.ReadAllLines("Puzzle5.txt");
            var niceCounter = data.Count(IsStringNice);

            Console.WriteLine($"There are {niceCounter} nice strings");
            Console.ReadKey();
        }

        public void Day5_2()
        {
            var data = File.ReadAllLines("Puzzle5.txt");
            var niceCounter = data.Count(IsStringNiceNewRules);

            Console.WriteLine($"There are {niceCounter} nice strings");
            Console.ReadKey();
        }

        private bool IsStringNiceNewRules(string example)
        {
            var condition1 = MatchDoubles(example);
            var condition2 = CountAppearanceOf(example, @"(\w)((\w)\1)");

            var isNice = condition1 >= 1 && condition2 >= 1;
            return isNice;
        }

        private bool IsStringNice(string example)
        {
            var condition1 = CountAppearanceOf(example, "[aeiou]");
            var condition2 = CountAppearanceOf(example, @"(.)\1");
            var condition3 = CountAppearanceOf(example, @"(ab|cd|pq|xy)");

            var isNice = condition1 >= 3 && condition2 >= 1 && condition3 == 0;
            return isNice;
        }

        private int CountAppearanceOf(string value, string regex)
        {
            var matches = Regex.Matches(value, regex);
            return matches.Count;
        }

        private int MatchDoubles(string value)
        {
            var length = value.Length;
            var allPairs = new List<Pairs>();
            for (var r = 0; r < length; r++)
            {
                var t = r + 1;
                if (t < length)
                {
                    var tmpPair = new Pairs
                    {
                        Pair = $"{value[r]}{value[t]}",
                        FirstChar = r,
                        SecondChar = t
                    };
                    allPairs.Add(tmpPair);
                }
            }

            var groups = allPairs.GroupBy(t => t.Pair).ToList();
            var matches = groups.Count(t => t.Count() > 1);

            var invalid = false;

            foreach (var item in groups)
            {
                foreach (var p in item)
                {
                    var firstChar = p.FirstChar;
                    var matchItem = item.Where(t => t.SecondChar == firstChar);
                    if (matchItem.Any())
                        invalid = true;
                }
                
            }

            return !invalid ? matches : 0;
        }

    }

    public class Pairs
    {
        public string Pair { get; set; }
        public int FirstChar { get; set; }
        public int SecondChar { get; set; }
    }
}