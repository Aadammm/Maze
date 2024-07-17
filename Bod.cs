using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    struct Bod
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public Bod(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

    }
}
