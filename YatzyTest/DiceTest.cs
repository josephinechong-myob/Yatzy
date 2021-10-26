using System;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class DiceTest
    {
        private RandomNumberGenerator _randomNumberGenerator;
        public DiceTest()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
        }
        [Fact]
        private void Dice_Roll_Should_Provide_Number_Between_One_And_Six()
        {
           //arrange
           var dice = new Die(_randomNumberGenerator);
           
           //act
           var rolledNumber = dice.Roll();

           //assert
            Assert.InRange(rolledNumber, 1, 6); //change to equal = 9
        }

        [Fact]
        private void Dice_Should_Record_Its_Value_After_Dice_Roll()
        {
            //arrange
            var mockRandomNumberGenerator = new Mock<IRandomNumberGenerator>();
            mockRandomNumberGenerator.Setup(m => m.RandomNumber(1, 6)).Returns(1);
            var dice = new Die(mockRandomNumberGenerator.Object);

            //act
            var rolledNumber = dice.Roll();

            //assert
            Assert.Equal(rolledNumber, dice.Face);
        }

        [Fact]
        private void New_Die_Face_Value_Should_Be_Zero_Before_First_Roll()
        {
            //arrange
            //act
            var die = new Die(_randomNumberGenerator);
            
            //assert
            Assert.Equal(0, die.Face);
        }

        [Fact]
        private void New_Die_Should_Not_Be_Held()
        {
            //arrange
            var die = new Die(_randomNumberGenerator);
            
            //act
            var held = die.IsHeld();
            
            //assert
            Assert.False(held);
        }

        [Fact]
        private void Die_Should_Be_Able_To_Be_Held()//implementation free name test name not setheld should be blah...
        {
            //arrange
            var die = new Die(_randomNumberGenerator);
            
            //act
            die.Hold();
            
            //assert
            Assert.True(die.IsHeld());
        }

        [Fact]
        private void Held_Die_Should_Be_Able_To_Be_Released()
        {
            //arrange
            var die = new Die(_randomNumberGenerator);
            
            //act
            die.Hold();
            die.Release();
            
            //assert
            Assert.False(die.IsHeld());
        }
    }
}