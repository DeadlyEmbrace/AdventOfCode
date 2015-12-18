using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solver
{
    public class Day3
    {
        public void Day3_1()
        {
            var fileData = File.ReadAllText("Puzzle3.txt");
            var directions = fileData.ToCharArray();
            var map = new List<Locations>();

            var currentX = 0;
            var currentY = 0;

            //Add starting location to the map - Santa drops a present when he starts
            var curLoc = new Locations {Visits = 1, X = currentX, Y = currentY};
            map.Add(curLoc);

            foreach (var item in directions)
            {
                switch (item)
                {
                    case '^':
                        currentX++;
                        break;
                    case 'v':
                        currentX--;
                        break;
                    case '<':
                        currentY--;
                        break;
                    case '>':
                        currentY++;
                        break;
                }

                var location = map.FirstOrDefault(t => t.X == currentX && t.Y == currentY);
                if (location == null)
                {
                    var tmpLoc = new Locations {Visits = 1, X = currentX, Y = currentY};
                    map.Add(tmpLoc);
                }
                else
                {
                    location.Visits++;
                }
            }
         
            Console.WriteLine($"Houses visited: {map.Count}");
            Console.ReadKey();
        } 
    }

    public class Locations
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Visits { get; set; }
    }
}