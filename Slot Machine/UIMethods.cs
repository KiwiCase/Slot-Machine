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
            Console.WriteLine($"Welcome to Casey's Supremely Awesome Slot Machine!");
            return;
        }

        public static int RequestCashAmount()
        {
            int credits = 0;
            Console.WriteLine("How much cash would you like to use ? Minimum $1: ");
            string input = Console.ReadLine();
            return credits;
        }

        public static int CashAmountValidation(int credits, string input)
        {
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
            if (credits > 0)
            {
                Console.WriteLine("How many lines would you like to play? Choose 1 to 8 lines to play: ");
                string input = Console.ReadLine();
            }
            return lines;

        }

        public static int LineValidation(int lines)
        {
            string input = "";
            while (!Int32.TryParse(input, out lines) || lines > 8 || lines <= 0)
            {
                Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out lines);
            }
            return lines;
        }
    }
}
