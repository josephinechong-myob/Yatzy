using System.Collections.Generic;

namespace Yatzy
{
    public class LargeStraightStrategy
    {
        public CategoryType Name => CategoryType.LargeStraight;
        
        private static bool IsLargeStraight(List<int> diceValues)
        {
            var LargeStraight = new List<int> {2, 3, 4, 5, 6};

            foreach (var number in LargeStraight)
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
            if (IsLargeStraight(diceValue))
            {
                return 20;
            }
            return 0;
        } 
    }
}