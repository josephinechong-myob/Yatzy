using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class ChanceStrategy
    {
        public static CategoryType Name => CategoryType.Chance;
        public static int CalculateScore(List<int> diceValues)
        {
            return diceValues.Sum();
        }
    }
}