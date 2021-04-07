using System;
using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Threading;

namespace labyrinth
{
    public class Laby
    {
        public int[,] laby;
        public int sizeX;
        public int sizeY;
        
        public Laby(int[,] laby)
        {
            this.laby = laby;
            sizeX = laby.GetLength(0);
            sizeY = laby.GetLength(1);
        }

        public void RandomGrid(int size)
        {
            Random r = new Random();
            sizeX = size;
            sizeY = size;
            laby = new int[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    laby[i, j] = (r.Next(5) == 0 ? 1: 0);
                }
            }
        }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < laby.GetLength(0); i++)
            {
                for (int j = 0; j < laby.GetLength(1); j++)
                {
                    Console.BackgroundColor = laby[i, j] == 1 ? ConsoleColor.White : ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public bool SolveRec(int x1, int y1, int x2, int y2)
        {
            Thread.Sleep(10);
            if (x1 == x2 && y1 == y2)
            {
                return true;
            }
            
            if (x1 < 0|| y1 < 0 || x1 >= sizeY || y1 >= sizeX || laby[y1, x1] != 0)
            {
                return false;
            }
            else
            {
                Console.SetCursorPosition(x1, y1);
                laby[y1, x1] = 1;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
                if(
                    SolveRec(x1, y1 + 1, x2, y2) ||
                    SolveRec(x1 - 1, y1, x2, y2) ||
                    SolveRec(x1 + 1, y1, x2, y2) ||
                    SolveRec(x1, y1 - 1, x2, y2)
                )
                {
                    return true;
                }
                Console.SetCursorPosition(x1, y1);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                laby[y1, x1] = 0;
                return false;
            }
        }
    }
}