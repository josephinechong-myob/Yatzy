using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class FourOfAKindCatergoryTest
    {
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Four_Of_A_Kind_Dice_If_They_Roll_Four_Of_A_Kind_And_Select_Four_Of_A_Kind_Category_2()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 4, 1};
            var fourOfAKindCatergory = new FourOfAKindCatergory();
            var expectedScore = 16;
          
            //act
            var finalScore = fourOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Four_Of_A_Kind_Dice_If_They_Roll_Four_Of_A_Kind_And_Select_Four_Of_A_Kind_Category_1()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 2, 1};
            var fourOfAKindCatergory = new FourOfAKindCatergory();
            var expectedScore = 0;
          
            //act
            var finalScore = fourOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        
        [Fact]
        private void Four_Of_A_Kind_Value_Should_Be_Sixteen_If_Five_Of_A_Kind_Of_Fours()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 4, 4};
            var fourOfAKindCatergory = new FourOfAKindCatergory();
            var expectedScore = 16;
          
            //act
            var finalScore = fourOfAKindCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
    }
}