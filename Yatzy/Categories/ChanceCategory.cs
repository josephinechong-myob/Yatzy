using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ChanceCategory : ICategory
    {
        public CategoryType Name => CategoryType.Chance;
        public int CalculateScore(List<int> diceValues)
        {
            return diceValues.Sum();
        }
    }
}