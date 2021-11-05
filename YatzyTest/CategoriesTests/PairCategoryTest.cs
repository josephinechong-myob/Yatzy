using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class PairCategoryTest
    {
        [Fact] //Inline data theory testing to test a bunch of pairs in this method
        private void Player_Should_Score_The_Sum_Of_The_Two_Highest_Matching_Dice_Numbers_They_Roll_If_They_Pick_Pair_Category()
        {
          //assign
          var finalDice = new List<int> {4, 4, 2, 2, 1};
          var pairCatergory = new PairCategory();
          var expectedScore = 8;
          
          //act
          var finalScore = pairCatergory.CalculateScore(finalDice);

          //assert
          Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_The_Sum_Of_The_Two_Highest_Matching_Dice_Numbers_They_Roll_If_They_Pick_Pair_Category_2()
        {
            //assign
            var finalDice = new List<int> {1, 1, 2, 2, 5};
            var pairCatergory = new PairCategory();
            var expectedScore = 4;
          
            //act
            var finalScore = pairCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        //Do another test for zero score if there are no pairs
    }
}