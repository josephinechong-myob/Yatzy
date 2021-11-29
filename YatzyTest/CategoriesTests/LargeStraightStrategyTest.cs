using System.Collections.Generic;
using Xunit;
using Yatzy;
using Yatzy.Categories;

namespace YatzyTest.CategoriesTests
{
    public class LargeStraightStrategyTest
    {
        [Fact]
        private void Player_Should_Score_Twenty_If_They_Roll_A_Large_Straight()
        {
            //assign
            var finalDice = new List<int> {2, 3, 4, 5, 6};
            var expectedScore = 20;

            //act
            var finalScore = LargeStraightStrategy.CalculateScore(finalDice);
            
            //assert
            Assert.Equal(expectedScore,finalScore);
        }
    }
}