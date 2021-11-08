using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class ChanceCatergoryTest
    {
        [Fact]
        private void Player_Should_Score_The_Sum_Of_The_Dice_Numbers_They_Roll_If_They_Pick_Chance_Catergory()
        {
            //assign
            var finalDice = new List<int> {1, 2, 2, 5, 4}; //plugin for auto formatting when you save
            var expectedSumOfDice = 14;

            //act
            //var finalSumOfDice = chanceCategory.CalculateScore(finalDice);
            var finalSumOfDice = ChanceStrategy.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedSumOfDice, finalSumOfDice);
        }
        //both below could be for validation class
        //empty list and choose a category?
        //would I need a test to validate input?
    }
}