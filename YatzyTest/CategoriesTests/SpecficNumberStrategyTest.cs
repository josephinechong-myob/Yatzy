using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class OneOfAKindStrategyTest
    {
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Dice_Value_They_Choose_For_One_Of_A_Kind()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 2, 1};
            var numberCatergory = SpecificNumberType.Fours;
            var expectedScore = 12;
          
            //act
            var finalScore = SpecificNumberStrategy.CalculateScore(numberCatergory, finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Dice_Value_They_Choose_For_One_Of_A_Kind_2()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 2, 1};
            var numberCatergory = SpecificNumberType.Threes;
            var expectedScore = 0;
          
            //act
            var finalScore = SpecificNumberStrategy.CalculateScore(numberCatergory, finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Sum_Of_The_Dice_Value_They_Choose_For_One_Of_A_Kind_3()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 2, 1};
            var numberCatergory = SpecificNumberType.Twos;
            var expectedScore = 2;
          
            //act
            var finalScore = SpecificNumberStrategy.CalculateScore(numberCatergory, finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
    }
}