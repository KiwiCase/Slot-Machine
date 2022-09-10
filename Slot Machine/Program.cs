using Slot_Machine;
using System;

namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage();

            int credits = UIMethods.RequestCreditsToPlay();

            //Play Again loop
            char playAgain = 'Y';
            while (true)
            {
                int lines = 0;
                int bet = 0;
                int totalBet = 0;
                if (credits < 2)
                {
                    credits = UIMethods.RequestCreditsToPlay();
                }
                //Lines played and betting amount variables.
                else
                {
                    lines = UIMethods.RequestLinesToPlay(credits);

                    while (lines > credits)
                    {
                        UIMethods.NotEnoughCreditsToPlayLines(credits);
                        lines = UIMethods.RequestLinesToPlay(credits);
                    }

                    bet = UIMethods.RequestBetToPlay(lines);

                    totalBet = UIMethods.TotalBetAmount(lines, bet);

                    while (totalBet > credits)
                    {
                        UIMethods.NotEnoughCreditsToPlayBet(credits);
                        bet = UIMethods.RequestBetToPlay(lines);
                        totalBet = UIMethods.TotalBetAmount(lines, bet);
                    }

                    //Credits deducting Bet

                    Console.WriteLine(credits);

                    UIMethods.PressEnterToSpin(totalBet, lines, bet);

                }
                //2D Array Generator and Printer
                int[,] slotNumber = Logic.GenerateArray();
                UIMethods.PrintArray(slotNumber);

                int totalLines = Logic.TotalLinesWon(slotNumber, lines);

                string response = "";
                if (totalLines > 0)
                {
                    //Payout calculation and Play Again
                    credits = Logic.BetDeduction(credits, totalBet);
                    int singleLineWinnings = UIMethods.SingleLineWinningsAmount(totalLines, bet);
                    credits = UIMethods.TotalWonAndCreditsAmount(credits, singleLineWinnings);
                    UIMethods.YouWon(totalLines, singleLineWinnings, credits);
                    response = UIMethods.PlayAgain(response);
                }

                else
                {
                    //Loss deduction calculation and Play Again
                    credits = Logic.BetDeduction(credits, totalBet);
                    UIMethods.YouLost(totalBet, credits);
                    response = UIMethods.PlayAgain(response);
                }

                if (response == "N")
                {
                    UIMethods.PlayAgainNo();
                    break;
                }

            }

        }
    }

}







