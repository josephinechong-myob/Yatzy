using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice
    {
        public readonly List<Die> Dice;
        private readonly IConsole _console;
  
        public GameDice(IRandomNumberGenerator randomNumberGenerator, IConsole console)
        {
            Dice = GameDiceGenerator.Generate(randomNumberGenerator);
            _console = console;

        }
        
        public void DisplayDice()
        {
            _console.WriteLine("Rolled dice are: ");
            foreach (Die die in Dice)
            {
                _console.WriteLine($"{die.Face} ");
            }
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
            for (var i = 0; i < playersHeldDice.Count; i++)
            {
                Dice[playersHeldDice[i]].Hold();
            }
        }
        
        public List<int> FindDice(List<int> valuesToHold)
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
    }
}