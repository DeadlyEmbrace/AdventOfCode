using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solver
{
    public class Day2
    {
        public void Day2_1()
        {
            var data = File.ReadAllLines("Puzzle2.txt");

            var totalLength = 0;
            foreach (var line in data)
            {
                var split = line.Split('x');
                var length = int.Parse(split[0]);
                var width = int.Parse(split[1]);
                var heigth = int.Parse(split[2]);

                var lengthSquare = CalculateSquare(length, width);
                var widthSquare = CalculateSquare(width, heigth);
                var heightSquare = CalculateSquare(heigth, length);

                var lengthArr = new List<int> {lengthSquare, widthSquare, heightSquare};
                var smallest = lengthArr.Min();

                totalLength += (2*lengthSquare) + (2*widthSquare) + (2*heightSquare) + smallest;    
            }

            Console.WriteLine($"Paper needed: {totalLength}");
            Console.ReadKey();
        }

        public void Day2_2()
        {
            var data = File.ReadAllLines("Puzzle2.txt");

            var totalLength = 0;
            foreach (var line in data)
            {
                var split = line.Split('x');
                var length = int.Parse(split[0]);
                var width = int.Parse(split[1]);
                var heigth = int.Parse(split[2]);

                var lengthArr = new List<int> {length, width, heigth};
                var smallest = lengthArr.Min();
                lengthArr.Remove(smallest);
                var secondSmallest = lengthArr.Min();

                var wrapping = (smallest*2) + (secondSmallest*2);
                var ribbon = length*width*heigth;

                totalLength += wrapping + ribbon;
            }

            Console.WriteLine($"Total Ribbon: {totalLength}");
            Console.ReadKey();
        }

        private int CalculateSquare(int dim1, int dim2)
        {
            return dim1*dim2;
        }
    }
}