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
            for (var i = 0; i < Dice.Count; i++)
            {
                if (!Dice[i].IsHeld())
                {
                    Dice[i].Roll();  
                }
            }
        }

        public void HoldDice(List<int> playersHeldDice)
        {
            for (var i = 0; i < Dice.Count; i++)
            {
                for (var j = 0; j < playersHeldDice.Count; j++)
                {
                    if (playersHeldDice[j] == Dice[i].Face)
                    {
                        Dice[i].Hold();
                    }
                }
            }
        }
    }
}