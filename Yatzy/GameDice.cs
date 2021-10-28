using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold
    {
        public List<Die> Dice;
        //private List<Die> _finalSelection;
  
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

        public void HoldDice(List<int> playersHeldDice) //passing in the dice idex that player wants to hold
        {
            for (var i = 0; i < playersHeldDice.Count; i++)
            {
                Dice[playersHeldDice[i]].Hold();
            }
        }

        private List<int> ConvertDieToInt()
        {
            List<int> intList = null;
            foreach (Die die in Dice)
            {
                intList.Add(die.Face);
            }
            return intList;
        }
        
        public void FindDice(List<int> valuesToHold)
        {
            //get values that player want to hold and get index for that
            // once a dice is chosen we have to remove it from being chosen again - maybe local variable 

            //so value of 3rd dice = 5 {1 2 5 2 4} {5}

            var newList = ConvertDieToInt();
            
            for (var i = 0; i < newList.Count; i++)
            {
                foreach (var t in valuesToHold)
                {
                    if (newList[i] == t)
                    {
                        var index = newList.IndexOf(t);
                    }
                }
            }
        }
    }
}