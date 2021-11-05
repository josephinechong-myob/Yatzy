using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class TwoPairsCategoryTest
    {
        [Fact]
        private void Player_Should_Score_The_Sum_Of_The_Two_Pairs_They_Roll_If_They_Pick_Two_Pairs_Category()
        {
            //assign
            var finalDice = new List<int> {4, 4, 2, 2, 1};
            var twoPairsCatergory = new TwoPairsCategory();
            var expectedScore = 12;
          
            //act
            var finalScore = twoPairsCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_The_Sum_Of_The_Two_Pairs_They_Roll_If_They_Pick_Two_Pairs_Category_Fours()
        {
            //assign
            var finalDice = new List<int> {4, 4, 4, 4, 1};
            var twoPairsCatergory = new TwoPairsCategory();
            var expectedScore = 16;
          
            //act
            var finalScore = twoPairsCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_If_They_Roll_One_Pair_And_Pick_Two_Pairs_Category()
        {
            //assign
            var finalDice = new List<int> {4, 4, 3, 6, 1};
            var twoPairsCatergory = new TwoPairsCategory();
            var expectedScore = 0;
          
            //act
            var finalScore = twoPairsCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_If_They_Roll_And_Have_No_Pairs_While_Selecting_Two_Pairs_Category()
        {
            //assign
            var finalDice = new List<int> {4, 5, 3, 6, 1};
            var twoPairsCatergory = new TwoPairsCategory();
            var expectedScore = 0;
          
            //act
            var finalScore = twoPairsCatergory.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
    }
}