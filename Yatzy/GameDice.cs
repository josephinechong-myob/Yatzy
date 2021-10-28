using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold
    {
        public List<Die> Dice;
        private List<Die> _finalSelection;
  
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

        public void HoldDice(List<int> playersHeldDice) //won't work for if they only want to keep just 1x 1's (if they have 3) 
        {
            // 1, 1, 5, 6, 3
            
            //hold 1, 3, 5
            
            //new list for only the dice list with the players selected choice

            //_finalSelection = playersHeldDice; // instead of bool 
            //after validation
            

            //List All (5) - Player's choice (1-5)

            //validation for if what they have chosen is a valid pick/in the existing Dice list

            // for (var i = 0; i < Dice.Count; i++)
            // {
            //     for (var j = 0; j < playersHeldDice.Count; j++)
            //     {
            //         if (playersHeldDice[j] == Dice[i].Face)
            //         {
            //             Dice[i].Hold();
            //         }
            //     }
            // }
            
            //Dice 1 = index 0

            for (var i = 0; i < playersHeldDice.Count; i++)
            {
                Dice[playersHeldDice[i]].Hold();
            }
            //using the dice index 
             // for (var i = 0; i < Dice.Count; i++)
             // {
             //     for (var j = 0; j < playersHeldDice.Count; j++)
             //     {
             //         //Dice 1 = index 0
             //         if (j - 1 == i)
             //         {
             //             Dice[i].Hold();
             //         }
             //     }
             // }
        }
    }
}