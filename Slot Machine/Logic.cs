using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class Logic
    {
        public static int BetDeduction(int credits, int totalBet)
        {
            credits -= totalBet;
            return credits;
        }

        public static int[,] GenerateArray()
        {
            Random rnd = new Random();
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
            } return slotNumber;
        }
        public static int TotalLinesWon(int[,] slotNumber, int lines)
        {
            int totalLines = 0;
            if (lines > 0)
            {
                if (slotNumber[1, 0] == slotNumber[1, 1] && slotNumber[1, 0] == slotNumber[1, 2])
                {
                    totalLines++;
                }
            }

            if (lines > 1)
            {
                if (slotNumber[0, 0] == slotNumber[0, 1] && slotNumber[0, 0] == slotNumber[0, 2])
                {
                    totalLines++;
                }
            }

            if (lines > 2)
            {
                if (slotNumber[2, 0] == slotNumber[2, 1] && slotNumber[2, 0] == slotNumber[2, 2])
                {
                    totalLines++;
                }
            }

            if (lines > 3)
            {
                if (slotNumber[0, 0] == slotNumber[1, 1] && slotNumber[0, 0] == slotNumber[2, 2])
                {
                    totalLines++;
                }
            }

            if (lines > 4)
            {
                if (slotNumber[2, 0] == slotNumber[1, 1] && slotNumber[2, 0] == slotNumber[0, 2])
                {
                    totalLines++;
                }
            }

            if (lines > 5)
            {
                if (slotNumber[0, 0] == slotNumber[1, 0] && slotNumber[0, 0] == slotNumber[2, 0])
                {
                    totalLines++;
                }
            }

            if (lines > 6)
            {
                if (slotNumber[0, 1] == slotNumber[1, 1] && slotNumber[0, 1] == slotNumber[2, 1])
                {
                    totalLines++;
                }
            }

            if (lines > 7)
            {
                if (slotNumber[0, 2] == slotNumber[1, 2] && slotNumber[0, 2] == slotNumber[2, 2])
                {
                    totalLines++;
                }
            }
            return totalLines;
        }
    }
}
