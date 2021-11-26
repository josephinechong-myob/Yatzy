using System;

namespace Yatzy
{
    public class Die
    {
        public int Face { get; private set; } //This records value of rolled number, ? after a type means it might be that type or null
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private bool _held; //Attribute which determines if die is held or rolled
        
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

        public void Hold()
        {
            _held = true;
        }

        public void Release()
        {
            _held = false;
        }
    }
}