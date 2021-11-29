using System.Collections.Generic;

namespace Yatzy.Categories
{
    public class SmallStraightStrategy
    {
        public CategoryType Name => CategoryType.SmallStraight;
        
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
            if (IsSmallStraight(diceValue))
            {
                return 15;
            }
            return 0;
        }
    }
}