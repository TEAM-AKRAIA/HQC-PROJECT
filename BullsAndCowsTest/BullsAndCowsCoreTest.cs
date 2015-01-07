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

        [TestMethod]
        public void TestPrintCallMsg()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var game = new BullsAndCowsCore();
            game.PrintCallMsg();

            var output = outputWriter.ToString();
            var expectedOutput = "Enter your guess or command: ";

            Assert.AreEqual(output, expectedOutput, "Invalid call message.\n");
        }

        [TestMethod]
        public void TestPrintWrongNumberMsg()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var game = new BullsAndCowsCore();
            game.PrintWrongNumberMsg();

            var output = outputWriter.ToString();
            var expectedOutput = "Please enter a 4-digit number or\n" + "one of the commands: 'top', 'restart', 'help' or 'exit'.\n";

            Assert.AreEqual(output, expectedOutput, "Invalid wrong number message.\n");
        }

        [TestMethod]
        public void TestPrintFinalMsgWhenNoCheating()
        {
            int attempts = 5;
            int cheats = 0;
            var message = Messages.GetGreetingMsg(attempts, cheats);

            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var game = new BullsAndCowsCore();
            game.PrintFinalMsg();

            var output = outputWriter.ToString();
            var expectedOutput = "Congratulations! You guessed the secret number in 5 attempts.\n Please enter your name for the top scoreboard: ";

            Assert.AreEqual(output, expectedOutput, "Invalid final message no cheating.\n");
        }     
    }
}
