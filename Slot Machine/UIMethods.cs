using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class UIMethods
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
        }

        public static int RequestCreditsToPlay()
        {
            int credits = 0;
            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("How much cash would you like to use ? Minimum $2: ");
            string input = Console.ReadLine();
            while (!Int32.TryParse(input, out credits) || credits < 2)
            {
                Console.WriteLine("\nThis is not a valid input.\nPlease choose how much cash you would like to use - Minimum $2: ");
                input = Console.ReadLine();
            }
            return credits;
        }

        public static int RequestLinesToPlay(int credits)
        {
            int lines = 0;
            Console.WriteLine("\nHow many lines would you like to play? Choose 1 to 8 lines to play: ");
            string input = Console.ReadLine();

            while (!Int32.TryParse(input, out lines) || lines > 8 || lines <= 0)
            {
                Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                input = Console.ReadLine();
            }
            return lines;
        }

        public static void NotEnoughCreditsToPlayLines(int credits)
        {
            Console.WriteLine($"\nYou do not have enough credits to play this many lines. You currently have ${credits} - please choose less lines to play.");
        }

        public static int RequestBetToPlay(int lines)
        {
            Console.WriteLine($"\nYou are playing {lines} {(lines > 1 ? "lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
            string input = Console.ReadLine();

            int bet = 0;
            while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
            {
                Console.WriteLine("\nThis is not a valid input.");
                input = Console.ReadLine();
            }
            return bet;
        }

        public static int TotalBetAmount(int lines, int bet)
        {
            int totalBet = lines * bet;
            return totalBet;
        }

        public static void NotEnoughCreditsToPlayBet(int credits)
        {
            Console.WriteLine($"You do not have enough cash to bet this amount per line. You currently have ${credits}");
        }

        public static void PressEnterToSpin(int totalBet, int lines, int bet)
        {
            Console.WriteLine($"\nYou are playing {lines} {(lines > 1 ? "lines" : "line")} and betting ${bet} per line for a total of ${totalBet}. Press Enter To Spin... ");
            string keyChoice = Console.ReadLine();
        }

        public static void PrintArray(int[,] slotNumber)
        {
            for (int i = 0; i < slotNumber.GetLength(0); i++)
            {
                for (int j = 0; j < slotNumber.GetLength(1); j++)
                {
                    {
                        Random rnd = new Random();
                        slotNumber[i, j] = rnd.Next(0, 4);

                    }
                }
            }
        }


        //Console.Write("{0}\t", slotNumber[i, j]);
        //Console.Write("\n\n");


        public static int SingleLineWinningsAmount(int totalLines, int bet)
        {
            int singleLineWinnings = totalLines * bet;
            return singleLineWinnings;
        }

        public static int TotalWonAndCreditsAmount(int credits, int singleLineWinnings)
        {
            credits += singleLineWinnings;
            return credits;
        }

        public static void YouWon(int totalLines, int singleLineWinnings, int credits)
        {
            Console.WriteLine($"You won {totalLines} {(totalLines > 1 ? "lines" : "line")} and ${singleLineWinnings}!\nYou have a total of ${credits} left.");
        }

        public static string PlayAgain(string response)
        {
            Console.WriteLine("Press Y to play again or N to quit: ");
            response = Console.ReadKey().KeyChar.ToString().ToUpper();
            return response;
        }

        public static void YouLost(int totalBet, int credits)
        {
            Console.WriteLine($"You lost ${totalBet}!\nYou have a total of ${credits} left.");
        }

        public static void PlayAgainNo()
        {
            Console.WriteLine();
            Console.WriteLine("OK then...Goodbye!");
        }
    }
}

