using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Category
    {
        public CategoryType CategoryType;
        private SpecificNumberType _specificNumberType;
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

        public void EndRound(List<Die> diceRolled) //not needed as play chooses category after all the rolls
        {
            DiceRolled = diceRolled;
            
        }
        
    }
}