using System.Collections.Generic;

namespace Yatzy
{
    public interface ICategory
    {
        Category Name { get; }
        int CalculateScore(List<int> diceValues);
    }
}