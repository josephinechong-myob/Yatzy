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

        private List<int> GetDiceFaceValues()
        {
            List<int> facevalues = null;
            foreach (Die die in Dice)
            {
                facevalues.Add(die.Face);
            }
            return facevalues;
        }
        
        public List<int> FindDice(List<int> valuesToHold)
        {
            List<int> diceToHold = new List<int>();
            
            for (var i = 0; i < Dice.Count; i++)
            {
                foreach (var t in valuesToHold)
                {
                    if (Dice[i].Face == t)
                    {
                        diceToHold.Add(i);
                    }
                }
            }
            return diceToHold;
        }
    }
}