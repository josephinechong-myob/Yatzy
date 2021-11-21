using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy
{
    
    public class Game
    { 
        const int MaxCategories = 15;
        //players should be in a list or array and loop through 
        private readonly IConsole _console;
        public GameDice _gamedice;
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            _gamedice = new GameDice(randomNumberGenerator, console);
        }
        
        private bool PlayerWantsToContinueGame()
        {
            _console.WriteLine("Would you like to continue playing? Y - Yes, N - No");
            var response = _console.ReadLine();
            return (response == "Y");
        }
        private string ResponseIsYOrN(string playerInput) //Y
        {
            var validPattern = new Regex("^[YN]$");
            var stringIsEmpty = playerInput == string.Empty; //true
            var patternIsMatch = validPattern.IsMatch(playerInput); //true
            
            while (stringIsEmpty || !patternIsMatch)
            {
                _console.WriteLine("Please enter Y - Yes, N - No");
            
                playerInput = _console.ReadLine();
            }
           
            return playerInput ;
        }

       // private bool PlayerWantsToRollDice(int rollcounter) //wants and can roll dice if rollcounter is less than 3
        private void PlayerRollsDice(Player player) 
        {
            var response = "Y";
            var rollCounter = 0;
            
            while (rollCounter < 3 && response == "Y")
            {
                if (rollCounter >= 1)
                {
                    _console.WriteLine("Would you like to hold dice? Y - Yes, N - No");
                    var holdResponse = _console.ReadLine();
                    if (holdResponse == "Y")
                    { 
                        PlayerSelectsDiceToHold(player);
                    }
                }
                
                _console.WriteLine("Would you like to roll dice? Y - Yes, N - No");
                response = ResponseIsYOrN(_console.ReadLine());
                //response = _console.ReadLine();
                if (response == "Y")
                {
                    _gamedice.RollDice();
                    _gamedice.DisplayDice();
                    rollCounter = rollCounter + 1;
                }
                // return (response == "Y");
            }
        }

        private void PlayerChoosesCategory(Player player)
        {
            var chosenCategory = requestPlayersCategory(player);
            var category = new Category(chosenCategory, _gamedice.Dice);
            player.ChooseCategory(category);
        }

        private void PlayerSelectsDiceToHold(Player player) //player should be able to not hold any dice and reroll all dice
        {
            var valuesToHold = player.ValuesToHold(_gamedice.Dice); 
            var diceToHold = _gamedice.FindDice(valuesToHold); 
            _gamedice.HoldDice(diceToHold); 
        }
        
        public void Run()
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine(); 
            var player = new Player(_console, playerName);
            
            var gamesPlayed = player.GetNumberOfCategoriesPlayed();
            
            while (PlayerWantsToContinueGame() && (player.GetNumberOfCategoriesPlayed() < MaxCategories)) //if player has finished the whole game max = max categories
            {
                PlayerRollsDice(player);
                PlayerChoosesCategory(player); //category is not removed from list after selection
            }
            
            
            
            

            //while((rollCounter > 0 ? PlayerWantsToContinueGame() : true) && player.GetNumberOfCategoriesPlayed() < MaxCategories && rollCounter == 0)
            // {
            //     var playerWantsToRollDice = true;
            //     rollCounter = 0;
            //     
            //     while(playerWantsToRollDice && rollCounter < 3)
            //     {
            //         _gamedice.RollDice();
            //         PlayerSelectsDiceToHold(player); // isn't allowed to enter nothing or null
            //         rollCounter++;
            //         playerWantsToRollDice = PlayerWantsToRollDice(); //if player chooses to hold all the dice we can't ask them to roll any dice
            //     }
            //
            //     if (playerWantsToRollDice)
            //     {
            //         var chosenCategory = requestPlayersCategory(player);
            //         var category = new Category(chosenCategory, _gamedice.Dice);
            //         player.ChooseCategory(category);
            //     }
            // }
        }
        
        private bool StringIsOnlyNumbers(string playerInput) 
        {
            var validPattern = new Regex("^[1-9][1-5]?$");
            var stringIsEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsEmpty && patternIsMatch;
        }
        
        private CategoryType requestPlayersCategory(Player player) //testing in "synchronisatin'?
        {
            var noteForPlayerOnOneOfAKind =
                "Please note that Ones, Twos, Threes, Fours, Fives and Sixes are considered to be in one classification of category, so if you select any of these, all of these will no longer be able the next round.";
            _console.WriteLine($"Please select a category below. {noteForPlayerOnOneOfAKind}");//the note should only be available if 1-6 category is still remaining
            
           var types = player.CategoryTypeRemaining;
           for (var i=0; i < types.Count(); i++)
           {
               var categoryNumber = i + 1;
               _console.WriteLine($"[{categoryNumber}] - {types.ElementAt(i).ToString()}");
           }

           var chosenCategory = _console.ReadLine(); 
           
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
    }
}