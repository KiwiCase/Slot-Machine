using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class Logic
    {

        public static int[,] NumberGridArray()
        {
            Random rnd = new Random();
            int[,] slotNumber = new int[3, 3];
            return slotNumber;
        }
    }
}
