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
            var game = new Game(mockConsole.Object);
            var randomNumberGenerator = new RandomNumberGenerator();
            var gamedice = new GameDice(randomNumberGenerator);

            //act
            game.Run();
            
            //assert
            Assert.True(gamedice.Dice.All(die => die.Face == 0));



        }
    }
}