using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Yatzy.Categories;

namespace Yatzy
{
    public class Game
    { 
        const int MaxCategories = 10;
        //players should be in a list or array and loop through 
        private readonly IConsole _console;
        public GameDice GameDice;
        public Dictionary<string, int> ScoreRecords;
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            GameDice = new GameDice(randomNumberGenerator, console);
            ScoreRecords = new Dictionary<string, int>();
        }
        
        public void Run()
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine(); 
            var player = new Player(_console, playerName);
            
            while (GameShouldContinue(player)) 
            {
                PlayerRollsDice(player);
                PlayerChoosesCategory(player); 
            }
            
            ScoreRecords.Add(playerName, player.Score); //completed game or player has quit the game and that's their final score
            PrintPlayersScores();
            
            
            //reset game
            //recording score for all compeled games (history for multiple players) - new class score keeper that does get reset or deleted
        }

        private void PrintPlayersScores()
        {
            _console.WriteLine("Congratulations on finishing your Yatzy game. Here are the results: ");
            foreach (var record in ScoreRecords)
            {
                _console.WriteLine($"{record.Key}'s final score is {record.Value}. ");
            }
        }
       

        private bool GameShouldContinue(Player player)
        {
            var gamesPlayed = player.GetNumberOfCategoriesPlayed();
            return PlayerHasNotPlayedBefore(player) || ((!PlayerHasNotPlayedBefore(player) && PlayerWantsToContinueGame(player))
                   && (gamesPlayed < MaxCategories));
        }

        private bool PlayerHasNotPlayedBefore(Player player)
        {
            return player.GetNumberOfCategoriesPlayed() == 0;
        }
        
        private bool PlayerWantsToContinueGame(Player player)
        {
            _console.WriteLine($"Your total score is {player.Score}. Would you like to continue playing? Y - Yes, N - No");
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
        private void PlayerRollsDice(Player player) //input validation for readline
        {
            var response = "Y";
            
            GameDice.RollDice();
            GameDice.DisplayDice();
            var rollCounter = 1;
            
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
                    GameDice.RollDice();
                    GameDice.DisplayDice();
                    rollCounter = rollCounter + 1;
                }
                // return (response == "Y");
            }
        }

        private void PlayerChoosesCategory(Player player)
        {
            var chosenCategory = RequestPlayersCategory(player);
            
            if (chosenCategory == CategoryType.SpecificNumber)
            { 
                var specificNumber = RequestSpecificNumberType();
                var specificNumberCategory = new Category(specificNumber, GameDice.Dice);
                player.ChooseCategory(specificNumberCategory);
            }
            else
            {
                var category = new Category(chosenCategory, GameDice.Dice);
                player.ChooseCategory(category);  
            }
        }

        private void PlayerSelectsDiceToHold(Player player) //player should be able to not hold any dice and reroll all dice
        {
            var valuesToHold = player.ValuesToHold(GameDice.Dice); 
            var diceToHold = GameDice.FindDice(valuesToHold); 
            GameDice.HoldDice(diceToHold); 
        }
        
        private bool StringIsOnlyNumbers(string playerInput) 
        {
            var validPattern = new Regex("^[1-9][1-5]?$");
            var stringIsEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsEmpty && patternIsMatch;
        }

        private SpecificNumberType RequestSpecificNumberType()
        {
            var noteForPlayerOnOneOfAKind =
                "Please note that Ones, Twos, Threes, Fours, Fives and Sixes are considered to be in one classification of category, so if you select any of these, all of these will no longer be able the next round.";
               
            _console.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number");

            var specificNumberType = _console.ReadLine(); //validation for user input
               
            var specificNumber = int.Parse(specificNumberType);
            var number = (SpecificNumberType) specificNumber;
            return number;
        }
        
        private CategoryType RequestPlayersCategory(Player player) //testing in "synchronisatin'? // may need to 
        {
            _console.WriteLine($"Please select a category below:");
            
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
    }
}