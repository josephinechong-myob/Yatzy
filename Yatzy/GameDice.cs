using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold
    {
        public List<Die> Dice;
        //public List<Die> Held;//new list for holding dice OR
        //hold interger/index of number being held OR
        //Dice can be locked for holding (attribute)
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

        public void HoldDice(List<int> playersHeldDice)//list of numbers of dice index they want to hold - dice (index - user they can hold the value of the face)
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