using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Solver
{
    public class Day4
    {
        public void Day4_1()
        {
            Calculate("00000");
        }

        public void Day4_2()
        {
            Calculate("000000");
        }

        private void Calculate(string leadingString)
        {
            var input = File.ReadAllText("Puzzle4.txt");
            var stop = false;
            var counter = 0;
            var md5Er = new MD5Cng();
            while (!stop)
            {
                counter++;
                var calcVal = $"{input}{counter}";
                var byteVal = Encoding.ASCII.GetBytes(calcVal);
                var hash = md5Er.ComputeHash(byteVal);
                var hexVal = ToHex(hash);

                if (hexVal.StartsWith(leadingString))
                {
                    stop = true;
                }
            }

            Console.WriteLine($"First number producing MD5 with 5 leading zeros: {counter}");
            Console.ReadKey();
        }

        private string ToHex(byte[] hash)
        {
            var s = string.Concat(hash.Select(b => b.ToString("X2")));
            return s;
        } 
    }
}