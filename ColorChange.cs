using System;
using System.Collections.Generic;
using System.Text;

namespace SeaWars
{
    class ColorChange
    {
        public void ChCol(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public void ChBkCol(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }
}
