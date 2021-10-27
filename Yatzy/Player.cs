using System.Collections.Generic;

namespace Yatzy
{
    public class Player
    {
        //record which category the player has already won
        private readonly List<Category> _categoriesWon;
        //score
        public int Score { get; private set; }

        public Player()
        {
            _categoriesWon = new List<Category>();
            Score = 0;
        }
        
        //add to the list
        
        //get the list
        
        //score
    }
}