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
            Console.WriteLine("How much cash would you like to use ? Minimum $1: ");
            string input = Console.ReadLine();
            while (!Int32.TryParse(input, out credits) || credits < 1)
            {
                Console.WriteLine("This is not a valid input.\nPlease choose how much cash you would like to use - Minimum $1: ");
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
        public static int NotEnoughCreditsToPlayLines(int credits)
        {
            Console.WriteLine($"You do not have enough credits to play this many lines. You currently have ${credits} - please choose less lines to play.\n");
            return credits;
        }
        public static int RequestBetToPlay(int lines)
        {
            Console.WriteLine($"\nYou are playing {lines} {(lines > 1 ? "lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
            string input = Console.ReadLine();

            int bet = 0;
            while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
            {
                Console.WriteLine("This is not a valid input.");
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

        public static string PressEnterToSpin(int totalBet, int lines, int bet)
        {
            Console.WriteLine($"\nYou are playing {lines} {(lines > 1 ? "lines" : "line")} and betting ${bet} per line for a total of ${totalBet}. Press Enter To Spin... ");
            string keyChoice = Console.ReadLine();
            return keyChoice;
        }
        public static int SingleLineWinningsAmount(int totalLines, int bet)
        {
            int singleLineWinnings = totalLines * bet;
            return singleLineWinnings;
        }
        public static int TotalCreditsAmount(int credits, int singleLineWinnings)
        {
            credits += singleLineWinnings;
            return credits;
        }
        public static void YouWon(int totalLines, int singleLineWinnings, int credits)
        {
            Console.WriteLine($"You won {totalLines} {(totalLines > 1 ? "lines" : "line")} and ${singleLineWinnings}!\nYou have a total of ${credits} left.");
        }
        public static string YouWonPlayAgain(string response)
        {
            Console.WriteLine("Press Y to play again or N to quit: ");
            response = Console.ReadKey().KeyChar.ToString().ToUpper();
            return response;
        }
    }
}

