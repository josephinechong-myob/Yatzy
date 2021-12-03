using System.Text.RegularExpressions;

namespace Yatzy
{
    public class PlayerInputValidator
    {
        private readonly IConsole _console;

        public PlayerInputValidator(IConsole console)
        {
            _console = console;
        }

        private bool IsValidInput(string playerInput, Regex validPattern)
        {
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch; 
        }
        public bool StringIsOnlyNumbers(string playerInput) //function that returns a boolean that has all 4 lines
        {
            var validPattern = new Regex("^[1-9][0]?$");
            return IsValidInput(playerInput, validPattern);
        }
        
        public bool StringIsOnlyNumbersOneToSix(string playerInput)
        {
            var validPattern = new Regex("^[1-6]$");
            return IsValidInput(playerInput, validPattern);
        }
        public bool ResponseIsYOrN(string playerInput) 
        {
            var validPattern = new Regex("^[YN]$");
            return IsValidInput(playerInput, validPattern);
        }
    }
}