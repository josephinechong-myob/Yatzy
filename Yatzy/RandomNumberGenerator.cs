using System;

namespace Yatzy
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int RandomNumber(int min, int max)
        {
            var number = new Random().Next(min, max);
            return number;
        }
    }
}