using System.Collections.Generic;
using System.Reflection;

namespace Yatzy
{
    public class Game
    { 
        //players should be in a list or array and loop through 
        private readonly IConsole _console;
        public GameDice _gamedice;
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            _gamedice = new GameDice(randomNumberGenerator);
        }
        
        public void Run()
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine();
            var player = new Player(_console, playerName);
            _console.WriteLine($"{playerName} would you like to play a game? Y - yes or N - no");
            var playerChoice = _console.ReadLine();
            var rollCounter = 0;
            
            if (playerChoice == "Y")
            {
                _gamedice.RollDice();
                rollCounter++;
                
                _console.WriteLine($"{playerName} would you like to roll again? Y - yes or N - no");
                var playerReRollDice = _console.ReadLine();
                
                while (playerReRollDice == "Y" && rollCounter <= 3) //while - max 3 rolls/optional
                {
                    var valuesToHold = player.ValuesToHold(_gamedice.Dice);
                    var diceToHold = _gamedice.FindDice(valuesToHold);
                    _gamedice.HoldDice(diceToHold);
                    _gamedice.RollDice();
                    rollCounter++;
                }
                //player choosing category 
                
                // roll dice
                //player choice to cont rolling?

                //We ask the player what category they want to play

            }
            else if (playerChoice == "N")
            {
                return;
            }


            //player rolls dice (new instance of gamedice)
            //optional to hold and re-roll (3 times total)
            //player chooses a category (per player record)
            //player obtains a score & adds to total score (per player record)
            //category is removed from options to choose in next roll

            //changes player (alternate rolls) or player 1 plays and finishes game before player 2?

            //repeat until all categories are used to complete the game

            //put into an object and rotate the object, or put players in a list and rotate the list 
        }
        
        //Rolling dice
        
        //Rolling with held numbers
        
        //Reset game
    }
}