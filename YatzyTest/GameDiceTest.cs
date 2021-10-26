using System.Collections.Generic;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameDiceTest
    {
        [Fact]
        public void New_Game_Dice_Should_Have_Five_Dice()
        {
            //arrange
            //act
            var randomNumberGenerator = new RandomNumberGenerator();
            var gameDice = new GameDice(randomNumberGenerator);
            
            //assert
            Assert.Equal(5, gameDice.Dice.Count);
        }

        [Fact]
        public void RollDice_Should_Roll_All_Five_Dice()
        {
            //arrange
            var randomNumberGenerator = new RandomNumberGenerator();
            var gameDice = new GameDice(randomNumberGenerator);
            
            //act
            gameDice.RollDice();
            var dice = gameDice.Dice;
            var rolledDice = dice.TrueForAll(m => m.Face > 0 && m.Face < 6);
            
            //assert
            Assert.True(rolledDice);
        }

        [Fact]
        private void Player_Should_Be_Able_To_Hold_Selected_Dice()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(1)
                .Returns(3)
                .Returns(1)
                .Returns(5);
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var mockPlayerHeldList = new List<int>() {1};
            
            //act
            gameDice.RollDice();
            gameDice.HoldDice(mockPlayerHeldList);
            
            //assert
            var firstHeldDie = gameDice.Dice[0].IsHeld();
            var secondHeldDie = gameDice.Dice[1].IsHeld();
            var thirdHeldDie = gameDice.Dice[3].IsHeld();
            var firstNonHeldDie = gameDice.Dice[2].IsHeld();
            var secondNonHeldDie = gameDice.Dice[4].IsHeld();
            Assert.True(firstHeldDie);
            Assert.True(secondHeldDie);
            Assert.True(thirdHeldDie);
            Assert.False(firstNonHeldDie);
            Assert.False(secondNonHeldDie);
        }

        //test for player holding numbers 
        [Fact]
        public void HeldDice_Should_Not_Be_Rolled()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock <IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(3)
                .Returns(3)
                .Returns(2)
                .Returns(5);
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            
            //act
            gameDice.RollDice();
            var allDice = gameDice.Dice; //list of held dice (everything all 5)
           // var selectedDiceForHolding = gameDice.Held; //create new list for dice to hold
            var HeldNumbers = new List<Die>() //removing the 3 from all Dice the number in the held number list
            {
                //new Die(m)
            };
            
                //assert
               
        }
    }
}