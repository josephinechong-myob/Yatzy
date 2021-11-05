using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class FourOfAKindCatergory//: ICategory
    {
        public CategoryType Name => CategoryType.FourOfAKind;
        
        public static int CalculateScore(List<int> diceValues)
        {
            var findFours = diceValues.GroupBy(four => four)
                .Where(diceValue => diceValue.Count() > 3)
                .ToDictionary(four => four.Key, occerence => occerence.Count());

            if (findFours.Keys.Count() == 1)
            {
                return findFours.Keys.FirstOrDefault() * 4;
            }
            return 0;
        }
    }
}