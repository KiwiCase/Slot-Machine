﻿namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bet = 0;
            int cash = 25;
            double lines = 0;
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];

            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
            while (cash > 0)
            {
                Console.WriteLine($"You currently have ${cash}.\nHow many lines would you like to play? Choose 1 to 8 lines to play: ");
                string input = Console.ReadLine();
                while (!double.TryParse(input, out lines) || lines > 8 || lines <= 0)
                {
                    Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                    input = Console.ReadLine();
                }
                if (lines < 8 || lines > 0)
                {
                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "Lines" : "line")}...\nHow many dollars per line would you like to bet? Maximum $3 per line: ");
                    input = Console.ReadLine();
                    while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
                    {
                        Console.WriteLine("This is not a valid input.\nPlease choose how many dollars per line you would like to bet - Maximum $3 per line:  ");
                        input = Console.ReadLine();
                    }
                    break;
                }
                break;
            }
            Console.WriteLine($"You are playing {lines} {(lines > 1 ? "Lines" : "line")} and betting ${bet} per line. Press Enter To Spin... ");
            string keyChoice = Console.ReadLine();

            for (int i = 0; i < slotNumber.GetLength(0); i++)
            {
                for (int j = 0; j < slotNumber.GetLength(1); j++)
                {
                    slotNumber[i, j] = rnd.Next(0, 9);
                    Console.Write("{0}\t", slotNumber[i, j]);
                }
                Console.Write("\n\n");
                while (cash > 0)
                {
                    if (slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                        Console.WriteLine("YOU WIN!");
                    else break;
                }
            }
        }

    }

}

