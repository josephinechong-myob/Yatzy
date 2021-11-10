using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Yatzy
{
    public class FullHouseStrategy
    {
        public CategoryType Name => CategoryType.FullHouse;

        public static int CalculateScore(List<int> diceValues)
        {
            var distinctDice = diceValues.Distinct().Count();
            if (distinctDice == 2)
            {
                var isThereAThree = diceValues.GroupBy(three => three)
                    .Where(d => d.Count() == 3)
                    .ToDictionary(three => three.Key, occurence => occurence.Count());

                if (isThereAThree.Keys.Count() == 1)
                {
                    return diceValues.Sum();
                }
            }
            return 0;
        }
    }
}