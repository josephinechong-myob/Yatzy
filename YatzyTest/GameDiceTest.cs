using System;
using System.Collections.Generic;
using System.Linq;
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
                .Returns(1) //gameDice.Dice[0]
                .Returns(1) //gameDice.Dice[1]
                .Returns(3) //gameDice.Dice[2]
                .Returns(1) //gameDice.Dice[3]
                .Returns(5); //gameDice.Dice[4]
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var mockPlayerHeldList = new List<int>() {0, 1, 3}; //Holding based on dice index
            
            //act
            gameDice.RollDice();
            gameDice.HoldDice(mockPlayerHeldList);
            
            //assert
            Assert.True(gameDice.Dice[0].IsHeld());
            Assert.True(gameDice.Dice[1].IsHeld());
            Assert.True(gameDice.Dice[3].IsHeld());
            Assert.False(gameDice.Dice[2].IsHeld());
            Assert.False(gameDice.Dice[4].IsHeld());
        }
        
        [Fact]
        public void HeldDice_Should_Not_Be_Rolled()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1)
                .Returns(1)
                .Returns(3)
                .Returns(1)
                .Returns(5)
                .Returns(2)
                .Returns(4);

            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var mockPlayerHeldList = new List<int>() {1};
            
            //act
            gameDice.RollDice();
            var diceAfterFirstRoll = gameDice.Dice.Select(d => d.Face).ToList();
            
            gameDice.HoldDice(mockPlayerHeldList);
            
            gameDice.RollDice();
            var diceAfterSecondRoll = gameDice.Dice;

            //assert
            Dice_Should_Reroll_Unless_Held(diceAfterFirstRoll, diceAfterSecondRoll);
        }
        
        [Fact]
        public void Player_Should_Be_Able_To_Select_Specific_Amount_Of_The_Same_Face_Number_To_Be_Held()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1
                .Returns(1) //dice 2
                .Returns(3) //dice 3
                .Returns(1) //dice 4
                .Returns(5) //dice 5
                .Returns(2) //re roll for dice 4
                .Returns(4); //re roll for dice 5

            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var mockPlayerHeldList = new List<int>() {0, 1, 2}; //Dice index
            
            //act
            gameDice.RollDice();
            var diceAfterFirstRoll = gameDice.Dice.Select(d => d.Face).ToList();
            
            gameDice.HoldDice(mockPlayerHeldList);
            
            gameDice.RollDice();
            var diceAfterSecondRoll = gameDice.Dice;
            
            //assert
            Assert.True(gameDice.Dice[0].IsHeld());
            Assert.True(gameDice.Dice[1].IsHeld());
            Assert.True(gameDice.Dice[2].IsHeld());
            Assert.False(gameDice.Dice[3].IsHeld());
            Assert.False(gameDice.Dice[4].IsHeld());

            Dice_Should_Reroll_Unless_Held(diceAfterFirstRoll, diceAfterSecondRoll);

        }

        private void Dice_Should_Reroll_Unless_Held(List<int> diceAfterFirstRoll, List<Die> diceAfterSecondRoll)
        {
            for (var i = 0; i < diceAfterFirstRoll.Count; i++)
            {
                var dieAfterFirstRoll = diceAfterFirstRoll[i];
                var dieAfterSecondRoll = diceAfterSecondRoll[i];
                
                if (dieAfterSecondRoll.IsHeld())
                {
                    Assert.Equal(dieAfterFirstRoll, dieAfterSecondRoll.Face);
                }
                else
                {
                    Assert.NotEqual(dieAfterFirstRoll, dieAfterSecondRoll.Face);
                }
            }  
        }

        [Fact]
        public void Should_Be_Able_To_Find_Dice_Number_When_Given_Players_Values_To_Hold()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1
                .Returns(2) //dice 2
                .Returns(5) //dice 3
                .Returns(5) //dice 4
                .Returns(4); //dice 5
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var valuesToHold = new List<int> {5};
            
            //act
            gameDice.RollDice();
            var foundDice = gameDice.FindDice(valuesToHold);

            //assert
            Assert.Equal(1, foundDice.Count);
            Assert.Equal(2, foundDice[0]); //Dice position 3 = 5 for 0 index is dice 2 not 3
        }
        
        [Fact]
        public void Should_Be_Able_To_Find_Dice_Number_When_Given_Players_Values_Which_Have_Multiple_Of_The_Same_Value_To_Hold()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1 = index 0 <-
                .Returns(1) //dice 2 = index 1 
                .Returns(1) //dice 3 = index 2 
                .Returns(5) //dice 4 = index 3 <-
                .Returns(5); //dice 5 = index 4 <-
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var valuesToHold = new List<int> {5, 5, 1}; 
            
            //act
            gameDice.RollDice();
            var foundDice = gameDice.FindDice(valuesToHold);

            //assert
            Assert.Equal(3, foundDice.Count);
            Assert.Equal(0, foundDice[0]);
            Assert.Equal(3, foundDice[1]); 
            Assert.Equal(4, foundDice[2]);// The order of foundDice is based on the order of the faces in dice (even though they have been listed 5,2,2)
        }

        [Fact]
        private void Player_Should_Not_Be_Able_To_Hold_Dice_That_Are_Not_Contained_In_Their_Dice_Collection()
        {
            //assign
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.SetupSequence(m => m.RandomNumber(1, 6))
                .Returns(1) //dice 1 = index 0 <-
                .Returns(1) //dice 2 = index 1 
                .Returns(1) //dice 3 = index 2 
                .Returns(5) //dice 4 = index 3 <-
                .Returns(5); //dice 5 = index 4 <-
                
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var valuesToHold = new List<int> {2, 3, 4}; 
            //act
            gameDice.RollDice();

            //assert
            Assert.Throws <DiceNotFoundException>(() => gameDice.FindDice(valuesToHold));
        }
    }
}