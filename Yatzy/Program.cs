namespace Yatzy
{
    static class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var randomNumberGenerator = new RandomNumberGenerator();
            var game = new Game(console, randomNumberGenerator);
            game.Run();
        }
    }
}