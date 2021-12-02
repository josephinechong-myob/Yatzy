using System.Text.RegularExpressions;

namespace Yatzy
{
    public class UserInputValidator
    {
        private readonly IConsole _console;

        public UserInputValidator(IConsole console)
        {
            _console = console;
        }
        
        public bool StringIsOnlyNumbers(string playerInput) //cat no
        {
            var validPattern = new Regex("^[1-9][0]?$");
            var stringIsEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsEmpty && patternIsMatch;
        }
        
        public string StringIsOnlyNumbersOneToSix(string playerInput) //spec no select
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
        public string ResponseIsYOrN(string playerInput) 
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
        
    }
}