using System;
using System.Collections.Generic;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeGameBoard game = new PrimeGameBoard("MyGame", 8, 8, 0, 0, 7, 7);
            Console.WriteLine(game.ToString());
            game.Solve(game.StartSpace, 16);
            Console.WriteLine("Returning");
            Console.ReadKey();
        }
    }
}
