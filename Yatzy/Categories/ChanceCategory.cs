using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ChanceCategory : ICategory
    {
        public Category Name => Category.Chance;
        public int CalculateScore(List<int> diceNumbers)
        {
            return diceNumbers.Sum();
        }
    }
}