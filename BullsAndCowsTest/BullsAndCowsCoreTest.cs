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
        public void TestNumber1234()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var input = "1358\nexit";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var game = new BullsAndCowsCore();
            game.Run("1234");

            var output = outputWriter.ToString();
            var expectedOutput = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                                 "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n" +
                                 "Enter your guess or command: Wrong number! Bulls: 1, Cows: 1\n" +
                                 "Enter your guess or command: Good Bye!\n";

            Assert.AreEqual(output, expectedOutput, "Invalid start message.\n");

        }

        [TestMethod]
        public void TestWrongCommand()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var input = "ggggg\nexit";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var game = new BullsAndCowsCore();
            game.Run("1234");

            var output = outputWriter.ToString();
            var expectedOutput = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                                 "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n" +
                                 "Enter your guess or command: Please enter a 4-digit number or\none of the commands: 'top', 'restart', 'help' or 'exit'.\n" +
                                 "Enter your guess or command: Good Bye!\n";

            Assert.AreEqual(output, expectedOutput, "Invalid start message.\n");

        }

        [TestMethod]
        public void TestMakeNewJoker()
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var input = "help\nexit";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var game = new BullsAndCowsCore();
            game.Run("1234");

            var output = outputWriter.ToString();
            var words = output.Split(' ');
            var countX = words[44].Split('X').Length - 1;
            var expectedOutput = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                                 "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n" +
                                 "Enter your guess or command: Please enter a 4-digit number or\none of the commands: 'top', 'restart', 'help' or 'exit'.\n" +
                                 "Enter your guess or command: Good Bye!\n";

            int expectedCountX = 3;

            Assert.AreEqual(countX, expectedCountX, "Invalid count X.\n");

        }
    }
}
