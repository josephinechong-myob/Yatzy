using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class YatzyStrategy
    {
        public static int CalculateScore(List<int> diceValues)
        {
            var distinctDice = diceValues.Distinct().Count();
            if (distinctDice == 1)
            {
                return 50;  
            }

            return 0;
        }
    }
}