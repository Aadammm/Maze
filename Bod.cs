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
        public int Hodnota { get; set; }
        public Bod(int x, int y, int hodnota)
        {
            X = x;
            Y = y;
            Hodnota = hodnota;
        }
    }
}
