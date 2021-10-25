using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold & change class Dice to Die (singluar)
    {
        public List<Dice> Dice; 
        public GameDice()
        {
            var randomNumberGenerator = new RandomNumberGenerator();
            Dice = new List<Dice>() {
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
                new Dice(randomNumberGenerator), 
            }; 
        }
        
        
        //Dice 1
        //Dice 2
        //Dice 3
        //Dice 4
        //Dice 5
    }
}