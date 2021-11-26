using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class SpecificNumberStrategy // 1s, 2s, 3s, 4s, 5s, 6s
    {
        public static int CalculateScore(SpecificNumberType chosenNumber, List<int> diceValues)
        {
            var pickedNumber = (int)chosenNumber;

            var countPickedNumber = diceValues.Where(p => p == pickedNumber).Count();

            return pickedNumber * countPickedNumber;
        }
    }
}