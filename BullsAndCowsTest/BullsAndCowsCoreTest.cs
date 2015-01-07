using System;
using System.IO;
using BullsAndCowsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCowsTest
{
    [TestClass]
    public class BullsAndCowsCoreTest
    {
        [TestMethod]
        public void TestPrintStartMsg()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var game = new BullsAndCowsCore();
            game.PrintStartMsg();

            var output = outputWriter.ToString();
            var expectedOutput = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                               "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n";

            Assert.AreEqual(output, expectedOutput, "Invalid start message.\n");

        }

        [TestMethod]
        public void TestPrintEndMsg()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var game = new BullsAndCowsCore();
            game.PrintEndMsg();

            var output = outputWriter.ToString();
            var expectedOutput = "Good Bye!\n";

            Assert.AreEqual(output, expectedOutput, "Invalid end message.\n");

        }
    }
}
