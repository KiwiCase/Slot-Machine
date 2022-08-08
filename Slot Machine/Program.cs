namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Casey's Supremely Awesome Slot Machine!");
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
