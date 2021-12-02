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
        public Dictionary<string, List<int>> ScoreRecords;
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            GameDice = new GameDice(randomNumberGenerator, console);
            ScoreRecords = new Dictionary<string, List<int>>();
        }
        
        public void Run() 
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine(); 
            var player = new Player(_console, playerName);
            
            while (GameShouldContinue(player)) 
            {
                if (AllCategoriesHaveBeenPlayed(player)) 
                {
                    UpdateScoreRecords(player);
                    player = player.Reset();
                }
                PlayerRollsDice(player);
                PlayerChoosesCategory(player);
            }
            UpdateScoreRecords(player);
            PrintPlayersScores();
        }

        private void UpdateScoreRecords(Player player)
        {
            var playerName = player.Name;
            if (ScoreRecords.ContainsKey(playerName))
            {
                ScoreRecords[playerName].Add(player.Score);
            }
            else
            {
                ScoreRecords.Add(playerName, new List<int>{player.Score});
            }  
        }
        
        private void PrintPlayersScores()
        {
            _console.WriteLine("Congratulations on finishing your Yatzy game. Here are the results: ");
            foreach (var record in ScoreRecords)
            {
                _console.WriteLine($"{record.Key}'s final score is {record.Value.Sum()}. ");
            }
        }

        private bool AllCategoriesHaveBeenPlayed(Player player)
        {
            return player.GetNumberOfCategoriesPlayed() == MaxCategories;
        }

        private bool PLayerWantsToResetGame() //don't use recussion here although it does work
        {
            _console.WriteLine("Would you like to play again? Y - Yes, N - No");
            var reply = _console.ReadLine();
            while (reply != "Y" && reply != "N")
            {
                _console.WriteLine("Please enter Y - Yes to play again or N - No to stop the game");
                reply = _console.ReadLine();
            }
            if (reply == "Y")
            {
                return true;
            }
            return false;
        }

        private bool GameIsInProgress(Player player)
        {
            return (!PlayerHasNotPlayedBefore(player) && !AllCategoriesHaveBeenPlayed(player) &&
                    PlayerWantsToContinueGame(player));
        }
        
        private bool GameShouldContinue(Player player)
        {
            if (PlayerHasNotPlayedBefore(player))
            {
                return true;
            }
            
            if (GameIsInProgress(player))
            {
                return true;
            }
            
            if (AllCategoriesHaveBeenPlayed(player) && PLayerWantsToResetGame())
            {
                return true;
            }
            
            return false;
            //var gamesPlayed = player.GetNumberOfCategoriesPlayed();
            // return PlayerHasNotPlayedBefore(player) ||
            //        ((!PlayerHasNotPlayedBefore(player) && !AllCategoriesHaveBeenPlayed(player) && PlayerWantsToContinueGame(player)) ||
            //        (AllCategoriesHaveBeenPlayed(player) && PLayerWantsToResetGame())
            //        );
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
        private string ResponseIsYOrN(string playerInput) 
        {
            var validPattern = new Regex("^[YN]$");
            var stringIsEmpty = playerInput == string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            
            while (stringIsEmpty || !patternIsMatch)
            {
                _console.WriteLine("Please enter Y - Yes, N - No");
            
                playerInput = _console.ReadLine();
                patternIsMatch = validPattern.IsMatch(playerInput);
                stringIsEmpty = playerInput == string.Empty;
            }
           
            return playerInput ;
        }
        
        private void PlayerRollsDice(Player player)
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
                if (response == "Y")
                {
                    GameDice.RollDice();
                    GameDice.DisplayDice();
                    rollCounter = rollCounter + 1;
                }
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

        private void PlayerSelectsDiceToHold(Player player)
        {
            var valuesToHold = player.ValuesToHold(GameDice.Dice); 
            var diceToHold = GameDice.FindDice(valuesToHold); 
            GameDice.HoldDice(diceToHold); 
        }
        
        private bool StringIsOnlyNumbers(string playerInput) 
        {
            var validPattern = new Regex("^[1-9][0]?$");
            var stringIsEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsEmpty && patternIsMatch;
        }
        
        private string StringIsOnlyNumbersOneToSix(string playerInput) 
        {
            var validPattern = new Regex("^[1-6]$");
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            while (!stringIsNotEmpty && !patternIsMatch)
            {
                _console.WriteLine("Please enter a number 1 to 6.");
                playerInput = _console.ReadLine();
            }
            return playerInput;
        }

        private SpecificNumberType RequestSpecificNumberType()
        {
            _console.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number");

            var specificNumberType = StringIsOnlyNumbersOneToSix(_console.ReadLine());
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