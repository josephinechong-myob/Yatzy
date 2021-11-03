namespace Yatzy
{
    public class Game
    { 
        //players should be in a list or array and loop through 
        private readonly IConsole _console;
        private GameDice _gamedice;
        public Game(IConsole console)
        {
            _console = console;
            var randomNumberGenerator = new RandomNumberGenerator();
            _gamedice = new GameDice(randomNumberGenerator);
        }
        
        public void Run()
        {
            _console.WriteLine("Welcome to Yatzy. \nWhat is you name?");
            var playerName = _console.ReadLine();
            _console.WriteLine("Would you like to play a game? Y - yes or N - no");
            var playerChoice = _console.ReadLine();
            if (playerChoice == "Y")
            {
                // roll dice
                _gamedice.RollDice();
            }
            else if (playerChoice == "N")
            {
                return;
            }


            //player rolls dice (new instance of gamedice)
            //optional to hold and re-roll (3 times total)
            //player chooses a category (per player record)
            //player obtains a score & adds to total score (per player record)
            //category is removed from options to choose in next roll

            //changes player (alternate rolls) or player 1 plays and finishes game before player 2?

            //repeat until all categories are used to complete the game

            //put into an object and rotate the object, or put players in a list and rotate the list 
        }
        
        //Rolling dice
        
        //Rolling with held numbers
        
        //Reset game
    }
}