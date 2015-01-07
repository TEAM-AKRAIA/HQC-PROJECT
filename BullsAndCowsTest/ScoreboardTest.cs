using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCowsTest
{
    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void TestScoreboardAddAndDisplayPlayers()
        {
            string result = "Scoreboard:\n" +
                    "1. eeeeee --> 1 guesses\n" +
                     "2. sdfs --> 2 guesses\n" +
                     "3. sdfs --> 3 guesses\n" +
                     "4. sdfs --> 4 guesses\n" +
                     "5. sdfs --> 5 guesses\n";
            var scboard = new Scoreboard();
            scboard.addNewPlayer("sdfs", 3);
            scboard.addNewPlayer("sdfs", 4);
            scboard.addNewPlayer("sdfs", 56);
            scboard.addNewPlayer("sdfs", 2);
            scboard.addNewPlayer("sdfs", 5);
            scboard.addNewPlayer("eeeeee", 1);
            Assert.AreEqual(scboard.ToString(), result);
        }
    }
}
