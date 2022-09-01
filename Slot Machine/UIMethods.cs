using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
                Int32.TryParse(input, out credits);

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
                Int32.TryParse(input, out lines);
            }
            return lines;
        }
        public static int NotEnoughCreditsToPlayLines(int credits)
        {
            Console.WriteLine($"You do not have enough credits to play this many lines. You currently have ${credits} - please choose less lines to play.\nHow many lines would you like to play?");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int lines);
            return lines;
        }
        public static int RequestBetToPlay(int lines)
        {
            Console.WriteLine($"\nYou are playing {lines} {(lines > 1 ? "lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
            string input = Console.ReadLine();

            int bet = 0;
            while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
            {
                Console.WriteLine("This is not a valid input - please choose how many dollars per line you would like to bet -\nMinimum $1 per line\nMaximum $3 per line:  ");
                input = Console.ReadLine();
                Int32.TryParse(input, out bet);
            }
            return bet;
        }

        public static int TotalBetAmount(int lines, int bet)
        {
            int totalBet = 0;
            totalBet = bet * lines;
            return totalBet;
        }
        public static int NotEnoughCreditsToPlayBet(int lines, int bet, int credits)
        {
            Console.WriteLine($"You do not have enough cash to bet this amount per line. You currently have ${credits} - please choose a less bet per line.\nMinimum $1 per line\nMaximum $3 per line: ");
            int totalBet = 0;
            string input = Console.ReadLine();
            Int32.TryParse(input, out bet);
            totalBet = lines * bet;
            Console.WriteLine(totalBet);
            return totalBet;
        }
    }
}
