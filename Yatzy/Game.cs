using System.Collections.Generic;
using System.Linq;
using Yatzy.Categories;

namespace Yatzy
{
    public class Game
    {
        #region fields
        private readonly IConsole _console;
        private readonly GameDice _gameDice;
        private readonly Dictionary<string, List<int>> _scoreRecords;
        private readonly PlayerInputValidator _playerInputValidator;
        #endregion
        
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            _gameDice = new GameDice(randomNumberGenerator, console);
            _scoreRecords = new Dictionary<string, List<int>>();
            _playerInputValidator = new PlayerInputValidator(console);
        }
        
        public void Run() 
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is your name?");
            var playerName = _console.ReadLine(); 
            var player = new Player(_console, playerName);
            
            while (GameShouldContinue(player)) 
            {
                if (player.AllCategoriesHaveBeenPlayed()) 
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
        
        #region Ask player
        private bool AskIfPlayerWantsToRollDice()
        {
            _console.WriteLine("Would you like to roll dice? Y - Yes, N - No");
            var playerWantsToRollDice = _console.ReadLine();
                
            while(!_playerInputValidator.IsYOrN(playerWantsToRollDice))
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
            
            while(!_playerInputValidator.IsYOrN(playerWantsToHoldDice))
            {
                _console.WriteLine("Please enter Y - Yes, N - No");
                playerWantsToHoldDice = _console.ReadLine();
            }

            return playerWantsToHoldDice == "Y";
        }
        
        private void PlayerSelectsDiceToHold(Player player)
        {
            var valuesToHold = player.ValuesToHold(_gameDice.Dice); 
            var diceToHold = _gameDice.FindDice(valuesToHold); 
            _gameDice.HoldDice(diceToHold); 
        }
        
        private void PlayerChoosesCategory(Player player)
        {
            var chosenCategory = RequestPlayersCategory(player);
            
            if (chosenCategory == CategoryType.SpecificNumber)
            { 
                var specificNumber = RequestSpecificNumberType();
                var specificNumberCategory = new Category(specificNumber, _gameDice.Dice);
                player.ChooseCategory(specificNumberCategory);
            }
            else
            {
                var category = new Category(chosenCategory, _gameDice.Dice);
                player.ChooseCategory(category);  
            }
        }
        
        private CategoryType RequestPlayersCategory(Player player) //testing in "synchronisatin'? // may need to 
        {
            _console.WriteLine($"Please select a category below:");
            
            var types = player.CategoryTypeRemaining;
            PrintCategories(types);
            
            var category = GetSelectedCategory(types);
            _console.WriteLine($"You have chosen {category} category");
            
            return category;
        }
        
        private void PrintCategories(List<CategoryType> types)
        {
            
            for (var i=0; i < types.Count(); i++)
            {
                var categoryNumber = i + 1;
                _console.WriteLine($"[{categoryNumber}] - {types.ElementAt(i).ToString()}");
            }
        }

        private CategoryType GetSelectedCategory(List<CategoryType> types)
        {
            var chosenCategory = _console.ReadLine(); 
            while (!_playerInputValidator.IsOnlyNumbersOneToTen(chosenCategory))
            {
                _console.WriteLine("Please enter the number of the category you would like to select");
            
                chosenCategory = _console.ReadLine();
            }
           
            var categoryIndex = int.Parse(chosenCategory);
            var category = types.ElementAt(categoryIndex-1);
            return category;
        }
        
        private SpecificNumberType RequestSpecificNumberType()
        {
            _console.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number");

            var playerInput = _console.ReadLine();
            while (!_playerInputValidator.IsOnlyNumbersOneToSix(playerInput))
            {
                _console.WriteLine("Please enter a number 1 to 6.");
                playerInput = _console.ReadLine();
            }
            
            var specificNumber = int.Parse(playerInput);
            var number = (SpecificNumberType) specificNumber;
            return number;
        }
        #endregion //player input class
        
        #region Dice mechanics
        private void PlayerRollsDice(Player player)
        {
            var playerWantsToRollDice = true;
            var rollCounter = 0;
            
            while (rollCounter < 3 && playerWantsToRollDice) // put into a function the condition
            {
                HoldDice(player, rollCounter);

                if (rollCounter > 0) // Is not player's first roll function
                {
                    playerWantsToRollDice = AskIfPlayerWantsToRollDice();
                }
                
                if (playerWantsToRollDice) //maybe put into roll dice ?
                {
                    RollDice();
                    rollCounter = rollCounter + 1;
                } 
            }
        }
        private void RollDice()
        {
            _gameDice.RollDice();
            _gameDice.DisplayDice();
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
        #endregion
        
        #region Player state
        private bool PlayerIsPlayingCurrentGame(Player player) // move to player class 
        {
            return (!player.HasNotPlayedBefore() && !player.AllCategoriesHaveBeenPlayed() &&
                    PlayerWantsToContinueGame(player));
        }
        
        private bool PlayerWantsToContinueGame(Player player) //move to player class
        {
            _console.WriteLine($"Your total score is {player.Score}. Would you like to continue playing? Y - Yes, N - No");
            var response = _console.ReadLine();
            return (response == "Y");
        }
        
        private bool PLayerWantsToResetGame() //move to player class
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
        #endregion
        

        private void UpdateScoreRecords(Player player)
        {
            var playerName = player.Name;
            if (_scoreRecords.ContainsKey(playerName))
            {
                _scoreRecords[playerName].Add(player.Score);
            }
            else
            {
                _scoreRecords.Add(playerName, new List<int>{player.Score});
            }  
        }
        
        private void PrintPlayersScores() 
        {
            _console.WriteLine("Congratulations on finishing your Yatzy game. Here are the results: ");
            foreach (var record in _scoreRecords)
            {
                _console.WriteLine($"{record.Key}'s final score is {record.Value.Sum()}. ");
            }
        }
        
        private bool GameShouldContinue(Player player)
        {
            if (player.HasNotPlayedBefore()) 
            {
                return true;
            }

            if (PlayerIsPlayingCurrentGame(player))
            {
                return true;
            }

            if (player.AllCategoriesHaveBeenPlayed() && PLayerWantsToResetGame())
            {
                return true;
            }

            return false;
        }
    }
}