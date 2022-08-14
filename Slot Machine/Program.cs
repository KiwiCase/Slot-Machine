using System;

namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bet = 0;
            int cash = 25;
            int lines = 0;
            int singleSlotNumber = 0;
            char playAgain = 'Y';
            string input = "";
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];

            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
            while (cash > 0)
            {
                while (playAgain == 'Y')
                {
                    Console.WriteLine($"You currently have ${cash}.\nHow many lines would you like to play? Choose 1 to 8 lines to play: ");
                    input = Console.ReadLine();
                    while (!Int32.TryParse(input, out lines) || lines > 8 || lines <= 0)
                    {
                        Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out lines);
                    }
                    while (lines > cash)
                    {
                        Console.WriteLine($"You do not have enough cash to play this many lines. You currently have ${cash} - please choose less lines to play.\nHow many lines would you like to play?");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out lines);
                    }
                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
                    input = Console.ReadLine();
                    while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
                    {
                        Console.WriteLine("This is not a valid input - please choose how many dollars per line you would like to bet -\nMinimum $1 per line\nMaximum $3 per line:  ");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out bet);
                    }
                    while ((bet * lines) > cash)
                    {
                        Console.WriteLine($"You do not have enough cash to bet this amount per line. You currently have ${cash} - please choose a less bet per line.\nMinimum $1 per line\nMaximum $3 per line: ");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out bet);
                    }

                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "lines" : "line")} and betting ${bet} per line for a total of ${lines * bet}. Press Enter To Spin... ");
                    string keyChoice = Console.ReadLine();
                    break;
                }
                for (int i = 0; i < slotNumber.GetLength(0); i++)
                {
                    for (int j = 0; j < slotNumber.GetLength(1); j++)
                    {
                        if (singleSlotNumber < 9)
                        {
                            slotNumber[i, j] = rnd.Next(0, 2);
                            Console.Write("{0}\t", slotNumber[i, j]);
                            singleSlotNumber++;
                        }
                    }
                    Console.Write("\n\n");
                }
                switch (lines)
                {
                    case 1:
                        if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");

                        }
                        break;
                    case 2:
                        if (slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                            
                        }
                        break;
                    case 3:
                        if (slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                            
                        }
                        break;
                    case 4:
                        if (slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                            
                        }
                        break;
                    case 5:
                        if (slotNumber[2, 0] == slotNumber[1, 2] && slotNumber[2, 0] == slotNumber[0, 2])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                            
                        }
                        break;
                    case 6:
                        if (slotNumber[0, 0] == slotNumber[1, 0] && slotNumber[0, 0] == slotNumber[2, 0])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                           
                        }
                        break;
                    case 7:
                        if (slotNumber[0, 1] == slotNumber[1, 1] && slotNumber[0, 1] == slotNumber[2, 1])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        }
                        break;
                    case 8:
                        if (slotNumber[0, 1] == slotNumber[1, 1] && slotNumber[0, 1] == slotNumber[2, 1])
                        {
                            Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        }
                        break;
                }
            }
            while (lines == 2)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] || slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                {
                    Console.WriteLine($"YOU WIN! You won ${bet * 1} and have ${(cash) + bet * 1} left");
                    break;
                }
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                {
                    Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                    break;
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            while (lines == 3)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2] && slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2])
                {
                    Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                    break;
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            while (lines == 4)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2] && slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2] && slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2])
                {
                    {
                        Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        break;
                    }
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            while (lines == 5)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2] && slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2] && slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2] && slotNumber[2, 0] == slotNumber[1, 1] && slotNumber[2, 0] == slotNumber[0, 2])
                {
                    {
                        Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        break;
                    }
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            while (lines == 6)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2] && slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2] && slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2] && slotNumber[2, 0] == slotNumber[1, 1] && slotNumber[2, 0] == slotNumber[0, 2] && slotNumber[0, 0] == slotNumber[1, 0] && slotNumber[0, 0] == slotNumber[2, 0])
                {
                    {
                        Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        break;
                    }
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            while (lines == 7)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2] && slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2] && slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2] && slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2] && slotNumber[2, 0] == slotNumber[1, 1] && slotNumber[2, 0] == slotNumber[0, 2] && slotNumber[0, 0] == slotNumber[1, 0] && slotNumber[0, 0] == slotNumber[2, 0])
                {
                    {
                        Console.WriteLine($"YOU WIN! You won ${lines * bet} and have ${(cash) + lines * bet} left");
                        break;
                    }
                }
                else Console.WriteLine($"You lost ${lines * bet} and have ${(cash) - lines * bet} left.");
                break;
            }
            if (cash > 0)
                Console.WriteLine("Continue playing? Press Y to play again or N to stop.");
        }

    }

}




