using System;
using System.Collections.Generic;
using System.Text;

namespace Kattis
{
    public class QuadrantSelection
    {
        public static void Main()
        {
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());
            Console.WriteLine(GetQuadrant(x, y));
        }

        public static int GetQuadrant(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                return 1;
            }
            if (x < 0 && y > 0)
            {
                return 2;
            }
            if (x < 0)
            {
                return 3;
            }
            return 4;
        }
    }
}
