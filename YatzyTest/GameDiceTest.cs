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
    }
}