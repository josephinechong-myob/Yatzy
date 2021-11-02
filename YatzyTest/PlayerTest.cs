using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class PlayerTest
    {
        [Fact]
        private void Player_Should_Be_Able_To_Hold_List_The_Dice_Face_Values_They_Want_To_Hold()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var expectedValueToHold = new List<int>{1, 1, 5};
            mockConsole.SetupSequence(m => m.ReadLine()).Returns("1,1,5");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1 = index 0 <-
                .Returns(1) //dice 2 = index 1 
                .Returns(1) //dice 3 = index 2 
                .Returns(5) //dice 4 = index 3 <-
                .Returns(5); //dice 5 = index 4 <-
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            //var gameDice = new List<Die>(); 
            var player = new Player(mockConsole.Object);
            //act
            gameDice.RollDice();
            var valuesToHold = player.ValuesToHold(gameDice.Dice);
            
            
            //assert
            Assert.Equal(valuesToHold, expectedValueToHold);
        }
        
        [Fact]
        private void Player_Should_Not_Be_Able_To_Hold_Invalid_Values()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("a,b,c")
                .Returns("1,1,5");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1 = index 0 <-
                .Returns(1) //dice 2 = index 1 
                .Returns(1) //dice 3 = index 2 
                .Returns(5) //dice 4 = index 3 <-
                .Returns(5); //dice 5 = index 4 <-
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var player = new Player(mockConsole.Object);
           
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
    }
}