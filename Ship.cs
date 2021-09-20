using System;
using System.Collections.Generic;
using System.Text;

namespace SeaWars
{
    class Ship //: IShip
    {
        public bool IsAlive { get { return PartsAlive != 0;}}
        public int PartsAlive { get; set; }
        public int ShipLength { get; set; }
        public Ship(int n)
        {
            this.ShipLength = n;
            this.PartsAlive = n;
        }
        public void ShoveShip(int direct)
        {
            ColorChange color = new ColorChange();
            switch (direct)
            {
                case 1:     //Vertical
                    Console.WriteLine("\t  ___  ");
                    Console.WriteLine("\t /---\\ ");
                    for (int j = 0; j < this.ShipLength; j++)
                    {
                        Console.Write("\t|");
                        color.ChBkCol(ConsoleColor.Green);
                        color.ChCol(ConsoleColor.Green);
                        Console.Write("     ");
                        color.ChBkCol(ConsoleColor.Black);
                        color.ChCol(ConsoleColor.White);
                        Console.WriteLine("|");
                        if (j != this.ShipLength - 1)
                        {
                            Console.WriteLine("\t|-----|");
                        }
                    }
                    Console.WriteLine("\t \\___/ ");

                    break;
                case 2:     //Horizontal
                    Console.Write("\t /" + new string('-', 5 * this.ShipLength -3) + "\\\n\t");
                    Console.Write("|");
                    for (int j = 0; j < this.ShipLength; j++)
                    {
                        color.ChBkCol(ConsoleColor.Green);
                        color.ChCol(ConsoleColor.Green);
                        Console.Write("    ");
                        color.ChBkCol(ConsoleColor.Black);
                        color.ChCol(ConsoleColor.White);
                        Console.Write("|");
                    }
                    Console.Write("\n\t \\" + new string('-', 5 * this.ShipLength -3) + "/\n");
                    break;
                default:
                    break;
            }
        }
    }
}
