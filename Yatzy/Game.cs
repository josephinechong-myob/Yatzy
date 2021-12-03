using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Yatzy.Categories;

namespace Yatzy
{
    public class Game
    {
        //players should be in a list or array and loop through 
        private readonly IConsole _console;
        public GameDice GameDice;
        public Dictionary<string, List<int>> ScoreRecords;
        public PlayerInputValidator PlayerInputValidator;
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            GameDice = new GameDice(randomNumberGenerator, console);
            ScoreRecords = new Dictionary<string, List<int>>();
            PlayerInputValidator = new PlayerInputValidator(console);
        }
        
        public void Run() 
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine(); 
            var player = new Player(_console, playerName);
            
            while (GameShouldContinue(player)) 
            {
                if (player.AllCategoriesHaveBeenPlayed(player)) 
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

        private bool PlayerIsPlayingCurrentGame(Player player) //?
        {
            return (!PlayerHasNotPlayedBefore(player) && !player.AllCategoriesHaveBeenPlayed(player) &&
                    PlayerWantsToContinueGame(player));
        }
        
        
        private bool GameShouldContinue(Player player)
        {
            if (PlayerHasNotPlayedBefore(player))
            {
                return true;
            }
            
            if (PlayerIsPlayingCurrentGame(player))
            {
                return true;
            }
            
            if (player.AllCategoriesHaveBeenPlayed(player) && PLayerWantsToResetGame())
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

        private bool AskIfPlayerWantsToRollDice()
        {
            _console.WriteLine("Would you like to roll dice? Y - Yes, N - No");
            var playerWantsToRollDice = _console.ReadLine();
                
            while(!PlayerInputValidator.IsYOrN(playerWantsToRollDice))
            {
                _console.WriteLine("Please enter Y - Yes, N - No");
                playerWantsToRollDice = _console.ReadLine();
            }
            
            return playerWantsToRollDice == "Y";
        }

        private bool AskIfPlayerWantsToHoldDice()
        {
            _console.WriteLine("Would you like to hold dice? Y - Yes, N - No");
            var playerWantsToHoldDice = _console.ReadLine();
            
            while(!PlayerInputValidator.IsYOrN(playerWantsToHoldDice))
            {
                _console.WriteLine("Please enter Y - Yes, N - No");
                playerWantsToHoldDice = _console.ReadLine();
            }

            return playerWantsToHoldDice == "Y";
        }

        private void RollDice()
        {
            GameDice.RollDice();
            GameDice.DisplayDice();
        }

        private void HoldDice(Player player, int rollCounter)
        {
            if (rollCounter >= 1)
            {
                var playerWantsToHoldDice = AskIfPlayerWantsToHoldDice();
                if (playerWantsToHoldDice)
                { 
                    PlayerSelectsDiceToHold(player);
                }
            }
        }
        
        private void PlayerRollsDice(Player player)
        {
            var playerWantsToRollDice = true;
            var rollCounter = 0;
            
            while (rollCounter < 3 && playerWantsToRollDice)
            {
                HoldDice(player, rollCounter);

                if (rollCounter > 0)
                {
                    playerWantsToRollDice = AskIfPlayerWantsToRollDice();
                }
                
                if (playerWantsToRollDice)
                {
                    RollDice();
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
       
        private SpecificNumberType RequestSpecificNumberType()
        {
            _console.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number");

            var playerInput = _console.ReadLine();
            while (!PlayerInputValidator.IsOnlyNumbersOneToSix(playerInput))
            {
                _console.WriteLine("Please enter a number 1 to 6.");
                playerInput = _console.ReadLine();
            }
            
            var specificNumber = int.Parse(playerInput);
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
           
           while (!PlayerInputValidator.IsOnlyNumbersOneToTen(chosenCategory))
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