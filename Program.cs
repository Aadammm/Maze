using System;
using System.Collections.Generic;
using System.Linq;
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
            bool cilovyBodNajdeny = false;
            // Každý bod má ve výchozím stavu maximální možnou hodnotu,
            // aby se pak dala jednodušeji porovnávat při hledání výsledné cesty
            for (int y = 0; y < body.GetLength(1); y++)
                for (int x = 0; x < body.GetLength(0); x++)
                    body[x, y] = new Bod(x, y, int.MaxValue);

            int aktualX=pocatecniBod.X;int aktualY = pocatecniBod.Y;
            body[aktualX, aktualY] = pocatecniBod;

            Queue<Bod> franta = new Queue<Bod>();
            franta.Enqueue(pocatecniBod);
            while (cilovyBodNajdeny)
            {

            //pravo
            if (prostredi[aktualX+1, aktualY] == 0)
            {
                    aktualX += 1;
                body[aktualX , aktualY].Hodnota =+ 1;
            }
            //vlavo
            if (prostredi[aktualX - 1, aktualY] == 0)
            {
                    aktualX -= 1;
                body[aktualX , aktualY].Hodnota = +1;
            }
            //hore
            if (prostredi[aktualX , aktualY-1] == 0)
            {
                    aktualY -= 1;
                body[aktualX , aktualY].Hodnota = +1;
            }
            //dole
            if (prostredi[aktualX , aktualY+1] == 0)
            {
                    aktualX += 1;
                body[aktualX, aktualY].Hodnota = +1;
            }
                franta.Enqueue(body[aktualX, aktualY]);

                //finish
                if (aktualX == cilovyBod.X && aktualY == cilovyBod.Y)
                    cilovyBodNajdeny = true;
            }


        }
    }
}
