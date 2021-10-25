using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold
    {
        public List<Die> Dice; 
        public GameDice(IRandomNumberGenerator randomNumberGenerator)
        {
            Dice = GameDiceGenerator.Generate(randomNumberGenerator); 
        }

        public void RollDice()
        {
            for (var i = 0; i < Dice.Count; i++) //rolling all 5 dice 
            {
                Dice[i].Roll();
            }
        }
    }
}