using System.Collections.Generic;
using System.Linq;

namespace Yatzy.Categories
{
    public class Category
    {
        public readonly CategoryType CategoryType;
        private readonly SpecificNumberType _specificNumberType;
        public int Score => CalculateScore();
        public List<Die> DiceRolled { get; private set; }

        public Category(CategoryType categoryType, List<Die> diceRolled)
        {
            CategoryType = categoryType;
            DiceRolled = diceRolled;
        }

        public Category(SpecificNumberType specificNumberType, List<Die> diceRolled)
        {
            CategoryType = CategoryType.SpecificNumber;
            _specificNumberType = specificNumberType;
            DiceRolled = diceRolled;
        }
        
        public int CalculateScore()
        {
            if(DiceRolled.Count == 0) return 0;
            var categoryContext = CategoryType == CategoryType.SpecificNumber ? new CategoryContext(_specificNumberType) : new CategoryContext(CategoryType);
            var diceValues = DiceRolled.Select(die => die.Face).ToList();
            return categoryContext.CalculateScore(diceValues);
        }
    }
}