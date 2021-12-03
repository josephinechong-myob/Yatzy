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

        private bool IsValidInput(string playerInput, string pattern)
        {
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch; 
        }
        
        public bool IsOnlyNumbersOneToTen(string playerInput) //function that returns a boolean that has all 4 lines
        {
            var pattern = "^[1-9][0]?$";
            return IsValidInput(playerInput, pattern);
        }
        
        public bool IsOnlyNumbersOneToSix(string playerInput)
        {
            var pattern = "^[1-6]$";
            return IsValidInput(playerInput, pattern);
        }
        
        public bool IsYOrN(string playerInput)
        {
            var pattern = "^[YN]$";
            return IsValidInput(playerInput, pattern);
        }
    }
}