using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Program
    {
        static int[,] prostredi = new int[12, 12]
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
        // Zde se budou ukládat všechny procházené body
        static Bod[,] body = new Bod[prostredi.GetLength(0), prostredi.GetLength(1)];
        static Bod pocatecniBod = new Bod(4, 7, 0);
        static Bod cilovyBod = new Bod(8, 9, int.MaxValue);


        static void Main(string[] args)
        {
            for (int y = 0; y < body.GetLength(1); y++)
                for (int x = 0; x < body.GetLength(0); x++)
                    body[x, y] = new Bod(x, y, int.MaxValue);

            int aktualX = pocatecniBod.X; int aktualY = pocatecniBod.Y;
            body[aktualX, aktualY] = pocatecniBod;
            //fronta franta kde sa pridavaju bod 
            Queue<Bod> franta = new Queue<Bod>();
            //pridanie prveho bodu 
            franta.Enqueue(pocatecniBod);
            //pokym nedojde do cieloveho bodu bude postupne prechadzat policka vedla prveho bodu vo fronte
            while (aktualX != cilovyBod.X || aktualY != cilovyBod.Y)
            {
                //hore
                if (aktualY - 1 >= 0 && prostredi[aktualX, aktualY - 1] == 0 && body[aktualX, aktualY - 1].Hodnota == int.MaxValue)
                {

                    body[aktualX, aktualY - 1].Hodnota = franta.Peek().Hodnota + 1;//zvysi hodnotu o 1
                    franta.Enqueue(body[aktualX, aktualY - 1]);//pridava bod na konci fronty 
                }
                //vlavo
                if (aktualX - 1 >= 0 && prostredi[aktualX - 1, aktualY] == 0 && body[aktualX - 1, aktualY].Hodnota == int.MaxValue)
                {

                    body[aktualX - 1, aktualY].Hodnota = franta.Peek().Hodnota + 1;
                    franta.Enqueue(body[aktualX - 1, aktualY]);
                }
                //dole
                if (aktualY + 1 < body.GetLength(1) && prostredi[aktualX, aktualY + 1] == 0 && body[aktualX, aktualY + 1].Hodnota == int.MaxValue)
                {

                    body[aktualX, aktualY + 1].Hodnota = franta.Peek().Hodnota + 1;
                    franta.Enqueue(body[aktualX, aktualY + 1]);
                }
                //pravo
                if (aktualX + 1 < body.GetLength(0) && prostredi[aktualX + 1, aktualY] == 0 && body[aktualX + 1, aktualY].Hodnota == int.MaxValue)
                {

                    body[aktualX + 1, aktualY].Hodnota = franta.Peek().Hodnota + 1;
                    franta.Enqueue(body[aktualX + 1, aktualY]);
                }
                franta.Dequeue();//odoberie prvy bod zo zaciatku fronty
                aktualX = franta.Peek().X; aktualY = franta.Peek().Y;

            }

            //sme v cieli , musime vypisat cestu spat- pouzijeme zasobnik 
            //mozeme pouzit aj frontu
            Stack<Bod> stack = new Stack<Bod>(franta);
                do
                {
                    //hore
                    if (body[aktualX, aktualY - 1].Hodnota < body[aktualX, aktualY].Hodnota)
                    {
                        aktualY -= 1;
                        stack.Push(body[aktualX, aktualY]);
                        // franta.Enqueue(body[aktualX, aktualY]);

                    }
                    //v pravo
                    else if (body[aktualX + 1, aktualY].Hodnota < body[aktualX, aktualY].Hodnota)
                    {
                        aktualX += 1;
                        stack.Push(body[aktualX, aktualY]);
                        // franta.Enqueue(body[aktualX, aktualY]);

                    }
                    //vlavo
                    else if (body[aktualX - 1, aktualY].Hodnota < body[aktualX, aktualY].Hodnota)
                    {
                        aktualX -= 1;
                        stack.Push(body[aktualX, aktualY]);
                        // franta.Enqueue(body[aktualX, aktualY]);

                    }
                    //dole
                    else if (body[aktualX, aktualY + 1].Hodnota < body[aktualX, aktualY].Hodnota)
                    {
                        aktualY += 1;
                        stack.Push(body[aktualX, aktualY]);
                        // franta.Enqueue(body[aktualX, aktualY]);


                    }
                } while (body[aktualX, aktualY].Hodnota != 0);
            //vypis cesty ciselne v bodoch x,y
            foreach (Bod bod in stack)
            {
                Console.Write("[{0};{1}] ", bod.X, bod.Y);
            }
            //vypis cesty graficky
            for (var i = 0; i < prostredi.GetLength(0); i++)
            {
                for (int ji = 0; ji < prostredi.GetLength(1); ji++)
                {
                    if (body[ji, i].Hodnota < 50)
                        Console.Write($"{body[ji, i].Hodnota,3}");
                    else
                        Console.Write($"{"███",3}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();


        }

    }
}
