using System;

namespace Yatzy
{
    public class Dice
    {
        public int Face { get; private set; }
        private IRandomNumberGenerator _randomNumberGenerator;
        
        //create interface for random number generator to create test double
        public Dice(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }
        public int Roll()
        {
            var rolledNumber = _randomNumberGenerator.RandomNumber(1, 6);
            Face = rolledNumber;
            
            return rolledNumber;
        }
    }
}