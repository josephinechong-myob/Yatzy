using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class FourOfAKindStrategy
    {
        public static CategoryType Name => CategoryType.FourOfAKind;
        
        public static int CalculateScore(List<int> diceValues)
        {
            var findFours = diceValues.GroupBy(four => four)
                .Where(diceValue => diceValue.Count() > 3)
                .ToDictionary(four => four.Key, occurrence => occurrence.Count());

            if (findFours.Keys.Count() == 1)
            {
                return findFours.Keys.FirstOrDefault() * 4;
            }
            return 0;
        }
    }
}