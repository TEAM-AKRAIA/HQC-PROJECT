using System;
using System.Text.RegularExpressions;

namespace BullsAndCowsGame
{
    class BullsAndCowsCore
    {
        private Random randomGenerator = new Random();
        private string computerNumber;
        private Scoreboard scoreboard = new Scoreboard();
        private int attempts;
        private int cheats;
        private string joker;
        private int bulls;
        private int cows;

        public BullsAndCowsCore()
        {
        }

        private void CreateComputerNumber()
        {
            const int MinNumber = 1000;
            const int MaxNumber = 10000;
            this.computerNumber = randomGenerator.Next(MinNumber, MaxNumber).ToString();
        }

        private string ReadPlayerInput()
        {
            string input = Console.ReadLine().Trim();
            return input;
        }

        public void Run()
        {
            this.PrintStartMsg();

            bool isBreaked = false;
            while (!isBreaked)
            {
                CreateComputerNumber();
                this.attempts = 1;
                this.joker = "XXXX";

                bool isRestarted = false;
                while (!isBreaked && !isRestarted)
                {
                    this.PrintCallMsg();
                    var command = ReadPlayerInput();

                    switch (command)
                    {
                        case "top":
                            this.PrintScoreboard();
                            break;
                        case "help":
                            this.PrintJoker();
                            this.cheats++;
                            break;
                        case "restart":
                            this.PrintMessage("\n");
                            this.PrintStartMsg();
                            isRestarted = true;
                            break;
                        case "exit":
                            this.PrintEndMsg();
                            isBreaked = true;
                            break;
                        default:
                            try
                            {
                                CheckForValidNumber(command);
                                CountBullsAndCows(command);
                                if (this.bulls == 4)
                                {
                                    this.PrintFinalMsg();
                                    this.PrintMessage("\n");
                                    this.PrintStartMsg();
                                    isRestarted = true;
                                }
                                else
                                {
                                    this.PrintCountOfBullsAndCowsMsg();
                                }

                                this.attempts++;
                            }
                            catch (Exception)
                            {
                                this.PrintWrongNumberMsg();
                            }

                            break;
                    }
                }
            }
        }

        private void MakeNewJoker()
        {
            if (this.joker.IndexOf('X') >= 0)
            {
                int i;
                do
                {
                    i = this.randomGenerator.Next(0, 4);
                }
                while (this.joker[i] != 'X');

                char[] digits = this.joker.ToCharArray();
                digits[i] = computerNumber[i];
                this.joker = new string(digits);
            }
        }

        private void CountBullsAndCows(string guessNumber)
        {
            bool[] isBull = new bool[4];
            this.bulls = 0;
            this.cows = 0;
            for (int i = 0; i < 4; i++)
            {
                isBull[i] = (this.computerNumber[i] == guessNumber[i]);
                if (isBull[i])
                {
                    this.bulls++;
                }
            }


            int[] digs = new int[10];
            for (int d = 0; d < 10; d++)
            {
                digs[d] = 0;
            }


            for (int i = 0; i < 4; i++)
            {
                if (!isBull[i])
                {
                    digs[this.computerNumber[i] - '0']++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (!isBull[i])
                {
                    if (digs[guessNumber[i] - '0'] > 0)
                    {
                        this.cows++;
                        digs[guessNumber[i] - '0']--;
                    }
                }
            }
        }


        private void CheckForValidNumber(string number)
        {
            var patt = new Regex("[1-9]\\d{3}");
            if (!patt.IsMatch(number) || number.Length > 4)
            {
                throw new ApplicationException("Number must be of 4 digits.");
            }
        }

        private void PrintMessage(string message)
        {
            Console.Write(message);
        }

        private void PrintStartMsg()
        {
            var message = Messages.GetWelcomeMsg();
            this.PrintMessage(message);
        }


        private void PrintJoker()
        {
            this.MakeNewJoker();
            var message = Messages.GetHelpMsg(this.joker);
            this.PrintMessage(message);
        }

        private void PrintEndMsg()
        {
            var message = Messages.GetGoodByeMsg();
            this.PrintMessage(message);
        }

        private void PrintCountOfBullsAndCowsMsg()
        {
            var message = Messages.GetResultMsg(this.bulls, this.cows);
            this.PrintMessage(message);
        }

        private void PrintCallMsg()
        {
            var message = Messages.GetCallMsg();
            this.PrintMessage(message);
        }

        private void PrintWrongNumberMsg()
        {
            var message = Messages.GetWrongNumberMsg();
            this.PrintMessage(message);
        }

        private void PrintScoreboard()
        {
            var message = this.scoreboard.ToString();
            this.PrintMessage(message);
        }


        private void PrintFinalMsg()
        {
            var message = Messages.GetGreetingMsg(this.attempts, this.cheats);

            if (this.cheats == 0)
            {
                this.PrintMessage(message);
                var name = this.ReadPlayerInput();
                scoreboard.addNewPlayer(name, attempts);
                this.PrintScoreboard();
            }
            else
            {
                this.PrintMessage(message);
            }
        }

    }
}
