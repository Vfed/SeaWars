using System;
using System.Collections.Generic;
using System.Text;

namespace SeaWars
{
    class Player //: IPlayer
    {
        public string Name { get; set; }
        public int[,] MyField { get; set ; }
        public int[,] EnemyAttacksField { get; set; }
        public int[,] MyActionField { get ; set ; }
        public Ship[] Ships { get ; set ; }

        //Contructor of Player
        public Player(int n, string name, int[] shiplength)
        {
            Name = name;
            MyField = new int[n, n];
            MyActionField = new int[n, n];
            EnemyAttacksField = new int[n, n];
            Ships = new Ship[shiplength.Length];
            for (int i = 0; i < shiplength.Length; i++)
            {
                Ships[i] = new Ship(shiplength[i]);
            }
        }

        //Show Init Field
        public void ShowFieldInit()
        {
            ColorChange color = new ColorChange();
            
            string line = new string('-', 6);
            for (int i = 0; i < MyField.GetLength(1); i++)
            {
                line += "-----";
            }
            color.ChCol(ConsoleColor.Yellow);
            Console.Write("\n" + new string(' ', ((MyField.GetLength(1)+1)*5 / 2) - Name.Length / 2 > 0 ? ((MyField.GetLength(1) + 1) * 5 / 2) - Name.Length / 2 : 0 ) + Name + "\n");
            color.ChCol(ConsoleColor.White);
            
            Console.WriteLine("\n" + line);
            for (int j = MyField.GetLength(0)-1; j >= 0; j--)
            {
                Console.Write("| " + (j + 1 ) + new string(' ', 3 - (j+1).ToString().Length));
                for (int i = 0; i < MyField.GetLength(1); i++)
                {
                    Console.Write("|");
                    switch (MyField[j, i])
                    {
                        case 0:
                            color.ChBkCol(ConsoleColor.DarkBlue);
                            color.ChCol(ConsoleColor.White);
                            Console.Write(" ~~ ");
                            break;
                        default:
                            color.ChBkCol(ConsoleColor.Green);
                            color.ChCol(ConsoleColor.Magenta);
                            Console.Write($" {(MyField[j, i]) + new string(' ', 3 - MyField[j, i].ToString().Length)}");
                            break;
                    }
                    color.ChBkCol(ConsoleColor.Black);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("|\n");
                Console.WriteLine(line);
            }
            Console.Write("| y\\x");
            for (int i = 0; i < MyField.GetLength(1); i++)
            {
                Console.Write("| " + (i + 1) + new string(' ', 3 - (i + 1).ToString().Length));
            }
            Console.WriteLine("|\n"+line);
        }

        //Show the Field
        public void ShowField()
        {
            string space = new string(' ', 8);
            ColorChange color = new ColorChange();
            string line = new string('-', 6);
            for (int i = 0; i < MyActionField.GetLength(1); i++){ line += "------";}
            color.ChCol(ConsoleColor.Red);
            Console.Write("\n" + new string(' ', (line.Length / 2) - "Enemy Field".Length / 2 > 0 ? (line.Length / 2) - "Enemy Field".Length / 2 : 0) + "Enemy Field" + "");
            Console.Write(new string(' ',( line.Length / 2 - "Enemy Field".Length / 2 ))+space);
            color.ChCol(ConsoleColor.Yellow);
            Console.Write(new string(' ', (line.Length / 2) - Name.Length / 2 > 0 ? (line.Length / 2) - Name.Length / 2 : 0) + Name + "");
            color.ChCol(ConsoleColor.White);
            Console.WriteLine("\n" + line + space + line);

            for (int j = MyActionField.GetLength(0) - 1; j >= 0; j--)
            {
                Console.Write("| " + (j + 1) + new string(' ', 3 - (j + 1).ToString().Length));
                for (int i = 0; i < MyActionField.GetLength(1); i++)
                {
                    Console.Write("|");
                    switch (MyActionField[j, i])
                    {
                        case 0:
                            color.ChBkCol(ConsoleColor.Blue);
                            color.ChCol(ConsoleColor.White);
                            Console.Write(" ~ ~ ");
                            break;
                        case 1:
                            color.ChBkCol(ConsoleColor.White);
                            color.ChCol(ConsoleColor.DarkBlue);
                            Console.Write("-\\|/-");
                            break;
                        case 2:
                            color.ChBkCol(ConsoleColor.Yellow);
                            color.ChCol(ConsoleColor.Red);
                            Console.Write("-\\|/-");
                            break;
                        case 3:
                            color.ChBkCol(ConsoleColor.Red);
                            color.ChCol(ConsoleColor.Black);
                            Console.Write("-\\|/-");
                            break;
                        default:
                            color.ChBkCol(ConsoleColor.Green);
                            color.ChCol(ConsoleColor.Magenta);
                            Console.Write(" ~ ~ ");
                            break;
                    }
                    color.ChBkCol(ConsoleColor.Black);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("|" + space +"| " + (j + 1) + new string(' ', 3 - (j + 1).ToString().Length));
                for (int i = 0; i < MyField.GetLength(1); i++)
                {
                    Console.Write("|");
                    switch (MyField[j, i])
                    {
                        case 0:
                            if (EnemyAttacksField[j, i] == 0)
                            {
                                color.ChBkCol(ConsoleColor.DarkBlue);
                                color.ChCol(ConsoleColor.White);
                                Console.Write(" ~ ~ ");
                            }
                            else
                            {
                                color.ChBkCol(ConsoleColor.White);
                                color.ChCol(ConsoleColor.DarkBlue);
                                Console.Write("-\\|/-");
                            }
                            break;
                        default:
                            if (EnemyAttacksField[j, i] == 0)
                            {
                                color.ChBkCol(ConsoleColor.Green);
                                color.ChCol(ConsoleColor.Yellow);
                                Console.Write($" {(MyField[j, i]) + new string(' ', 4 - MyField[j, i].ToString().Length)}");
                            }
                            else
                            {
                                if (Ships[MyField[j, i] - 1].IsAlive)
                                {
                                    color.ChBkCol(ConsoleColor.Green);
                                    color.ChCol(ConsoleColor.Yellow);
                                    Console.Write("-\\|/-");
                                }
                                else
                                {
                                    color.ChBkCol(ConsoleColor.Red);
                                    color.ChCol(ConsoleColor.DarkRed);
                                    Console.Write("-\\|/-");
                                }
                            }
                            break;
                    }
                    color.ChBkCol(ConsoleColor.Black);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("|\n" + line + space + line);

            }
            Console.Write("| y\\x");
            for (int i = 0; i < MyField.GetLength(1); i++)
            {
                Console.Write("| " + (i + 1) + new string(' ', 4 - (i + 1).ToString().Length));
            }
            Console.Write("|" + space + "| y\\x");
            for (int i = 0; i < MyField.GetLength(1); i++)
            {
                Console.Write("| " + (i + 1) + new string(' ', 4 - (i + 1).ToString().Length));
            }
            Console.WriteLine("|\n" + line + space + line);
        }

        public void PlaceShips()
        {
            for (int k = 0; k < this.Ships.Length; k++)
            {
                ColorChange color = new ColorChange();
                bool directionChk = true;
                int direction = 0;
                bool canBePlaced = true;
                int xCoord = 0, 
                    yCoord = 0;
                bool xCoordChk = true, 
                    yCoordChk = true;

                if (this.Ships[k].ShipLength > 1)
                    do
                    {
                        Console.Clear();
                        this.ShowFieldInit();
                        if (!directionChk)
                        {
                            color.ChCol(ConsoleColor.Red);
                            Console.WriteLine("\nWrong Enter !!!");
                            color.ChCol(ConsoleColor.White);
                        }
                        this.Ships[k].ShoveShip(2);
                        Console.Write("\nChose ship direction (1-vertical \\ 2-horizontal): ");
                        directionChk = Int32.TryParse(Console.ReadLine(), out direction);
                        directionChk = directionChk && (direction < 1 || direction > 2) ? false : true;
                    } while (!directionChk);
                else { direction = 1; }

                do
                {
                    Console.Clear();
                    this.ShowFieldInit();
                    if (!canBePlaced)
                    {
                        color.ChCol(ConsoleColor.Red);
                        Console.WriteLine("\n\t Wrong Enter or Can`t be Placed there !!!");
                        color.ChCol(ConsoleColor.White);
                    }
                    Console.WriteLine("\nPlace a Ship (lenght - " + Ships[k].ShipLength + "):\n");
                    Ships[k].ShoveShip(direction);
                    Console.Write("\nEnter Ships head(bottom left point) X coordinate:");
                    xCoordChk = Int32.TryParse(Console.ReadLine(), out xCoord);
                    Console.Write("\nEnter Ships head(bottom left point) Y coordinate:");
                    yCoordChk = Int32.TryParse(Console.ReadLine(), out yCoord);
                    xCoord--;
                    yCoord--;
                    canBePlaced = xCoordChk && 
                        yCoordChk && 
                        xCoord >= 0 && xCoord < this.MyField.GetLength(1) && 
                        yCoord >= 0 && yCoord < this.MyField.GetLength(0) 
                        ? true 
                        : false;

                    if (canBePlaced)
                    {
                        switch (direction)
                        {
                            case 1:
                                if (yCoord + (this.Ships[k].ShipLength - 1) >= this.MyField.GetLength(0))
                                {
                                    canBePlaced = false;
                                }
                                else
                                {
                                    for (int j = 0; j < this.Ships[k].ShipLength; j++)
                                    {
                                        if (this.MyField[yCoord + j, xCoord] != 0)
                                        {
                                            canBePlaced = false;
                                        }
                                    }
                                }
                                break;
                            case 2:
                                if (xCoord + this.Ships[k].ShipLength - 1 >= this.MyField.GetLength(1))
                                {
                                    canBePlaced = false;
                                }
                                else
                                {
                                    for (int j = 0; j < this.Ships[k].ShipLength; j++)
                                    {
                                        if (this.MyField[yCoord, xCoord + j] != 0)
                                        {
                                            canBePlaced = false;
                                        }
                                    }
                                }
                                break;
                            default:
                                canBePlaced = false;
                                break;
                        }
                    }
                } while (!canBePlaced);

                for (int i = 0; i < this.Ships[k].ShipLength; i++)
                {
                    switch (direction)
                    {
                        case 1:
                            for (int j = 0; j < this.Ships[k].ShipLength; j++)
                            {
                                this.MyField[yCoord + j, xCoord] = k+1;
                            }
                            break;
                        case 2:
                            for (int j = 0; j < this.Ships[k].ShipLength; j++)
                            {
                                this.MyField[yCoord, xCoord + j] = k+1;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //Any Ships Left 
        public bool IsAlive()
        {
            for (int i = 0; i < this.Ships.Length; i++)
            {
                if (Ships[i].IsAlive)
                {
                    return true;
                }
            }
            return false;
        }
        public int CheckAction(int x, int y)
        {
            EnemyAttacksField[y, x] = 1;
            if (MyField[y, x] > 0)
            {
                if (Ships[MyField[y, x] - 1].IsAlive) 
                {
                    Ships[MyField[y, x] - 1].PartsAlive--;
                    return Ships[MyField[y, x] - 1].IsAlive ? 2: 3 ;
                }
            }
            return 1;
        }
        public int[,] CheckField()
        {
            int[,] result = new int[MyField.GetLength(0), MyField.GetLength(1)];
            for (int i = 0; i < EnemyAttacksField.GetLength(0); i++)
            {
                for (int j = 0; j < EnemyAttacksField.GetLength(1); j++)
                {
                    if (EnemyAttacksField[i, j] == 1)
                    {
                        if (MyField[i, j] == 0)
                        {
                            result[i, j] = 1;
                        }
                        else
                        {
                            result[i, j] = Ships[MyField[i, j] - 1].IsAlive ? 2 : 3;
                        }

                    }
                }
            }
            return result;
        }
    }
}
