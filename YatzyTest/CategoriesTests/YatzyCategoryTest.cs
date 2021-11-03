using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class YatzyCategoryTest
    {
        [Fact]
        private void Player_Should_Score_Fifty_Points_If_They_Pick_Yatzy_Catergory_And_Roll_All_The_Same_Dice_Number()
        {
            //assign
            var finalDice = new List<int>{1, 1, 1, 1, 1};
            var yatzyCatergory = new YatzyCategory();

            //act
            var finalScore = yatzyCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(50, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_Points_If_They_Pick_Yatzy_Catergory_And_Does_Not_Roll_All_The_Same_Dice_Number()
        {
            //assign
            var finalDice = new List<int>{2, 1, 1, 3, 1};
            var yatzyCatergory = new YatzyCategory();

            //act
            var finalScore = yatzyCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(0, finalScore);
        }
    }
}