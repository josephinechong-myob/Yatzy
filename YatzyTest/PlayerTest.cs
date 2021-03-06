using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class PlayerTest
    {
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
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
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
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
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
    }
}