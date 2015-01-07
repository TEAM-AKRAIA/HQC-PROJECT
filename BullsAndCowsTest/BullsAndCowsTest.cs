using System;
using System.IO;
using BullsAndCowsGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCowsTest
{
    [TestClass]
    public class BullsAndCowsTest
    {
        [TestMethod]
        public void TestMainMethod()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var input = "exit";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            BullsAndCows.Main();

            var output = outputWriter.ToString();
            var expectedOutput = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n" +
                    "Enter your guess or command: " +
                    "Good Bye!\n";

            Assert.AreEqual(output, expectedOutput, "Invalid start message.\n");

        }
    }
}
