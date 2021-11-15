using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest.CategoriesTests
{
    public class CategoryTest //write test if face is zero it cannot win for specific category - or do you change the dice to return null if 0?
    {
        /*[Fact]
        private void Category_Should_Be_Able_To_Know_Score_Once_Roll_Has_Ended()
        {
            //assign
            var categoryType = CategoryType.Yatzy;
            var category = new Category(categoryType);
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(1)
                .Returns(1)
                .Returns(1)
                .Returns(1);
            var dice1 = new Die(mockRandomNumberGenerator.Object);
            var dice2 = new Die(mockRandomNumberGenerator.Object);
            var dice3 = new Die(mockRandomNumberGenerator.Object);
            var dice4 = new Die(mockRandomNumberGenerator.Object);
            var dice5 = new Die(mockRandomNumberGenerator.Object);
            var diceRolled = new List<Die> {dice1, dice2, dice3, dice4, dice5};
          
            var expectedScore = 50;

            //act
            foreach (var dice in diceRolled)
            {
                dice.Roll();
            }
            category.EndRound(diceRolled);
            var finalScore = category.Score;
            
            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        
        [Fact]
        private void Category_Should_Be_Able_To_Know_Score_Once_Roll_Has_Ended_2()
        {
            //assign
            var categoryType = CategoryType.Yatzy;
            var category = new Category(categoryType);
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(2)
                .Returns(3)
                .Returns(4)
                .Returns(5);
            var dice1 = new Die(mockRandomNumberGenerator.Object);
            var dice2 = new Die(mockRandomNumberGenerator.Object);
            var dice3 = new Die(mockRandomNumberGenerator.Object);
            var dice4 = new Die(mockRandomNumberGenerator.Object);
            var dice5 = new Die(mockRandomNumberGenerator.Object);
            var diceRolled = new List<Die>{dice1, dice2, dice3, dice4, dice5};
            var expectedScore = 0;

            //act
            foreach (var dice in diceRolled)
            {
                dice.Roll();
            }
            category.EndRound(diceRolled);
            var finalScore = category.Score;
            
            //assert
            Assert.Equal(expectedScore, finalScore);
        }
        */
    }
}