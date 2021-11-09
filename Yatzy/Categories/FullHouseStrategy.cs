using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class FullHouseStrategy
    {
        public CategoryType Name => CategoryType.FullHouse;
        //full house is 3 of a kind and pairs - am I able to use those functions?
        
        // public static int CalculateScore(List<int> diceValues)
        // {
        //     var distinctDice = diceValues.Distinct().Count();
        //     if (distinctDice == 2)
        //     {
        //         return 50;  
        //     }
        //     
        //     var findThrees = diceValues.GroupBy(three => three)
        //         .Where(diceValue => diceValue.Count() > 2)
        //         .ToDictionary(three => three.Key, occurence => occurence.Count());
        //
        //     if (findThrees.Keys.Count() == 1)
        //     {
        //         return findThrees.Keys.FirstOrDefault() * 3;
        //     }
        //
        //     return 0;
        // }
        //
        // var findPairs = diceValues.GroupBy(pair => pair)
        //     .Where(dicevalue => dicevalue.Count() > 1)
        //     .ToDictionary(pair => pair.Key, occurence => occurence.Count());
        //
        // var firstPair = findPairs.Keys.OrderByDescending(m => m).FirstOrDefault();
        // var firstPairSum = firstPair * 2;
        //     return firstPairSum;
        
    }
}