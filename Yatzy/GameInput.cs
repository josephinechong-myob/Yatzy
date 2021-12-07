using System.Collections.Generic;
using System.Linq;
using Yatzy.Categories;

namespace Yatzy
{
    public class GameInput
    {
        private readonly IConsole _console;
        private readonly PlayerInputValidator _playerInputValidator;

        public GameInput(IConsole console)
        {
            _console = console;
            _playerInputValidator = new PlayerInputValidator();
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
        
        private CategoryType GetSelectedCategory(List<CategoryType> types)
        {
            var chosenCategory = _console.ReadLine(); 
            while (!_playerInputValidator.IsOnlyNumbersOneToTen(chosenCategory))
            {
                _console.WriteLine("Please enter the number of the category you would like to select");
            
                chosenCategory = _console.ReadLine();
            }
           
            var categoryIndex = int.Parse(chosenCategory);
            var category = types.ElementAt(categoryIndex-1);
            return category;
        }
        
        private void PrintCategories(List<CategoryType> types)
        {
            
            for (var i=0; i < types.Count(); i++)
            {
                var categoryNumber = i + 1;
                _console.WriteLine($"[{categoryNumber}] - {types.ElementAt(i).ToString()}");
            }
        }
        
        private CategoryType RequestPlayersCategory(Player player)
        {
            _console.WriteLine($"Please select a category below:");
            
            var types = player.CategoryTypeRemaining;
            PrintCategories(types);
            
            var category = GetSelectedCategory(types);
            _console.WriteLine($"You have chosen {category} category");
            
            return category;
        }
        
        private SpecificNumberType RequestSpecificNumberType()
        {
            _console.WriteLine("Please enter a number from 1 to 6 which you want to use for your specific number");

            var playerInput = _console.ReadLine();
            while (!_playerInputValidator.IsOnlyNumbersOneToSix(playerInput))
            {
                _console.WriteLine("Please enter a number 1 to 6.");
                playerInput = _console.ReadLine();
            }
            
            var specificNumber = int.Parse(playerInput);
            var number = (SpecificNumberType) specificNumber;
            return number;
        }
        
        public void PlayerChoosesCategory(Player player, GameDice gameDice)
        {
            var chosenCategory = RequestPlayersCategory(player);
            
            if (chosenCategory == CategoryType.SpecificNumber)
            { 
                var specificNumber = RequestSpecificNumberType();
                var specificNumberCategory = new Category(specificNumber, gameDice.Dice);
                player.ChooseCategory(specificNumberCategory);
            }
            else
            {
                var category = new Category(chosenCategory, gameDice.Dice);
                player.ChooseCategory(category);  
            }
        }
    }
}