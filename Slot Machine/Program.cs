namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
            int rowValue = 0;
            int colValue = 0;
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slotNumber[i, j] = rnd.Next(0, 9);
                }
            }
        }

    }
}
