using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class YatzyCategoryTest
    {
        [Fact]
        private void If_Player_Wins_Yatzy_Category_They_Should_Score_Fifty_Points()
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
        private void If_Player_Does_Not_Win_Yatzy_Category_They_Should_Score_Zero_Points()
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