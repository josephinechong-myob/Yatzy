using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class ThreeOfAKindCategoryTest
    {
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Three_Of_A_Kind_Dice_If_They_Roll_Three_Of_A_Kind_And_Select_Three_Of_A_Kind_Category()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 6, 1};
            var threeOfAKindCatergory = new ThreeOfAKindCatergory();
            var expectedScore = 12;
          
            //act
            var finalScore = threeOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Three_Of_A_Kind_Dice_If_They_Roll_Three_Of_A_Kind_And_Select_Three_Of_A_Kind_Category_2()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 4, 4};
            var threeOfAKindCatergory = new ThreeOfAKindCatergory();
            var expectedScore = 12;
          
            //act
            var finalScore = threeOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_If_They_Roll_Numbers_That_Do_Not_Contain_Three_Of_A_Kind_And_Select_Three_Of_A_Kind_Category()
        {
            //assign
            var finalDice = new List<int> {4, 4, 2, 6, 1};
            var threeOfAKindCatergory = new ThreeOfAKindCatergory();
            var expectedScore = 0;
          
            //act
            var finalScore = threeOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
    }
}