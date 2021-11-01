using System.Collections.Generic;

namespace Yatzy
{
    public class GameDice //roll or hold
    {
        public List<Die> Dice;
        //private List<Die> _finalSelection;
  
        public GameDice(IRandomNumberGenerator randomNumberGenerator)
        {
            Dice = GameDiceGenerator.Generate(randomNumberGenerator); 
        }

        public void RollDice()
        {
            for (var i = 0; i < Dice.Count; i++)
            {
                if (!Dice[i].IsHeld())
                {
                    Dice[i].Roll();  
                }
            }
        }

        public void HoldDice(List<int> playersHeldDice) //passing in the dice index that player wants to hold
        {
            for (var i = 0; i < playersHeldDice.Count; i++)
            {
                Dice[playersHeldDice[i]].Hold();
            }
        }

        private List<int> GetDiceFaceValues()
        {
            List<int> facevalues = null;
            foreach (Die die in Dice)
            {
                facevalues.Add(die.Face);
            }
            return facevalues;
        }
        /*
         * This function has a time complexity of O(nk) - i mean like n*k
         * n being the length of valuesToHold
         * k being the length of Dice
         * It has a best case though, of 
         */
        // public List<int> FindDice(List<int> valuesToHold)
        // {
            // List<int> diceToHold = new List<int>();
            // Dictionary<int, List<int>> valueIndexees = new Dictionary<int, List<int>>();
            /*
             * [5, 5, 2] - values to hold
             * [ 5, 4, 5, 3, 2] - face values of dice
             * {}
             * 5 -> go to line 76 find me the five, if it's not the five i'm looking for, or an additional five, then add its index to the dictionary
             * diceToHold = [ 0 ]
             * valueIndexees = { 5: [2], 4: [1], 3: [3], 2: [4] }
             * 5 -> go to line 67, and my dictionary has the key
             * because of this I can lookup the value, and get a list of the indexes it occurs at
             * I take the first occurence from the dictionary,
             * add it to my diceToHold
             * remmove that occurence  from my dictionary
             * and i repeat this
             */
        //     for (var i = 0; i < valuesToHold.Count; i++)
        //     {
        //         var valueToFind = valuesToHold[i];
        //         
        //         if (valueIndexees.ContainsKey(valueToFind))
        //         {
        //             var index = valueIndexees[valueToFind][0];
        //             valueIndexees[valueToFind].RemoveAt(0);
        //             diceToHold.Add(index);
        //         }
        //         else
        //         {
        //             var foundValue = false;
        //             for (var k = 0; k < Dice.Count; k++)
        //             {
        //                 if (Dice[k].Face == valueToFind && !foundValue)
        //                 {
        //                     diceToHold.Add(k);
        //                     foundValue = true;
        //                 }
        //                 else
        //                 {
        //                     if (valueIndexees.ContainsKey(Dice[k].Face))
        //                     {
        //                         valueIndexees[Dice[k].Face].Add(k);
        //                     }
        //                     else
        //                     {
        //                         valueIndexees.Add(Dice[k].Face, new List<int>{ k });
        //                     }
        //                 }
        //             }
        //         }
        //         
        //         
        //     }
        //     
        //     return diceToHold;
        // }

        public List<int> FindDice(List<int> valuesToHold)
        { //5 5
            List<int> diceToHold = new List<int>();

            for (var i = 0; i < Dice.Count; i++)
            {
                foreach (var t in valuesToHold)
                {
                    if (Dice[i].Face == t)
                    {
                        diceToHold.Add(i);
                        break;
                        //stop
                    }
                }
            }

            return diceToHold;
        }
    }
}