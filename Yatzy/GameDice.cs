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

        public void HoldDice()//list of numbers of dice index they want to hold
        {
            //allow the player to hold(bool in die) a particular dice
        }
    }
}