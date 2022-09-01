using Slot_Machine;
using System;

namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Important variables and Random Number Generator
            int bet = 0;
            int credits = 0;
            char playAgain = 'Y';
            string response;
            string input = "";
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];

            //Console.WriteLine($"Welcome to Casey's Supremely Awesome Slot Machine!") - Method below
            UIMethods.DisplayWelcomeMessage();

            //Console.WriteLine("How much cash would you like to use? Minimum $1: ") - Method below
            credits = UIMethods.RequestCashToPlay();

            /*
            while (!Int32.TryParse(input, out credits) || credits < 1)
            {
                Console.WriteLine("This is not a valid input.\nPlease choose how much cash you would like to use - Minimum $1: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out credits);
            }*/

            //Play Again loop
            while (playAgain == 'Y')
            {
                //Lines played and betting amount variables. No invalid inputs
                int lines = 0;
                int totalLines = 0;
                int totalBet = bet * lines;
                int singleLineWinnings = totalLines * bet;
                if (credits > 0)
                {
                    /*Console.WriteLine("How many lines would you like to play? Choose 1 to 8 lines to play: ");
                    input = Console.ReadLine();

                    while (!Int32.TryParse(input, out lines) || lines > 8 || lines <= 0)
                    {
                        Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out lines);
                    }*/
                    lines = UIMethods.RequestLinesToPlay(credits);

                    while (lines > credits)
                    {
                        Console.WriteLine($"You do not have enough credits to play this many lines. You currently have ${credits} - please choose less lines to play.\nHow many lines would you like to play?");
                        input = Console.ReadLine();
                    }

                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
                    input = Console.ReadLine();

                    while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
                    {
                        Console.WriteLine("This is not a valid input - please choose how many dollars per line you would like to bet -\nMinimum $1 per line\nMaximum $3 per line:  ");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out bet);
                    }

                    totalBet = bet * lines;
                    while (totalBet > credits)
                    {
                        Console.WriteLine($"You do not have enough cash to bet this amount per line. You currently have ${credits} - please choose a less bet per line.\nMinimum $1 per line\nMaximum $3 per line: ");
                        input = Console.ReadLine();
                        totalBet = 0;
                        Int32.TryParse(input, out bet);
                        totalBet = bet * lines;
                    }

                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "lines" : "line")} and betting ${bet} per line for a total of ${totalBet}. Press Enter To Spin... ");
                    string keyChoice = Console.ReadLine();
                }


                //Creates grid array of 9 random numbers
                for (int i = 0; i < slotNumber.GetLength(0); i++)
                {
                    for (int j = 0; j < slotNumber.GetLength(1); j++)
                    {

                        {
                            slotNumber[i, j] = rnd.Next(0, 4);
                            Console.Write("{0}\t", slotNumber[i, j]);
                        }
                    }
                    Console.Write("\n\n");

                }
                //Checks each line for matching numbers
                totalLines = 0;
                if (lines > 0)
                {
                    if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2])
                    {
                        totalLines++;
                    }
                }

                if (lines > 1)
                {
                    if (slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                    {
                        totalLines++;
                    }
                }

                if (lines > 2)
                {
                    if (slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2])
                    {
                        totalLines++;
                    }
                }

                if (lines > 3)
                {
                    if (slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2])
                    {
                        totalLines++;
                    }
                }

                if (lines > 4)
                {
                    if (slotNumber[2, 0] == slotNumber[1, 1] && slotNumber[2, 0] == slotNumber[0, 2])
                    {
                        totalLines++;
                    }
                }

                if (lines > 5)
                {
                    if (slotNumber[0, 0] == slotNumber[1, 0] && slotNumber[0, 0] == slotNumber[2, 0])
                    {
                        totalLines++;
                    }
                }

                if (lines > 6)
                {
                    if (slotNumber[0, 1] == slotNumber[1, 1] && slotNumber[0, 1] == slotNumber[2, 1])
                    {
                        totalLines++;
                    }
                }

                if (lines > 7)
                {
                    if (slotNumber[0, 2] == slotNumber[1, 2] && slotNumber[0, 2] == slotNumber[2, 2])
                    {
                        totalLines++;
                    }
                }

                response = "";
                if (totalLines > 0)
                {
                    //Payout calculation and Play Again
                    singleLineWinnings = totalLines * bet;
                    credits += singleLineWinnings;
                    Console.WriteLine($"You won {totalLines} {(totalLines > 1 ? "lines" : "line")} and ${singleLineWinnings}!\nYou have a total of ${credits} left.\nPress Y to play again or N to quit.");
                    response = Console.ReadKey().KeyChar.ToString().ToUpper();

                }

                else totalLines = 0;
                {
                    //Loss deduction calculation and Play Again
                    credits -= totalBet;
                    if (credits > 0)
                    {
                        Console.WriteLine($"You lost ${totalBet}!\nYou have a total of ${credits} left.\nPress Y to play again or N to quit.");
                        response = Console.ReadKey().KeyChar.ToString().ToUpper();

                    }

                    if (credits == 0)
                    {
                        Console.WriteLine($"You lost ${totalBet}!\nYou have a total of ${credits} left and cannot continue playing.\nGoodbye!");
                        break;
                    }

                }

                if (response == "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("OK then...Goodbye!");
                    break;
                }

            }

        }
    }

}







