using System.Text.RegularExpressions;

namespace Yatzy
{
    public class PlayerInputValidator
    {
        public bool IsOnlyNumbersAndCommas(string playerInput)
        {
            var pattern = "^[1-6],?[1-6]?,?[1-6]?,?[1-6]?,?[1-6]?$";
            return IsValidInput(playerInput, pattern);
        }
        public bool IsOnlyNumbersOneToTen(string playerInput)
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
        
        private static bool IsValidInput(string playerInput, string pattern)
        {
            var validPattern = new Regex(pattern);
            var stringIsNotEmpty = playerInput != string.Empty;
            var patternIsMatch = validPattern.IsMatch(playerInput);
            return stringIsNotEmpty && patternIsMatch; 
        }
    }
}