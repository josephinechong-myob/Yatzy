using System;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class DiceTest
    {
        [Fact]
        private void Dice_Roll_Should_Provide_Number_Between_One_And_Six()
        {
           //arrange
           var randomNumberGenerator = new Mock<IRandomNumberGenerator>();
           randomNumberGenerator.Setup(m => m.RandomNumber(1, 9)).Returns(9);
           var dice = new Dice(randomNumberGenerator.Object);
           
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
            var dice = new Dice(mockRandomNumberGenerator.Object);

            //act
            var rolledNumber = dice.Roll();

            //assert
            Assert.Equal(rolledNumber, dice.Face);
        }
    }
}