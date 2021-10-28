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
            
            var firstHeldDieFace = gameDice.Dice[0].Face;
            var secondHeldDieFace = gameDice.Dice[1].Face;
            var thirdHeldDieFace = gameDice.Dice[3].Face;
            var firstNonHeldDieFace = gameDice.Dice[2].Face;
            var secondNonHeldDieFace = gameDice.Dice[4].Face;
            
            gameDice.HoldDice(mockPlayerHeldList);
            gameDice.RollDice();
            
            var firstHeldDieFacePostRoll = gameDice.Dice[0].Face;
            var secondHeldDieFacePostRoll = gameDice.Dice[1].Face;
            var thirdHeldDieFacePostRoll = gameDice.Dice[3].Face;
            var firstNonHeldDieFacePostRoll = gameDice.Dice[2].Face;
            var secondNonHeldDieFacePostRoll = gameDice.Dice[4].Face;
            
            //assert
            Assert.Equal(firstHeldDieFace, firstHeldDieFacePostRoll);
            Assert.Equal(secondHeldDieFace, secondHeldDieFacePostRoll);
            Assert.Equal(thirdHeldDieFace, thirdHeldDieFacePostRoll);
            Assert.NotEqual(firstNonHeldDieFace, firstNonHeldDieFacePostRoll);
            Assert.NotEqual(secondNonHeldDieFace, secondNonHeldDieFacePostRoll);
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
        private void Should_Be_Able_To_Find_Dice_Number_When_Given_Players_Values_To_Hold()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            // Add values to return from random number generator
            var gameDice = new GameDice(mockRandomNumberGenerator.Object);
            var valuesToHold = new List<int> {5}; {}
            
            //act
            gameDice.RollDice();
            var foundDice = gameDice.FindDice(valuesToHold);
            
            //assert
            Assert.Equal(1, foundDice.Count);
            Assert.Equal(3, foundDice[0]); //so value of 3rd dice = 5 {1 2 5 2 4}
            

        }
        
        // 5 5 (test 1)
        // dice { 1 1 1 5 5} making sure that the second 5 is index 4 not 3 again
            
        //validation of user input  (test 2)
        //valudation here if the user passes in values not within dice list
    }
}