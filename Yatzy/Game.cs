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
        private readonly GameInput _gameInput;
        #endregion
        
        public Game(IConsole console, IRandomNumberGenerator randomNumberGenerator)
        {
            _console = console;
            _gameDice = new GameDice(randomNumberGenerator, console);
            _scoreRecords = new Dictionary<string, List<int>>();
            _playerInputValidator = new PlayerInputValidator(console);
            _gameInput = new GameInput(console);
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
                _gameInput.PlayerChoosesCategory(player, _gameDice);
            }
            UpdateScoreRecords(player);
            PrintPlayersScores();
        }
        
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
                    playerWantsToRollDice = _gameInput.AskIfPlayerWantsToRollDice();
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
                var playerWantsToHoldDice = _gameInput.AskIfPlayerWantsToHoldDice();
                if (playerWantsToHoldDice)
                { 
                    player.PlayerSelectsDiceToHold(_gameDice);
                }
            }
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

            if (player.PlayerIsPlayingCurrentGame())
            {
                return true;
            }

            if (player.AllCategoriesHaveBeenPlayed() && player.PLayerWantsToResetGame())
            {
                return true;
            }

            return false;
        }
    }
}