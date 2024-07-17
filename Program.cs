using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public static class Program
    {
        static readonly int[,] Maze = new int[12, 12]
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
        static readonly Point[,] Field = new Point[Maze.GetLength(0), Maze.GetLength(1)];
        static readonly Point Start = new Point(4, 7, 0);
        static readonly Point Finish = new Point(8, 9, int.MaxValue);


        static void Main(string[] args)
        {
            int fieldWidthLength = Maze.GetLength(0);
            int fieldHeightLength = Maze.GetLength(1);
            FillField(fieldWidthLength,fieldHeightLength);

            int aktualX = Start.X; int aktualY = Start.Y;
            Field[aktualX, aktualY] = Start;
            
            Queue<Point> Road = new Queue<Point>();
           
            Road.Enqueue(Start);
             while (aktualX != Finish.X || aktualY != Finish.Y)
            {                 
                if (aktualY - 1 >= 0 && Maze[aktualX, aktualY - 1] == 0 && Field[aktualX, aktualY - 1].Value == int.MaxValue)
                {
                    Field[aktualX, aktualY - 1].Value = Road.Peek().Value + 1;
                    Road.Enqueue(Field[aktualX, aktualY - 1]);                
                }
                if (aktualX - 1 >= 0 && Maze[aktualX - 1, aktualY] == 0 && Field[aktualX - 1, aktualY].Value == int.MaxValue)
                {
                    Field[aktualX - 1, aktualY].Value = Road.Peek().Value + 1;
                    Road.Enqueue(Field[aktualX - 1, aktualY]);
                }
                if (aktualY + 1 < fieldHeightLength && Maze[aktualX, aktualY + 1] == 0 && Field[aktualX, aktualY + 1].Value == int.MaxValue)
                {
                    Field[aktualX, aktualY + 1].Value = Road.Peek().Value + 1;
                    Road.Enqueue(Field[aktualX, aktualY + 1]);
                }
                if (aktualX + 1 < fieldWidthLength && Maze[aktualX + 1, aktualY] == 0 && Field[aktualX + 1, aktualY].Value == int.MaxValue)
                {
                    Field[aktualX + 1, aktualY].Value = Road.Peek().Value + 1;
                    Road.Enqueue(Field[aktualX + 1, aktualY]);
                }
                Road.Dequeue();
                aktualX = Road.Peek().X; aktualY = Road.Peek().Y;
                DisplayRoad();

            }
            Stack<Point> stack = new Stack<Point>(Road);
            do
            {
                if (Field[aktualX, aktualY - 1].Value < Field[aktualX, aktualY].Value)
                {
                    aktualY -= 1;
                    stack.Push(Field[aktualX, aktualY]);
                }
                else if (Field[aktualX + 1, aktualY].Value < Field[aktualX, aktualY].Value)
                {
                    aktualX += 1;
                    stack.Push(Field[aktualX, aktualY]);
                }
                else if (Field[aktualX - 1, aktualY].Value < Field[aktualX, aktualY].Value)
                {
                    aktualX -= 1;
                    stack.Push(Field[aktualX, aktualY]);
                }
                else if (Field[aktualX, aktualY + 1].Value < Field[aktualX, aktualY].Value)
                {
                    aktualY += 1;
                    stack.Push(Field[aktualX, aktualY]);
                }
            } while (Field[aktualX, aktualY].Value != 0);
            DisplayPointRoad(stack);

            Console.ReadLine();
        }

        private static void FillField(int fieldWidthLength,int fieldHeightLength)
        {
          
            for (int y = 0; y < fieldWidthLength; y++)
                for (int x = 0; x < fieldHeightLength; x++)
                    Field[x, y] = new Point(x, y, int.MaxValue);
        }

        private static void DisplayPointRoad(Stack<Point> stack)
        {
            Console.WriteLine();
            foreach (Point bod in stack)
            {
                Console.Write($"[{bod.X};{bod.Y}] ");
            }
            Console.WriteLine();
        }

        private static void DisplayRoad()
        {
            for (var i = 0; i < Maze.GetLength(0); i++)
            {
                for (int ji = 0; ji < Maze.GetLength(1); ji++)
                {
                    if (Field[ji, i].Value < 50)
                        Console.Write($"{Field[ji, i].Value,3}");
                    else
                        Console.Write($"{"███",3}");
                }
                Console.WriteLine();
            }
        }
    }
}
