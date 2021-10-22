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
           var dice = new Dice();
           
           //act
           var rolledNumber = dice.Roll();

           //assert
            Assert.InRange(rolledNumber, 1, 6);
        }
    }
}