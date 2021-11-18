using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy
{
    public class Player
    {
        private readonly List<Category> _categoriesWon; //15 categories max .count 
        public string Name { get; }
        private readonly IConsole _console;
        public int Score => GetScore();

        public Player(IConsole console, string name)
        {
            Name = name;
            _categoriesWon = new List<Category>();
            _console = console;
        }

        public int GetNumberOfCategoriesPlayed()
        {
            return _categoriesWon.Count;
        }

        private int GetScore()
        {
            var sum = 0;
            foreach (var category in _categoriesWon)
            {
                sum += category.CalculateScore();
            }
            return sum;
        }
        

        private bool StringIsOnlyNumbersAndCommas(string playerInput) //player validator class or game validator class
        {
            var validPattern = new Regex("^[1-6],?[1-6]?,?[1-6]?,?[1-6]?,?[1-6]?$");
            return playerInput != string.Empty && validPattern.IsMatch(playerInput);
        }
        
        //hold should be on the player (all interactions with the player) - player need to provide a list of dice values to hold
        public List<int> ValuesToHold(List<Die> gameDice) //mock the console and write a test
        {
            var valuesToHold = new List<int>();
            var answer = string.Empty;
            while (!StringIsOnlyNumbersAndCommas(answer)) //pass through the answer of a function 
            {
                _console.WriteLine("Please list all the numbers you would like to hold separated by comma ','. For example if you would to hold the same number twice please write it twice when listing. ");
            
                answer = _console.ReadLine(); //5,5 validate input with regex
            }
            
            var listOfStrings = answer.Split(",").ToList();
            foreach (var item in listOfStrings)
            {
                var number = int.Parse(item); //ask Jeremy what is better Parse (have to be tightly coupled e.g. in the same function) or try (validation is in a different class) parse - validation or try parse what if the user inputs something wrong like letters
                
                valuesToHold.Add(number);
            }
            return valuesToHold;
        }
        
        private bool HasChosenCategory(CategoryType chosenCategory)
        {
            foreach (var category in _categoriesWon)
            {
                if (category.CategoryType == chosenCategory) //need to account for only one of the one of a kind ones
                {
                    return false;
                }
            }
            return true;
        }
        
        public void ChooseCategory(Category chosenCategory)
        {
            if (HasChosenCategory(chosenCategory.CategoryType))
            {
                var categoryScore = chosenCategory.CalculateScore();
                _console.WriteLine($"You have scored {categoryScore} for {chosenCategory.CategoryType}");
                _categoriesWon.Add(chosenCategory);
            }
        }
    }
}