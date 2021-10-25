using System.Collections.Generic;

namespace Yatzy
{
    public static class GameDiceGenerator
    {
        public static List<Dice> Generate(IRandomNumberGenerator randomNumberGenerator)
        {
            return new List<Dice>() {
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
            }; 
        }
    }
}