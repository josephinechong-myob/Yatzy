using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class FullHouseStrategyTest
    {
        [Fact]
        private void Player_Should_Score_Twenty_If_They_Roll_A_Big_Straight()
        {
           // assign
            var finalDice = new List<int> {2, 2, 1, 1, 1};
            var expectedScore = 7;

           // act
            var finalScore = FullHouseStrategy.CalculateScore(finalDice);
            
           // assert
            Assert.Equal(expectedScore,finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_If_They_Do_Not_Roll_A_Big_Straight()
        {
            // assign
            var finalDice = new List<int> {2, 1, 1, 1, 1};
            var expectedScore = 0;

            // act
            var finalScore = FullHouseStrategy.CalculateScore(finalDice);
            
            // assert
            Assert.Equal(expectedScore,finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_If_They_Do_Not_Roll_A_Big_Straight2()
        {
            // assign
            var finalDice = new List<int> {1, 1, 1, 1, 1};
            var expectedScore = 0;

            // act
            var finalScore = FullHouseStrategy.CalculateScore(finalDice);
            
            // assert
            Assert.Equal(expectedScore,finalScore);
        }
    }
}