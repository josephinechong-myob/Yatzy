using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class SmallStraightStrategyTest
    {
        [Fact]
        private void Player_Should_Score_fifteen_If_They_Roll_A_Small_Straight()
        {
            //assign
            var finalDice = new List<int> {1, 2, 3, 4, 5};
            var expectedScore = 15;

            //act
            var finalScore = SmallStraightStrategy.CalculateScore(finalDice);
            
            //assert
            Assert.Equal(expectedScore,finalScore);
        }
        [Fact]
        private void Player2_Should_Score_fifteen_If_They_Roll_A_Small_Straight()
        {
            //assign
            var finalDice = new List<int> {4, 1, 5, 2, 3};
            var expectedScore = 15;

            //act
            var finalScore = SmallStraightStrategy.CalculateScore(finalDice);
            
            //assert
            Assert.Equal(expectedScore,finalScore);
        }
        [Fact]
        private void Player_Should_Score_Zero_If_They_Do_Not_Roll_A_Small_Straight()
        {
            //assign
            var finalDice = new List<int> {4, 1, 1, 2, 3};
            var expectedScore = 0;

            //act
            var finalScore = SmallStraightStrategy.CalculateScore(finalDice);
            
            //assert
            Assert.Equal(expectedScore,finalScore);
        }
    }
}