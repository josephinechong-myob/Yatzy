using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly PlayerInputValidator _playerInputValidator;
        #endregion
        
        public Player(IConsole console, string name)
        {
            Name = name;
            _categoriesWon = new List<Category>();
            _console = console;
            _categoriesAll = Category.GetAllCategories();
            _playerInputValidator = new PlayerInputValidator();
        }
        
        public void SelectDiceToHold(GameDice gameDice)
        {
            var diceValuesToHold = GetDiceValuesToHold(); 
            var diceToHold = gameDice.FindDice(diceValuesToHold); 
            gameDice.HoldDice(diceToHold); 
        }

        private string AskPlayerForDiceValuesToHold()
        {
            var answer = string.Empty;
            while (!_playerInputValidator.IsOnlyNumbersAndCommas(answer)) 
            {
                _console.WriteLine("Please list all the numbers you would like to hold separated by comma ','. For example if you would to hold the same number twice please write it twice when listing. ");
            
                answer = _console.ReadLine();
            }

            return answer;
        }
        
        public List<int> GetDiceValuesToHold() 
        {
            var valuesToHold = new List<int>();
            
            var diceValuesToHoldInput = AskPlayerForDiceValuesToHold();
            
            var listOfStrings = diceValuesToHoldInput.Split(",").ToList();
            foreach (var item in listOfStrings)
            {
                var number = int.Parse(item);
                
                valuesToHold.Add(number);
            }
            return valuesToHold;
        }
        
        public void SetCategory(Category chosenCategory)
        {
            if (HasChosenCategory(chosenCategory.CategoryType))
            {
                var categoryScore = chosenCategory.CalculateScore();
                _console.WriteLine($"You have scored {categoryScore} for {chosenCategory.CategoryType}");
                _categoriesWon.Add(chosenCategory);
                AddScore(categoryScore);
            }
        }
        
        public Player Reset()
        {
            return new Player(_console, Name);
        }
        
        public bool WantsToResetGame()
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
        
        public bool IsPlayingCurrentGame()
        {
            return (!HasNotPlayedBefore() && !HasPlayedAllCategories() && WantsToContinueGame());
        }

        private bool WantsToContinueGame()
        {
            _console.WriteLine($"Your total score is {Score}. Would you like to continue playing? Y - Yes, N - No");
            var response = _console.ReadLine();
            return (response == "Y");
        }
        
        public bool HasNotPlayedBefore() 
        {
            return GetNumberOfCategoriesPlayed() == 0;
        }
        
        public bool HasPlayedAllCategories()
        {
            return GetNumberOfCategoriesPlayed() == Constants.MaxCategories;
        }

        private int GetNumberOfCategoriesPlayed()
        {
            return _categoriesWon.Count;
        }
        
        private bool HasChosenCategory(CategoryType chosenCategory) 
        {
            foreach (var category in _categoriesWon)
            {
                if (category.CategoryType == chosenCategory)
                {
                    return false;
                }
            }
            return true;
        }
        
        private void AddScore(int categoryScore)
        {
            Score += categoryScore;
        }
    }
}