using System.Collections.Generic;

namespace Yatzy
{
    public class PairCategory : ICategory
    {
        public Category Name => Category.Pairs;

        public int CalculateScore(List<int> diceNumbers)
        {
            
            throw new System.NotImplementedException();
        }
    }
}