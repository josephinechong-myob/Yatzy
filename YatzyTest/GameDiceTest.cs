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
            var gameDice = new GameDice();
            
            //assert
            Assert.Equal(5, gameDice.Dice.Count);
        }
    }
}