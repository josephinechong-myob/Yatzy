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
        public void Player_Should_Be_Able_To_Reset_Game_Once_Max_Number_Of_Categories_Have_been_Played()
        {
           //Arrange
            var mockConsole = new Mock<IConsole>();
            var player = new Player(mockConsole.Object, "Gandalf");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(dice => dice.RandomNumber(1, 6))
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1);
            mockConsole.SetupSequence(input => input.ReadLine())
                .Returns(player.Name)
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("1")
                .Returns("Y")//cont game
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 2
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 3
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 4
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 5
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 6
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 7
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 8
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 9
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y") //edit
                .Returns("N")
                .Returns("N")
                .Returns("2")
                .Returns("N");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
        
            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Congratulations on finishing your Yatzy game. Here are the results: "), Times.Exactly(1));
            mockConsole.Verify(c => c.WriteLine("Gandalf's final score is 30. "), Times.Exactly(1));
            mockConsole.Verify(console => console.WriteLine("[10] - FullHouse"), Times.Exactly(2));
        }
        
        [Fact]
        public void Player_Should_See_Their_Final_Score_And_Congratulations_Greeting_After_They_Have_Fished_All_Categories()
        {
            //Arrange
            var mockConsole = new Mock<IConsole>();
            var player = new Player(mockConsole.Object, "Gandalf");
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(dice => dice.RandomNumber(1, 6))
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1)
                .Returns(1) //3 + 4 + 6 +3+ 0+ 0+7+0+0+7
                .Returns(2)
                .Returns(1)
                .Returns(2)
                .Returns(1);
            mockConsole.SetupSequence(input => input.ReadLine())
                .Returns(player.Name)
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("1")
                .Returns("Y")//cont game
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 2
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 3
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 4
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 5
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 6
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 7
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 8
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("Y")//cont game 9
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("N");
            var gameDice = new GameDice(mockRandomNumberGenerator.Object, mockConsole.Object);
            var game = new Game(mockConsole.Object, mockRandomNumberGenerator.Object);
        
            //Act
            game.Run();
            
            //Assert
            mockConsole.Verify(c => c.WriteLine("Congratulations on finishing your Yatzy game. Here are the results: "), Times.Exactly(1));
            mockConsole.Verify(c => c.WriteLine("Gandalf's final score is 30. "), Times.Exactly(1));
            mockConsole.Verify(c => c.WriteLine("our total score is 30. Would you like to continue playing? Y - Yes, N - No"), Times.Never);
        }
        
        
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
                .Returns("N")
                .Returns("N")
                .Returns("1")
                .Returns("1")
                .Returns("Y")
                .Returns("N")
                .Returns("N")
                .Returns("2")
                .Returns("N");
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
        
        // [Fact] //Might not need this test as the game play has changed
        // public void Player_Should_Be_Able_To_Answer_No_For_Playing_Option()
        // {
        //     //assign
        //     var mockConsole = new Mock<IConsole>();
        //     var playerName = "Dumbledore";
        //     mockConsole.SetupSequence(m => m.ReadLine())
        //         .Returns(playerName)
        //         .Returns("N")
        //         .Returns("N")
        //         .Returns("10")
        //         .Returns("N");
        //     var game = CreateGame(mockConsole);
        //
        //     //act
        //     game.Run();
        //     
        //     //assert
        //     Assert.True(game.GameDice.Dice.All(die => die.Face == 0));
        // }
        
        
        [Fact]
        public void Player_Should_Be_Greeted_By_The_Game()
        {
            //assign
            var mockConsole = new Mock<IConsole>();
            var playerName = "Dumbledore";
            mockConsole.SetupSequence(m => m.ReadLine())
                .Returns(playerName)
                .Returns("N")
                .Returns("N")
                .Returns("10")
                .Returns("N");
            var game = CreateGame(mockConsole);

            //act
            game.Run();
            
            //assert
            mockConsole.Verify(m => m.WriteLine("Welcome to Yatzy. \nWhat is your name?"), Times.Once());
            //mockConsole.Verify(m=>m.WriteLine($"{playerName} would you like to play a game? Y - yes or N - no"), Times.Once);

        }
        
        [Fact] //bug fixed here
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
                .Returns("N") //hold
                .Returns("N") //roll
                .Returns("1") //cat
                .Returns("1") // specifc number 1
                .Returns("Y") //cont play
                .Returns("N") //hold
                .Returns("N") //roll
                .Returns("2")
                .Returns("N");
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
                .Returns("N")
                .Returns("N")
                .Returns("10")
                .Returns("N");
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