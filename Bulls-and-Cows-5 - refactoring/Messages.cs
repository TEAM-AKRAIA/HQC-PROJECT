namespace BullsAndCowsGame
{
    using System;

    public static class Messages
    {
        public static string GetWelcomeMsg()
        {
            const string msg = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                               "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.\n";
            return msg;
        }

        public static string GetCallMsg()
        {
            var msg = "Enter your guess or command: ";
            return msg;
        }

        public static string GetGreetingMsg(int attempts, int cheats)
        {
            var msg = String.Format("Congratulations! You guessed the secret number in {0} attempts", attempts);

            if (cheats > 0)
            {
                msg += " and " + cheats + " cheats.\n" +
                       "You are not allowed to enter the top scoreboard.\n";
            }
            else
            {
                 msg += ".\n Please enter your name for the top scoreboard: ";
            }
           
            return msg;
        }

        public static string GetResultMsg(int bulls, int cows)
        {
            var msg = String.Format("Wrong number! Bulls: {0}, Cows: {1}\n", bulls, cows);
            return msg;
        }

        public static string GetWrongNumberMsg()
        {
            var msg = "Please enter a 4-digit number or\n" + "one of the commands: 'top', 'restart', 'help' or 'exit'.\n";
            return msg;
        }

        public static string GetHelpMsg(string joker)
        {
            var msg = String.Format("The number looks like {0}.\n", joker);
            return msg;
        }

        public static string GetGoodByeMsg()
        {
            var msg = "Good Bye!\n";
            return msg;
        }
    }
}
