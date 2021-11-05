using System.Collections.Generic;

namespace Yatzy
{
    public interface ICategory
    {
        CategoryType Name { get; }
        int CalculateScore(List<int> diceValues);
    }
}