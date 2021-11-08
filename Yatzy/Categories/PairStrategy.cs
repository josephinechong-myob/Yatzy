using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class PairStrategy
    {
        public CategoryType Name => CategoryType.Pairs;

        public static int CalculateScore(List<int> diceValues)// write theory test to test everything
        { // 5,5,5,5,5
            var findPairs = diceValues.GroupBy(pair => pair)
                .Where(dicevalue => dicevalue.Count() > 1)
                .ToDictionary(pair => pair.Key, occurence => occurence.Count());

            var firstPair = findPairs.Keys.OrderByDescending(m => m).FirstOrDefault();
            var firstPairSum = firstPair * 2;
            return firstPairSum;
        }
    }
}