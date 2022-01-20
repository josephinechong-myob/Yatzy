using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class PairStrategy
    {
        public static int CalculateScore(List<int> diceValues)
        {
            var findPairs = diceValues.GroupBy(pair => pair)
                .Where(value => value.Count() > 1)
                .ToDictionary(pair => pair.Key, occurence => occurence.Count());

            var firstPair = findPairs.Keys.OrderByDescending(m => m).FirstOrDefault();
            var firstPairSum = firstPair * 2;
            return firstPairSum;
        }
    }
}