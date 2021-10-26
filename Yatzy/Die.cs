using System;

namespace Yatzy
{
    public class Die
    {
        public int Face { get; private set; } //This records value of rolled number
        private IRandomNumberGenerator _randomNumberGenerator;
        private bool _held;
        
        public Die(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
            
        }
        public int Roll()
        {
            var rolledNumber = _randomNumberGenerator.RandomNumber(Constants.MinimumDiceRoll, Constants.MaximumDiceRoll);
            Face = rolledNumber;
            
            return rolledNumber;
        }

        public bool IsHeld()
        {
            return _held;
        }

        public bool SetHeld()
        {
            
        }
        //set held or hold
        
        
        //set released
    }
}