namespace Yatzy
{
    static class Program
    {
        static void Main(string[] args)
        {
            var console = new GameConsole();
            var randomNumberGenerator = new RandomNumberGenerator();
            var game = new Game(console, randomNumberGenerator);
            game.Run(); //do we have to test program - ask jeremy - integrated tests?
            //what would make an intergrated test - is the game test with all 10 cats for reseting game consitered an integrated test?
            //public methods are first - to tidy up
            //can things be made readonly and private
            //repetition or super long methods and make it smaller
            
            //intergrated test - testing your app with other systems so reset test is not integrated test - end to end test would test from the boundaries 
            //integrated tests - test funtionality in isolation and not na end to end test
            //end-to-end test - test entrie progam funcitonality (including automation for input)
            //don't have to test program file
            
            
            
        }
    }
}