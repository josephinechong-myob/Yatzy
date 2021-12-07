namespace Yatzy
{
    public class GameInput
    {
        private readonly IConsole _console;
        private readonly PlayerInputValidator _playerInputValidator;

        public GameInput(IConsole console)
        {
            _console = console;
            _playerInputValidator = new PlayerInputValidator(console);
        }
        
        
        public bool AskIfPlayerWantsToHoldDice()
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
        
        public bool AskIfPlayerWantsToRollDice()
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
        
        
    }
}