using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class YatzyCategory : ICategory
    {
        public CategoryType Name => CategoryType.Yatzy;
        
        public int CalculateScore(List<int> diceValues)
        {
            var distinctDice = diceValues.Distinct().Count();
            if (distinctDice == 1)
            {
                return 50;  
            }

            return 0;
        }
    }
}