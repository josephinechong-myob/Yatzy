using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy
{
    public class Player
    {
        //record which category the player has already won //list 
        private readonly List<Category> _categoriesWon;
        //score
        //name
        private IConsole _console;
        public int Score { get; private set; }

        public Player(IConsole console)
        {
            _categoriesWon = new List<Category>();
            Score = 0;
            _console = console;
        }
        
        //DisplayDice (private method)
        private void DisplayDice(List<Die> gameDice)
        {
            _console.WriteLine("Rolled dice are: ");
            foreach (Die die in gameDice)
            {
                _console.WriteLine($"{die.Face} ");
            }
        }

        private bool StringIsOnlyNumbersAndCommas(string playerInput)
        {
            var validPattern = new Regex("^[1-6],?[1-6]?,?[1-6]?,?[1-6]?,?[1-6]?$");
            return playerInput != string.Empty && validPattern.IsMatch(playerInput);
        }
        
        //hold should be on the player (all interactions with the player) - player need to proide a list of dice values to hold
        public List<int> ValuesToHold(List<Die> gameDice) //mock the console and write a test
        {
            var valuesToHold = new List<int>();
            var answer = string.Empty;
            DisplayDice(gameDice); //need to ask player if they even want to hold anything (that can be in the Game before this function is used)
            while (!StringIsOnlyNumbersAndCommas(answer)) //pass through the answer of a function 
            {
                _console.WriteLine("Please list all the numbers you would like to hold separated by comma ','. For example if you would to hold the same number twice please write it twice when listing. ");
            
                answer = _console.ReadLine(); //5,5 validate input with regex
            }
            
            var listOfStrings = answer.Split(",").ToList();
            foreach (var item in listOfStrings)
            {
                var number = int.Parse(item); //ask Jeremy what is better Parse or try parse - validation or try parse what if the user inputs something wrong like letters
                
                valuesToHold.Add(number);
            }
            return valuesToHold;
        }
        
        
        //choose catageory method
        
        //add to the list
        
        //get the list
        
        //score
    }
}