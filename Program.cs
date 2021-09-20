using System;

namespace SeaWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            int[] ships = new int[] { 1, 3 };
            Game game = new Game(10, ships);
            game.PlayersInit(); 
            game.GameStarts();            
        }
    }
}
