using System.Collections.Generic;

namespace Yatzy.Categories
{
    public class CategoryContext
    {
        private readonly CategoryType _categoryType;
        private readonly SpecificNumberType _specificNumberType;

        public CategoryContext(CategoryType categoryType)
        {
            _categoryType = categoryType;
        }

        public CategoryContext(SpecificNumberType specificNumberType)
        {
            _specificNumberType = specificNumberType;
            _categoryType = CategoryType.SpecificNumber;
        }

        public int CalculateScore(List<int> diceValues)
        {
            switch(_categoryType)
            {
                case CategoryType.FourOfAKind:
                    return FourOfAKindStrategy.CalculateScore(diceValues);
                
                case CategoryType.Chance:
                    return ChanceStrategy.CalculateScore(diceValues);
                
                case CategoryType.Yatzy:
                    return YatzyStrategy.CalculateScore(diceValues);
                
                case CategoryType.Pairs:
                    return PairStrategy.CalculateScore(diceValues);
                
                case CategoryType.TwoPairs:
                    return TwoPairsStrategy.CalculateScore(diceValues);
                
                case CategoryType.ThreeOfAKind:
                    return ThreeOfAKindStrategy.CalculateScore(diceValues);
                
                case CategoryType.SpecificNumber:
                    return SpecificNumberStrategy.CalculateScore(_specificNumberType, diceValues);
                
                case CategoryType.SmallStraight:
                    return SmallStraightStrategy.CalculateScore(diceValues);
                
                case CategoryType.LargeStraight:
                    return LargeStraightStrategy.CalculateScore(diceValues);
                
                case CategoryType.FullHouse:
                    return FullHouseStrategy.CalculateScore(diceValues);
            }
            
            return 0; // throw catergory not chosen 
        }
    }
}