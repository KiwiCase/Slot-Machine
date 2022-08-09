namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int cash = 50;
            double lines;
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];
  
            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
            Console.WriteLine($"You currently have ${cash} left.\nHow many lines would you like to play? Choose 1 to 8 lines to play.");
            while (!double.TryParse(Console.ReadLine(), out lines))
            {
                Console.WriteLine("This is not a valid input. Please choose 1 to 8 lines to play.");
            }

            Console.WriteLine("Press Enter to Start...");


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
