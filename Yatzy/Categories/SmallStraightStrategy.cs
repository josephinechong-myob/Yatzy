using System.Collections.Generic;

namespace Yatzy.Categories
{
    public static class SmallStraightStrategy
    {
        private static bool IsSmallStraight(List<int> diceValues)
        {
            var smallStraight = new List<int> {1, 2, 3, 4, 5};

            foreach (var number in smallStraight)
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
            return IsSmallStraight(diceValue) ? 15 : 0;
        }
    }
}