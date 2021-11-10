using System.Collections.Generic;

namespace Yatzy
{
    public class CategoryContext
    {
        private CategoryType _categoryType;
        
        public CategoryContext(CategoryType categoryType)
        {
            _categoryType = categoryType;
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
                
                case CategoryType.Ones:
                case CategoryType.Twos: //not nested but doable - shared switch case ** brown bag
                case CategoryType.Threes:
                case CategoryType.Fours:
                case CategoryType.Fives:
                case CategoryType.Sixes:
                    return SpecificNumberStrategy.CalculateScore(_categoryType, diceValues);
                
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