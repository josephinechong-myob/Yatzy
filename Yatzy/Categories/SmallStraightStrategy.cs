using System.Collections.Generic;

namespace Yatzy
{
    public class SmallStraightStrategy
    {
        private static bool IsSmallStraight(List<int> diceValues)
        {
            var SmallStraight = new List<int> {1, 2, 3, 4, 5};

            foreach (var number in SmallStraight)
            {
                if (!diceValues.Contains(number))
                {
                    return false;
                }
            }
            return true;
        }
        public static int CalculateScore(List<int> diceValue)
        {
            if (IsSmallStraight(diceValue))
            {
                return 15;
            }
            return 0;
        }
    }
}