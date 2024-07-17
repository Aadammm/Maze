using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze
{
    public static class Program
    {



        static void Main(string[] args)
        {
            Maze maze = new Maze();
            int fieldWidthLength = maze.GetWidth();
            int fieldHeightLength = maze.GetHeight();
            Point[,] fieldOfPoints = new Point[fieldWidthLength, fieldHeightLength];

            Point Start = new Point(4, 7, 0);
            Point Finish = new Point(8, 9, int.MaxValue);

            FillField(fieldWidthLength, fieldHeightLength, fieldOfPoints);

            int aktualX = Start.X; int aktualY = Start.Y;
            fieldOfPoints[aktualX, aktualY] = Start;

            Queue<Point> Road = new Queue<Point>();
            Road.Enqueue(Start);
            while (aktualX != Finish.X || aktualY != Finish.Y)
            {
                if (aktualY - 1 >= 0 && maze[aktualX, aktualY - 1] == 0 && fieldOfPoints[aktualX, aktualY - 1].Value == int.MaxValue)
                {
                    fieldOfPoints[aktualX, aktualY - 1].Value = Road.Peek().Value + 1;
                    Road.Enqueue(fieldOfPoints[aktualX, aktualY - 1]);
                }
                if (aktualX - 1 >= 0 && maze[aktualX - 1, aktualY] == 0 && fieldOfPoints[aktualX - 1, aktualY].Value == int.MaxValue)
                {
                    fieldOfPoints[aktualX - 1, aktualY].Value = Road.Peek().Value + 1;
                    Road.Enqueue(fieldOfPoints[aktualX - 1, aktualY]);
                }
                if (aktualY + 1 < fieldHeightLength && maze[aktualX, aktualY + 1] == 0 && fieldOfPoints[aktualX, aktualY + 1].Value == int.MaxValue)
                {
                    fieldOfPoints[aktualX, aktualY + 1].Value = Road.Peek().Value + 1;
                    Road.Enqueue(fieldOfPoints[aktualX, aktualY + 1]);
                }
                if (aktualX + 1 < fieldWidthLength && maze[aktualX + 1, aktualY] == 0 && fieldOfPoints[aktualX + 1, aktualY].Value == int.MaxValue)
                {
                    fieldOfPoints[aktualX + 1, aktualY].Value = Road.Peek().Value + 1;
                    Road.Enqueue(fieldOfPoints[aktualX + 1, aktualY]);
                }
                Road.Dequeue();
                aktualX = Road.Peek().X; aktualY = Road.Peek().Y;
                DisplayRoad(fieldWidthLength, fieldHeightLength, fieldOfPoints);
                Thread.Sleep(100);
            }

            Stack<Point> stack = new Stack<Point>(Road);
            do
            {
                if (fieldOfPoints[aktualX, aktualY - 1].Value < fieldOfPoints[aktualX, aktualY].Value)
                {
                    aktualY -= 1;
                    stack.Push(fieldOfPoints[aktualX, aktualY]);
                }
                else if (fieldOfPoints[aktualX + 1, aktualY].Value < fieldOfPoints[aktualX, aktualY].Value)
                {
                    aktualX += 1;
                    stack.Push(fieldOfPoints[aktualX, aktualY]);
                }
                else if (fieldOfPoints[aktualX - 1, aktualY].Value < fieldOfPoints[aktualX, aktualY].Value)
                {
                    aktualX -= 1;
                    stack.Push(fieldOfPoints[aktualX, aktualY]);
                }
                else if (fieldOfPoints[aktualX, aktualY + 1].Value < fieldOfPoints[aktualX, aktualY].Value)
                {
                    aktualY += 1;
                    stack.Push(fieldOfPoints[aktualX, aktualY]);
                }
            } while (fieldOfPoints[aktualX, aktualY].Value != 0);
            DisplayPointRoad(stack);

            Console.ReadLine();
        }

        private static void FillField(int fieldWidthLength, int fieldHeightLength, Point[,] field)
        {

            for (int y = 0; y < fieldWidthLength; y++)
                for (int x = 0; x < fieldHeightLength; x++)
                    field[x, y] = new Point(x, y, int.MaxValue);
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

        private static void DisplayRoad(int width, int height, Point[,] field)
        {
            Console.Clear();
            for (var i = 0; i < width; i++)
            {
                for (int ji = 0; ji < height; ji++)
                {
                    if (field[ji, i].Value < 50)
                        Console.Write($"{field[ji, i].Value,3}");
                    else
                        Console.Write($"{"███",3}");
                }
                Console.WriteLine();
            }
        }
    }
}
