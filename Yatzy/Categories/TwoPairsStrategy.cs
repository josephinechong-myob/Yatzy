using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class TwoPairsStrategy 
    {
        public static CategoryType Name => CategoryType.TwoPairs;
        
        public static int CalculateScore(List<int> diceValues)
        {
            var findPairs = diceValues.GroupBy(pair => pair)
                .Where(diceValue => diceValue.Count() > 1)
                .ToDictionary(pair => pair.Key, occurence => occurence.Count());

            var findFours = diceValues.GroupBy(four => four)
                .Where(diceValue => diceValue.Count() > 3)
                .ToDictionary(four => four.Key, occurence => occurence.Count());
            var sum = 0;
            
            if (findPairs.Keys.Count() == 2)
            {
                foreach (var pair in findPairs)
                {
                    sum += pair.Key * 2;
                }
            }
            else if (findFours.Keys.Count() == 1)
            {
                sum = findFours.Keys.FirstOrDefault() * 4;
            }
            
            return sum;
        }
    }
}