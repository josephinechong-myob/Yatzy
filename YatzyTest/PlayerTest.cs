using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class PlayerTest
    {
        //test for None - for values to hold
        [Fact]
        private void Player_Should_Be_Able_To_List_The_Dice_Face_Values_They_Want_To_Hold() //can hold dice
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var expectedValueToHold = new List<int>{1, 1, 5};
            mockConsole.SetupSequence(m => m.ReadLine()).Returns("1,1,5");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(1)
                .Returns(1)
                .Returns(5)
                .Returns(5);
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var player = new Player(mockConsole.Object, "player");
            //act
            gameDice.RollDice();
            var valuesToHold = player.ValuesToHold(gameDice.Dice);
            
            
            //assert
            Assert.Equal(valuesToHold, expectedValueToHold);
        }
        
        [Fact]
        private void Player_Should_Not_Be_Able_To_Hold_Invalid_Values() //cannot cheat by using values that are not in their hand
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("a,b,c")
                .Returns("1,1,5");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) 
                .Returns(1) 
                .Returns(1) 
                .Returns(5) 
                .Returns(5);
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var player = new Player(mockConsole.Object, "player");
           
            //act
            gameDice.RollDice();
            var valuesToHold = player.ValuesToHold(gameDice.Dice);
            
            //assert
            mockConsole.Verify(
                m=>m.WriteLine(
                    It.Is<string>(s=>s==$"Please list all the numbers you would like to hold separated by comma ','. For example if you would to hold the same number twice please write it twice when listing. ")
                ), Times.Exactly(2)
            );
        }

        [Fact]
        private void Player_Should_Be_Able_To_Choose_Category()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) 
                .Returns(1) 
                .Returns(1) 
                .Returns(1) 
                .Returns(1);
            var player = new Player(mockConsole.Object, "player");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var chosenCategory = new Category(CategoryType.Yatzy, gameDice.Dice);
            var expectedScore = 50;

            //act
            player.ChooseCategory(chosenCategory);
            gameDice.RollDice();

            //assert
            Assert.Equal(expectedScore, player.Score);
        }
        
        [Fact]
        private void Player_Should_Be_Able_To_Choose_Category_2()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(2) 
                .Returns(2) 
                .Returns(1) 
                .Returns(1) 
                .Returns(1);
            var player = new Player(mockConsole.Object, "player");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var chosenCategory = new Category(CategoryType.FullHouse, gameDice.Dice);
            var expectedScore = 7;

            //act
            player.ChooseCategory(chosenCategory);
            gameDice.RollDice();

            //assert
            Assert.Equal(expectedScore, player.Score);
        }
        
        [Fact]
        private void Count_Of_Category_Types_Remaining_Should_Reduce_By_One_When_One_Category_Is_Played()
        {
            //arrange
            var mockConsole = new Mock<IConsole>();
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(2) 
                .Returns(2) 
                .Returns(1) 
                .Returns(1) 
                .Returns(1);
            var player = new Player(mockConsole.Object, "player");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var chosenCategory = new Category(CategoryType.FullHouse, gameDice.Dice);
            var expectedCategoryTypesRemaining = 14;

            //act
            player.ChooseCategory(chosenCategory);
            gameDice.RollDice();
            var actualCategoryTypesRemaining = player.CategoryTypeRemaining.Count;

            //assert
            Assert.Equal(expectedCategoryTypesRemaining, actualCategoryTypesRemaining);
        }
    }
}