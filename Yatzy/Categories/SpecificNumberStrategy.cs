using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public static class SpecificNumberStrategy
    {
        public static int CalculateScore(SpecificNumberType chosenNumber, List<int> diceValues)
        {
            var pickedNumber = (int)chosenNumber;

            var countPickedNumber = diceValues.Count(p => p == pickedNumber);

            return pickedNumber * countPickedNumber;
        }
    }
}