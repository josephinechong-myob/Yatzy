using System;
using System.Linq;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameTest
    {
        [Fact]
        public void Player_Should_Be_Able_To_Answer_No_For_Playing_Option()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns("Dumbledore")
                .Returns("N");
            var game = CreateGame(mockConsole);

            //act
            game.Run();
            
            //assert
            Assert.True(game._gamedice.Dice.All(die => die.Face == 0));
        }
        
        [Fact]
        public void Player_Should_Be_Greeted_By_The_Game()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerName = "Dumbledore";
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerName)
                .Returns("N");
            var game = CreateGame(mockConsole);

            //act
            game.Run();
            
            //assert
            mockConsole.Verify(m => m.WriteLine("Welcome to Yatzy. \nWhat is your name?"), Times.Once());
            mockConsole.Verify(m=>m.WriteLine($"{playerName} would you like to play a game? Y - yes or N - no"), Times.Once);

        }

        private Game CreateGame(Mock<IConsole> mockConsole, IRandomNumberGenerator randomNumberGenerator=null)
        {
            if (randomNumberGenerator == null)
            {
                randomNumberGenerator = new RandomNumberGenerator(); 
            }
            var game = new Game(mockConsole.Object, randomNumberGenerator);
            return game;
        }
    }
}