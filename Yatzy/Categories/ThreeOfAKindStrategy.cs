using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class ThreeOfAKindStrategy
    {
        public CategoryType Name => CategoryType.ThreeOfAKind;
        
        public static int CalculateScore(List<int> diceValues)
        {
            var findThrees = diceValues.GroupBy(three => three)
                .Where(diceValue => diceValue.Count() > 2)
                .ToDictionary(three => three.Key, occurence => occurence.Count());

            if (findThrees.Keys.Count() == 1)
            {
                return findThrees.Keys.FirstOrDefault() * 3;
            }

            return 0;
        }
    }
}