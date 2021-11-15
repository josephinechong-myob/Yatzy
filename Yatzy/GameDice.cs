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
        

        public void HoldDice(List<int> playersHeldDice) //passing in the dice index that player wants to hold
        {
            for (var i = 0; i < playersHeldDice.Count; i++)
            {
                Dice[playersHeldDice[i]].Hold();
            }
        }

        private Die? TryMatchDice(Die die, List<int> valuesToHold)
        {
            foreach (var value in valuesToHold)
            {
                if (die.Face == value)
                {
                    return die;
                }
            }

            return null;
        }

        public List<int> FindDice(List<int> valuesToHold) //passes in dice face value to find dice index
        {
            List<int> diceToHold = new List<int>();
            
            for (var i = 0; i < Dice.Count; i++)
            {
                var matchedDice = TryMatchDice(Dice[i], valuesToHold);
                if (matchedDice !=null)
                {
                    diceToHold.Add(i);
                    valuesToHold.Remove(matchedDice.Face);
                }
            }

            if (valuesToHold.Count != 0)
            {
                throw new DiceNotFoundException($"The following dice values were not found: {string.Join(", ", valuesToHold)}" );
            }
            return diceToHold;
        }
    }
}