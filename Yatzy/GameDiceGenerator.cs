using System.Collections.Generic;

namespace Yatzy
{
    public static class GameDiceGenerator
    {
        public static List<Die> Generate(IRandomNumberGenerator randomNumberGenerator)
        {
            return new List<Die>() {
                new Die(randomNumberGenerator), 
                new Die(randomNumberGenerator), 
                new Die(randomNumberGenerator), 
                new Die(randomNumberGenerator), 
                new Die(randomNumberGenerator), 
            }; 
        }
    }
}