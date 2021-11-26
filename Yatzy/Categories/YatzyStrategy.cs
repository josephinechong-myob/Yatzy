using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class YatzyStrategy
    {
        public CategoryType Name => CategoryType.Yatzy;
        
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