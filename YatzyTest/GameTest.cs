using System;
using System.Linq;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameTest
    {
        // [Fact]
        // public void Player_Should_See_Their_Final_Score_And_Congratulations_Greeting_After_They_Have_Fished_All_Categories()
        // {
        //     //Arrange
        //     var mockConsole = new Mock<IConsole>();
        //     var player = new Player(mockConsole.Object, "Gandalf");
        //     var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
        //     mockRandomNumberGenerator.SetupSequence(dice => dice.RandomNumber(1, 6))
        //         .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
        //         .Returns(2)
        //         .Returns(1)
        //         .Returns(2)
        //         .Returns(1);
        //     mockConsole.SetupSequence(input => input.ReadLine())
        //         .Returns("Name")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1")
        //         .Returns("Y")
        //         .Returns("N")
        //         .Returns("1");
        //     var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
        //     var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
        //
        //     //Act
        //     game.Run();
        //     
        //     //Assert
        //     mockConsole.Verify(c => c.WriteLine("Congratulations on finishing the Yatzy game, your final score is 30"), Times.Exactly(1));
        // }
        
        //
        [Fact]
        public void Player_Should_Be_Able_To_Select_Number_For_Specific_Number_Type_Category()
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
                .Returns("1")
                .Returns("Y")
                .Returns("N")
                .Returns("2");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);

            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Please select a category below:"), Times.Exactly(2));
            mockConsole.Verify(c=>c.WriteLine("You have chosen SpecificNumber category"), Times.Once);
            mockConsole.Verify(c=>c.WriteLine("[1] - SpecificNumber"), Times.Once);
            mockConsole.Verify(c=>c.WriteLine("[2] - Pairs"), Times.Once);
            mockConsole.Verify(c=>c.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number"), Times.Once);
        }
        
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
            Assert.True(game.GameDice.Dice.All(die => die.Face == 0));
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
                .Returns("1")
                .Returns("Y")
                .Returns("N")
                .Returns("2");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);

            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Please select a category below:"), Times.Exactly(2));
            mockConsole.Verify(console=>console.WriteLine("You have chosen SpecificNumber category"), Times.Once);
            mockConsole.Verify(console=>console.WriteLine("[1] - SpecificNumber"), Times.Once);
            mockConsole.Verify(console=>console.WriteLine("[2] - Pairs"), Times.Once);
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
                .Returns("10");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);

            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Please select a category below:"), Times.Once);
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