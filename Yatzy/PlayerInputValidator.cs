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
        
        public bool StringIsOnlyNumbers(string playerInput) //cat no
        {
            var validPattern = new Regex("^[1-9][0]?$");
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch;
        }
        
        public bool StringIsOnlyNumbersOneToSix(string playerInput) //spec no select
        {
            var validPattern = new Regex("^[1-6]$");
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch;
        }
        public bool ResponseIsYOrN(string playerInput) 
        {
            var validPattern = new Regex("^[YN]$");
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch;
        }
    }
}