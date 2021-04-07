using System;

namespace labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] laby = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,0,1,1,1,1,1,1,0},
                {0,0,0,1,0,1,0,1,0,0,1,0},
                {1,1,0,0,0,0,0,1,1,0,1,0},
                {0,0,0,1,0,1,0,0,0,0,1,0},
                {0,1,1,1,0,1,0,1,1,1,1,0},
                {0,1,0,0,0,1,0,1,1,0,0,0},
                {0,0,0,1,0,0,0,0,0,0,1,0}
            };
            Laby map = new Laby(laby);
            map.Print();
            map.SolveRec(0, 0, 11, 7);
        }
    }
}