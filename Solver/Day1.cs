using System;
using System.IO;
using System.Linq;

namespace Solver
{
    class Day1
    {
        public void Day1_1()
        {
            var fileData = File.ReadAllText("Puzzle1.txt");
            var charArray = fileData.ToCharArray();
            var up = charArray.Count(t => t == '(');
            var down = charArray.Count(t => t == ')');

            var floor = up - down;

            Console.WriteLine($"Final floor: {floor}");
            Console.ReadKey();
        }

        public void Day1_2()
        {
            var fileData = File.ReadAllText("Puzzle1.txt");
            var charArray = fileData.ToCharArray();

            var floor = 0;
            var counter = 0;
            foreach (var item in charArray)
            {
                counter++;
                var adjustment = item == '(' ? 1 : -1;
                floor += adjustment;
                if (floor == -1)
                {
                    Console.WriteLine($"Enters basement at: {counter}");
                    Console.ReadKey();
                }
            }
        }
    }
}
