using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class TwoPairsCategory : ICategory
    {
        public Category Name => Category.TwoPairs;
        
        public int CalculateScore(List<int> diceNumbers)
        {
            var findPairs = diceNumbers.GroupBy(pair => pair)
                .Where(diceValue => diceValue.Count() == 2)
                .ToDictionary(pair => pair.Key, occurence => occurence.Count());

            var findFours = diceNumbers.GroupBy(four => four)
                .Where(diceValue => diceValue.Count() == 4)
                .ToDictionary(four => four.Key, occurence => occurence.Count());
            var sum = 0;
            
            if (findPairs.Keys.Count() == 2)
            {
                //var firstPair = findPairs.ElementAt(0).Key; //1 2
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