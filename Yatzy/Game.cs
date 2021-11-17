using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            var playerName = _console.ReadLine(); //1
            var player = new Player(_console, playerName);
            _console.WriteLine($"{playerName} would you like to play a game? Y - yes or N - no");
            var playerChoice = _console.ReadLine(); //2
            var rollCounter = 0;
            
            if (playerChoice == "Y")
            {
                _gamedice.RollDice();
                rollCounter++;
                
                _console.WriteLine($"{playerName} would you like to roll again? Y - yes or N - no");
                var playerReRollDice = _console.ReadLine(); //3
                
                while (playerReRollDice == "Y" && rollCounter <= 3) //while - max 3 rolls/optional
                {
                    var valuesToHold = player.ValuesToHold(_gamedice.Dice);
                    var diceToHold = _gamedice.FindDice(valuesToHold);
                    _gamedice.HoldDice(diceToHold);
                    _gamedice.RollDice();
                    rollCounter++;
                }
                //player choosing category 
                var chosenCategory = requestPlayersCategory(player);
                //player.ChooseCategory(chosenCategory);
                
                // roll dice
                //player choice to cont rolling?

                //We ask the player what category they want to play

            }
            else if (playerChoice == "N")
            {
                var chosenCategory = requestPlayersCategory(player);
                var category = new Category(chosenCategory, _gamedice.Dice);
                player.ChooseCategory(category);
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
        private bool StringIsOnlyNumbers(string playerInput) //validate category selection
        {
            var validPattern = new Regex("^[1-9][1-5]?$");
            var stringIsEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsEmpty && patternIsMatch;
        }
        
        private CategoryType requestPlayersCategory(Player player) //testing in "synchronisatin'?
        {
            _console.WriteLine("Please select a category: ");
           var types = Enum.GetValues(typeof(CategoryType)).Cast<CategoryType>();
           for (var i=0; i < types.Count(); i++)
           {
               var categoryNumber = i + 1;
               _console.WriteLine($"[{categoryNumber}] - {types.ElementAt(i).ToString()}");
           }

           var chosenCategory = _console.ReadLine(); //4
           
           while (!StringIsOnlyNumbers(chosenCategory))
           {
               _console.WriteLine("Please enter the number of the category you would like to select");
            
               chosenCategory = _console.ReadLine();
           }

           var categoryIndex = int.Parse(chosenCategory);
           var categoryString = types.ElementAt(categoryIndex-1);
           _console.WriteLine($"You have chosen {categoryString} category");
           return categoryString;
        }
        
        //Brown bag notes - new variable for numbering 
        //Rolling dice
        
        //Rolling with held numbers
        
        //Reset game
    }
}