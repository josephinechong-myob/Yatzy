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
            //mockConsole.Verify(m=>m.WriteLine($"{playerName} would you like to play a game? Y - yes or N - no"), Times.Once);

        }
        
        [Fact]
        public void Player_Should_Not_Be_Able_To_Select_Category_Already_Played_In_The_Game()
        {
            //Arrange
            var mockConsole = new Mock<IConsole>();
            var player = new Player(mockConsole.Object, "Gandalf");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(dice => dice.RandomNumber(1, 6))
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1);
            mockConsole.SetupSequence(input => input.ReadLine())
                .Returns("Name")
                .Returns("Y")
                .Returns("N")
                .Returns("1")
                .Returns("Y")
                .Returns("N")
                .Returns("2");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);

            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Please select a category: "), Times.Exactly(2));
            mockConsole.Verify(console=>console.WriteLine("You have chosen Ones category"), Times.Once);
            mockConsole.Verify(console=>console.WriteLine("[1] - Ones"), Times.Once);
            mockConsole.Verify(console=>console.WriteLine("[2] - Threes"), Times.Once);
        }
        
        

        [Fact]
        public void Player_Should_Be_Able_To_Select_Category_In_The_Game()
        {
            //Arrange
            var mockConsole = new Mock<IConsole>();
            var player = new Player(mockConsole.Object, "Gandalf");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(dice => dice.RandomNumber(1, 6))
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1);
            mockConsole.SetupSequence(input => input.ReadLine())
                .Returns("Name")
                .Returns("Y")
                .Returns("N")
                .Returns("15");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);

            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Please select a category: "), Times.Once);
            mockConsole.Verify(console=>console.WriteLine("You have chosen FullHouse category"), Times.Once);
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