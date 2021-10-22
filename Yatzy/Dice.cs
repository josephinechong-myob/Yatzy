using System;
using System.Security.Cryptography;

namespace Yatzy
{
    public class Dice
    {
        public Dice()
        {
            
        }
        public int Roll()
        {
            var random = new Random();
            return random.Next(1, 6);
        }
    }
}