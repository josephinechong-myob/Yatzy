using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class FullHouseStrategy
    {
        public CategoryType Name => CategoryType.FullHouse;

        public static int CalculateScore(List<int> diceValues)
        {
            var distinctDice = diceValues.Distinct().Count(); // O(N)
            // could do line 12 and line 16 in the same loop, by making a dictionary
            //that has the value as the key, and the count/occurences as the value.
            if (distinctDice == 2)
            {
                var isThereAThree = diceValues.GroupBy(three => three)
                    .Where(d => d.Count() == 3)
                    .ToDictionary(three => 
                        three.Key, occurence => occurence.Count()); // O(N^2)
        
                bool diceValuesHasTriplet = diceValues.GroupBy(value => value).Any(value => value.Count() == 3);
                
                if (isThereAThree.Keys.Count() == 1)
                {
                    return diceValues.Sum();
                }
            }
            return 0;
        }
    }
}