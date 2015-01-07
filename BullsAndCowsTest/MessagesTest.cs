using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCowsTest
{
    [TestClass]
    public class MessagesTest
    {
        [TestMethod]
        public void TestPrintGetWelcomeMsg()
        {
            string result = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                               "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n";
            var message = Messages.GetWelcomeMsg();
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetCallMsg()
        {
            string result = "Enter your guess or command: ";
            var message = Messages.GetCallMsg();
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetGreetingMsgWhenNoCheating()
        {
            int attempts = 5;
            int cheats = 0;
            var result = String.Format("Congratulations! You guessed the secret number in {0} attempts", attempts);
            result += ".\n Please enter your name for the top scoreboard: ";
            var message = Messages.GetGreetingMsg(attempts, cheats);
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetGreetingMsgWhenCheating()
        {
            int attempts = 5;
            int cheats = 2;
            var result = String.Format("Congratulations! You guessed the secret number in {0} attempts", attempts);
            result += " and " + cheats + " cheats.\n" +
                       "You are not allowed to enter the top scoreboard.\n";
            var message = Messages.GetGreetingMsg(attempts, cheats);
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetResultMsg()
        {
            int bulls = 2;
            int cows = 1;
            var result = String.Format("Wrong number! Bulls: {0}, Cows: {1}\n", bulls, cows);
            var message = Messages.GetResultMsg(bulls, cows);
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetWrongNumberMsg()
        {
            string result = "Please enter a 4-digit number or\n" + "one of the commands: 'top', 'restart', 'help' or 'exit'.\n";
            var message = Messages.GetWrongNumberMsg();
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetHelpMsg()
        {
            string joker = "XXXX";
            var result = String.Format("The number looks like {0}.\n", joker);
            var message = Messages.GetHelpMsg(joker);
            Assert.AreEqual(message, result);
        }

        [TestMethod]
        public void TestGetGoodByeMsg()
        {
            string result = "Good Bye!\n";
            var message = Messages.GetGoodByeMsg();
            Assert.AreEqual(message, result);
        }
    }
}
