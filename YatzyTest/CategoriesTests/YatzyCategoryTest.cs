using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class YatzyCategoryTest
    {
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {new List<int> {1, 1, 1, 1, 1}, 50};
            yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            yield return new object[] {new List<int> {3, 3, 3, 3, 3}, 50};
            yield return new object[] {new List<int> {4, 4, 4, 4, 4}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
            // yield return new object[] {new List<int> {2, 2, 2, 2, 2}, 50};
        }

       
        [Theory]
        [MemberData(nameof(Data))]
        private void Player_Should_Score_Fifty_Points_If_They_Pick_Yatzy_Catergory_And_Roll_All_The_Same_Dice_Number(List<int> finalDice, int expectedScore)
        {
            //assign
            //act
            var finalScore = YatzyStrategy.CalculateScore(finalDice);

            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Player_Should_Score_Zero_Points_If_They_Pick_Yatzy_Catergory_And_Does_Not_Roll_All_The_Same_Dice_Number()
        {
            //assign
            var finalDice = new List<int>{2, 1, 1, 3, 1};

            //act
            var finalScore = YatzyStrategy.CalculateScore(finalDice);

            //assert
            Assert.Equal(0, finalScore);
        }
    }
}