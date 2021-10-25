using System;

namespace Yatzy
{
    public class Dice
    {
        public int Face { get; private set; }
        private IRandomNumberGenerator _randomNumberGenerator;
        
        public Dice(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }
        public int Roll()
        {
            var rolledNumber = _randomNumberGenerator.RandomNumber(Constants.MinimumDiceRoll, Constants.MaximumDiceRoll);
            Face = rolledNumber;
            
            return rolledNumber;
        }
    }
}