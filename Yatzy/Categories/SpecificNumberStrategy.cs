using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    //public CategoryType Name => CategoryType.FullHouse; <- do I need this for the 6 category types here?
    public class SpecificNumberStrategy // 1s, 2s, 3s, 4s, 5s, 6s
    {
        public static int CalculateScore(CategoryType chosenNumber, List<int> diceValues)
        {
            var pickedNumber = (int)chosenNumber;

            var countPickedNumber = diceValues.Where(p => p == pickedNumber).Count();

            return pickedNumber * countPickedNumber;
        }
    }
}