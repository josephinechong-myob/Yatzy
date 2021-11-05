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
//                    var fourOfAKind = new FourOfAKindCatergory();//swap caterory to stratergy 
                    return FourOfAKindCatergory.CalculateScore(diceValues);
                
            }
            
            return 0; // throw catergory not chosen 
        }
    }
}