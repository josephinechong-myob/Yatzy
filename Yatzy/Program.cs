namespace Yatzy
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var console = new GameConsole();
            var randomNumberGenerator = new RandomNumberGenerator();
            var game = new Game(console, randomNumberGenerator);
            game.Run();
        }
    }
}