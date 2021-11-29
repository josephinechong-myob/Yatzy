using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class ChanceStrategy
    {
        public CategoryType Name => CategoryType.Chance;
        public static int CalculateScore(List<int> diceValues)
        {
            return diceValues.Sum();
        }
    }
}