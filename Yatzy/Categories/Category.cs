using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Category
    {
        public readonly CategoryType CategoryType;
        public int Score => CalculateScore();
        public List<Die> DiceRolled { get; private set; }

        public Category(CategoryType categoryType)
        {
            CategoryType = categoryType;
            DiceRolled = new List<Die>();
        }

        private int CalculateScore()
        {
            if(DiceRolled.Count == 0) return 0;
            var categoryContext = new CategoryContext(CategoryType);
            var diceValues = DiceRolled.Select(die => die.Face).ToList();
            return categoryContext.CalculateScore(diceValues);
        }

        public void EndRound(List<Die> diceRolled)
        {
            DiceRolled = diceRolled;
            
        }
        
    }
}