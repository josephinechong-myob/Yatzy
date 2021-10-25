using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold & change class Dice to Die (singluar)
    {
        public List<Dice> Dice; 
        public GameDice()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            Dice = GameDiceGenerator.Generate(randomNumberGenerator); 
        }
    }
}