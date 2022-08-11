namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bet = 0;
            int cash = 2;
            int lines = 0;
            int singleSlotNumber = 0;
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];

            static int cashCheck(int lines, int cash)
            {
                int result = lines * 1;
                return result;
            }
            static int multiplier(int lines, int bet)
            {
                int result = lines * bet;
                return result;
            }

            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
            while (cash > 0)
            {
                Console.WriteLine($"You currently have ${cash}.\nHow many lines would you like to play? Choose 1 to 8 lines to play: ");
                string input = Console.ReadLine();
                while (!Int32.TryParse(input, out lines) || lines > 8 || lines <= 0)
                {
                    Console.WriteLine("This is not a valid input.\nPlease choose 1 to 8 lines to play: ");
                    input = Console.ReadLine();
                }
                while ((lines * 1) > cash)
                {
                    Console.WriteLine($"You do not have enough cash to bet this many lines. You currently have ${cash} - please choose less lines to play.\nHow many lines would you like to play?");
                    input = Console.ReadLine();
                }
                if (lines < 8 || lines > 0)
                {
                    Console.WriteLine($"You are playing {lines} {(lines > 1 ? "Lines" : "line")}...\nHow many dollars per line would you like to bet?\nMinumum $1 per line\nMaximum $3 per line: ");
                    input = Console.ReadLine();
                    while (!Int32.TryParse(input, out bet) || bet > 3 || bet <= 0)
                    {
                        Console.WriteLine("This is not a valid input.\nPlease choose how many dollars per line you would like to bet - Maximum $3 per line:  ");
                        input = Console.ReadLine();
                    }
                    break;
                }
            }

            if (lines > 1)
            {
                cash -= multiplier(lines, bet);
            }
            else cash -= bet;
            Console.WriteLine($"You are playing {lines} {(lines > 1 ? "Lines" : "line")} and betting ${bet} per line for a total of ${lines * bet}. Press Enter To Spin... ");
            string keyChoice = Console.ReadLine();

            for (int i = 0; i < slotNumber.GetLength(0); i++)
            {
                for (int j = 0; j < slotNumber.GetLength(1); j++)
                {
                    if (singleSlotNumber < 9)
                    {
                        slotNumber[i, j] = rnd.Next(0, 9);
                        Console.Write("{0}\t", slotNumber[i, j]);
                        singleSlotNumber++;
                    }
                }
                Console.Write("\n\n");
            }
        }

    }

}

