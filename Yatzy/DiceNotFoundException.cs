using System;

namespace Yatzy
{
    public class DiceNotFoundException : Exception
    {
        public DiceNotFoundException(string message)
        : base(message)
        {
            
        }
    }
}