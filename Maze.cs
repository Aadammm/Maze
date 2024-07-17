using System;

namespace Maze
{
    public class Maze
    {
        public readonly int[,] Field;
        public int this[int x, int y]
        {
            get { return Field[x, y]; }
        }
        public Maze()
        {
            Field = new int[12, 12]
         {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
         };
        }
        public int GetWidth() => Field.GetLength(0);
        public int GetHeight() => Field.GetLength(1);
            }
}