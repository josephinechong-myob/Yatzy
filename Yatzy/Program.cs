using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var game = new Game(console);
            game.Run();
        }
    }
}