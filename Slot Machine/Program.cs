using Slot_Machine;
using System;

namespace SlotMachineGame
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Important variables and Random Number Generator
            int credits = 0;
            char playAgain = 'Y';
            string response;
            Random rnd = new Random();

            UIMethods.DisplayWelcomeMessage();

            credits = UIMethods.RequestCreditsToPlay();

            //Play Again loop
            while (playAgain == 'Y')
            {
                //Lines played and betting amount variables.
                int lines = 0;
                int bet = 0;
                int totalBet = 0;
                if (credits > 0)
                {
                    lines = UIMethods.RequestLinesToPlay(credits);

                    while (lines > credits)
                    {
                        lines = UIMethods.NotEnoughCreditsToPlayLines(credits);
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

                    credits = Logic.BetDeduction(credits, totalBet);
                    string keyChoice = UIMethods.PressEnterToSpin(totalBet, lines, bet);
                }

                //Creates grid array of 9 random numbers
                rnd = new Random();
                int[,] slotNumber = new int[3, 3];
                for (int i = 0; i < slotNumber.GetLength(0); i++)
                {
                    for (int j = 0; j < slotNumber.GetLength(1); j++)
                    {

                        {
                            slotNumber[i, j] = rnd.Next(0, 4);
                            Console.Write("{0}\t", slotNumber[i, j]);
                        }
                    }
                    Console.Write("\n\n");
                }
           
                int totalLines = Logic.TotalLinesWon(slotNumber, lines);

                response = "";
                if (totalLines > 0)
                {
                    //Payout calculation and Play Again
                    int singleLineWinnings = UIMethods.SingleLineWinningsAmount(totalLines, bet);
                    credits = UIMethods.TotalWonAndCreditsAmount(credits, singleLineWinnings);        
                    UIMethods.YouWon(totalLines, singleLineWinnings, credits);
                    response = UIMethods.PlayAgain(response);
                }

                else
                {
                    //Loss deduction calculation and Play Again
                    credits = UIMethods.TotalLossAndCreditsAmount(credits, totalBet);
                    if (credits > 0)
                    {
                        UIMethods.YouLost(totalBet, credits);
                        response = UIMethods.PlayAgain(response);

                    }
                    else
                    {
                        UIMethods.YouLostNoMoneyLeft(totalBet, credits);
                        break;
                    }

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







