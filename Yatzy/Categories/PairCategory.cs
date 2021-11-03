using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class PairCategory : ICategory
    {
        public Category Name => Category.Pairs;

        public int CalculateScore(List<int> diceNumbers)// write theory test to test everything
        { // 5,5,5,5,5
            var findPairs = diceNumbers.GroupBy(pair => pair)
                .Where(dicevalue => dicevalue.Count() == 2)
                .ToDictionary(pair => pair.Key, occurence => occurence.Count());

            var firstPair = findPairs.Keys.OrderByDescending(m => m).FirstOrDefault();
            var firstPairSum = firstPair * 2;
            return firstPairSum;
        }
    }
}