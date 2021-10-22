using System;
using System.Security.Cryptography;

namespace Yatzy
{
    public class Dice
    {
        public int Face { get; private set; }
        public Dice()
        {
        }
        public int Roll()
        {
            var random = new Random();
            var rolledNumber = random.Next(1, 6);
            
            Face = rolledNumber;
            
            return rolledNumber;
        }
    }
}