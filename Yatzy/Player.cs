using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Yatzy.Categories;

namespace Yatzy
{
    public class Player
    {
        #region Fields
        public string Name { get; }
        public int Score;
        public List<CategoryType> CategoryTypeRemaining =>
            _categoriesAll.Where(c=>!_categoriesWon.Exists(won=>won.CategoryType==c)).ToList();
        private readonly List<Category> _categoriesWon;
        private readonly List<CategoryType> _categoriesAll;
        private readonly IConsole _console;
        private PlayerInputValidator _playerInputValidator;
        #endregion
        
        public Player(IConsole console, string name)
        {
            Name = name;
            _categoriesWon = new List<Category>();
            _console = console;
            _categoriesAll = GetAllCategories();
            _playerInputValidator = new PlayerInputValidator();
        }
        
        public void PlayerSelectsDiceToHold(GameDice gameDice)
        {
            var valuesToHold = ValuesToHold(gameDice.Dice); 
            var diceToHold = gameDice.FindDice(valuesToHold); 
            gameDice.HoldDice(diceToHold); 
        }
        
        public bool PLayerWantsToResetGame()
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
        
        public bool PlayerIsPlayingCurrentGame()
        {
            return (!HasNotPlayedBefore() && !AllCategoriesHaveBeenPlayed() && PlayerWantsToContinueGame());
        }

        private bool PlayerWantsToContinueGame()
        {
            _console.WriteLine($"Your total score is {Score}. Would you like to continue playing? Y - Yes, N - No");
            var response = _console.ReadLine();
            return (response == "Y");
        }
        
        public bool HasNotPlayedBefore() 
        {
            return GetNumberOfCategoriesPlayed() == 0;
        }
        public bool AllCategoriesHaveBeenPlayed()
        {
            return GetNumberOfCategoriesPlayed() == Constants.MaxCategories;
        }

        private int GetNumberOfCategoriesPlayed()
        {
            return _categoriesWon.Count;
        }

        private List<CategoryType>  GetAllCategories() //(***MOVE***)new class of categy provider which gives a list of categories to choose from 
        {
            return Enum.GetValues(typeof(CategoryType)).Cast<CategoryType>().ToList();
         
        }


        public Player Reset()
        {
            return new Player(_console, Name);
        }
        
        
        
        //hold should be on the player (all interactions with the player) - player need to provide a list of dice values to hold
        public List<int> ValuesToHold(List<Die> gameDice) //mock the console and write a test
        {
            var valuesToHold = new List<int>();
            var answer = string.Empty;
            while (!_playerInputValidator.IsOnlyNumbersAndCommas(answer)) //pass through the answer of a function 
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
        
        private bool HasChosenCategory(CategoryType chosenCategory) //validation for cat
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
        private void GetTotalScore(int categoryScore)
        {
            Score += categoryScore;
        }
        public void ChooseCategory(Category chosenCategory)
        {
            if (HasChosenCategory(chosenCategory.CategoryType))
            {
                var categoryScore = chosenCategory.CalculateScore();
                _console.WriteLine($"You have scored {categoryScore} for {chosenCategory.CategoryType}");
                _categoriesWon.Add(chosenCategory); //if any of 1-6 is chosen all get added to this list here
                GetTotalScore(categoryScore);
            }
        }
    }
}