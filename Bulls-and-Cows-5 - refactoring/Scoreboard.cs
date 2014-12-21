using System;
using System.Linq;

namespace BullsAndCowsGame
{
    using System.Collections.Generic;

    public class Scoreboard
    {
        private SortedList<int, string> highScoreList = new SortedList<int, string>();

        public void addNewPlayer(string name, int attempts)
        {
            if (highScoreList.Count < 5 || highScoreList.ElementAt(4).Key > attempts)
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");

                highScoreList.Add(attempts, name);
                if (highScoreList.Count == 6)
                {
                     highScoreList.RemoveAt(5);
                }                 
            }
        }

        public override string ToString()
        {
            string result;

            if (this.highScoreList.Count > 0)
            {
                result = "Scoreboard:\n";
                int playerRank = 1;
                foreach (var player in this.highScoreList)
                {
                    result += String.Format("{0}. {1} --> {2} guesses\n", playerRank, player.Value, player.Key);
                    playerRank++;
                }
            }
            else
            {
               result = "Top scoreboard is empty.\n";
            }

            return result;
        }
    }
}
