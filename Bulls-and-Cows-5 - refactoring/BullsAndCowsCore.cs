using System;
using System.Text.RegularExpressions;

namespace BullsAndCowsGame
{
    public class BullsAndCowsCore
    {
        private Random randomGenerator = new Random();
        private Scoreboard scoreboard = new Scoreboard();

        private Random RandomGenerator
        {
            get { return this.randomGenerator; }
        }

        public string ComputerNumber { private get; set; }

        private Scoreboard Scoreboard
        {
            get { return this.scoreboard; }
        }

        private int Attempts { get; set; }

        private int Cheats { get; set; }

        private string Joker { get; set; }

        private int Bulls { get; set; }

        private int Cows { get; set; }

        private void CreateComputerNumber()
        {
            const int MinNumber = 1000;
            const int MaxNumber = 10000;
            this.ComputerNumber = randomGenerator.Next(MinNumber, MaxNumber).ToString();
        }

        private string ReadPlayerInput()
        {
            string input = Console.ReadLine().Trim();
            return input;
        }

        public void Run(string testNumber)
        {
            this.PrintStartMsg();

            bool isBreaked = false;
            while (!isBreaked)
            {
                if (string.IsNullOrEmpty(testNumber))
                {
                    CreateComputerNumber();
                }
                else
                {
                    ComputerNumber = testNumber;
                }

                this.Attempts = 1;
                this.Joker = "XXXX";

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
                            this.Cheats++;
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
                                if (this.Bulls == 4)
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

                                this.Attempts++;
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
            if (this.Joker.IndexOf('X') >= 0)
            {
                int i;
                do
                {
                    i = this.randomGenerator.Next(0, 4);
                }
                while (this.Joker[i] != 'X');

                char[] digits = this.Joker.ToCharArray();
                digits[i] = ComputerNumber[i];
                this.Joker = new string(digits);
            }
        }

        private void CountBullsAndCows(string guessNumber)
        {
            bool[] isBull = new bool[4];
            this.Bulls = 0;
            this.Cows = 0;
            for (int i = 0; i < 4; i++)
            {
                isBull[i] = (this.ComputerNumber[i] == guessNumber[i]);
                if (isBull[i])
                {
                    this.Bulls++;
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
                    digs[this.ComputerNumber[i] - '0']++;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (!isBull[i])
                {
                    if (digs[guessNumber[i] - '0'] > 0)
                    {
                        this.Cows++;
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

        //tested
        public void PrintStartMsg()
        {
            var message = Messages.GetWelcomeMsg();
            this.PrintMessage(message);
        }


        private void PrintJoker()
        {
            this.MakeNewJoker();
            var message = Messages.GetHelpMsg(this.Joker);
            this.PrintMessage(message);
        }

        //tested
        public void PrintEndMsg()
        {
            var message = Messages.GetGoodByeMsg();
            this.PrintMessage(message);
        }


        private void PrintCountOfBullsAndCowsMsg()
        {
            var message = Messages.GetResultMsg(this.Bulls, this.Cows);
            this.PrintMessage(message);
        }

        //tested
        public void PrintCallMsg()
        {
            var message = Messages.GetCallMsg();
            this.PrintMessage(message);
        }

        //tested
        public void PrintWrongNumberMsg()
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
            var message = Messages.GetGreetingMsg(this.Attempts, this.Cheats);

            if (this.Cheats == 0)
            {
                this.PrintMessage(message);
                var name = this.ReadPlayerInput();
                scoreboard.addNewPlayer(name, Attempts);
                this.PrintScoreboard();
            }
            else
            {
                this.PrintMessage(message);
            }
        }

    }
}
