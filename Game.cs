using System;
using System.Collections.Generic;
using System.Text;

namespace SeaWars
{
    class Game
    {
        private int mapSize = 0;
        private int[] Ships;
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }
        private int MoveCount { get; set; }
        public Game(int n, int[] ships) 
        {
            mapSize = n;
            Ships = ships;
            MoveCount = 1;
        }
        public void PlayersInit() 
        {
            ColorChange color = new ColorChange();
            string name = "";
            bool nameChk = true;
            do
            {
                Console.Clear();
                if (!nameChk) 
                {
                    color.ChCol(ConsoleColor.Red);
                    Console.WriteLine("Wrong enter , Lenght lover then 3 or biger then 20");
                    color.ChCol(ConsoleColor.White);
                }
                Console.Write("First Player Enters his Name : ");
                name = Console.ReadLine().Trim().Replace("  ", " ").Replace("  ", " ");
                nameChk = !(name.Length < 3 || name.Length > 20); 
            } while (!nameChk);
            Player1 = new Player(mapSize, name, Ships);
            do
            {
                Console.Clear();
                if (!nameChk)
                {
                    color.ChCol(ConsoleColor.Red);
                    Console.WriteLine("Wrong enter , Lenght lover then 3 or biger then 20");
                    color.ChCol(ConsoleColor.White);
                }
                Console.Write("Second Player Enters his Name : ");
                name = Console.ReadLine().Trim().Replace("  "," ").Replace("  ", " ");
                nameChk = !(name.Length < 3 || name.Length > 20);
            } while (!nameChk);
            Player2 = new Player(mapSize, name, Ships);
            Random n = new Random();
            int chkNum = n.Next(10); 
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine($"Player ({Player1.Name}) Starts to place the ships, press {chkNum} to start");
                key = Console.ReadKey();
            } while (key.KeyChar.ToString() != chkNum.ToString());
            Player1.PlaceShips();
            chkNum = n.Next(10);
            do
            {
                Console.Clear();
                Console.WriteLine($"Player : ({Player2.Name}) Starts to place the ships, press {chkNum} to start");
                key = Console.ReadKey();

            } while (key.KeyChar.ToString() != chkNum.ToString());
            Player2.PlaceShips();
        }

        public void GameStarts() 
        {
            ColorChange color = new ColorChange();
            Random r = new Random();
            ConsoleKeyInfo key;
            int chkNum;
            bool chkPlayersChange = true;
            bool winChk = false;
            bool chkMove = true;
            int changeChkNum;
            Player attackingPlayer = Player2;
            Player defendingPlayer = Player1;
            Console.Clear();
            color.ChCol(ConsoleColor.Green);
            Console.WriteLine("\n"+new string(' ',20)+"THE GAME STARTS !!!\n");
            color.ChCol(ConsoleColor.White);
            Console.ReadLine();
            do
            {
                Console.Clear();
                if (chkPlayersChange)
                {

                    Player midPlayer = attackingPlayer;
                    attackingPlayer = defendingPlayer;
                    defendingPlayer = midPlayer;
                    changeChkNum = r.Next(10);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Player : ({attackingPlayer.Name}) Make a Move, press {changeChkNum} to start");
                        key = Console.ReadKey();
                    } while (key.KeyChar.ToString() != changeChkNum.ToString());
                    chkPlayersChange = false;
                }
                do
                {
                    Console.Clear();
                    attackingPlayer.ShowField();
                    if (!chkMove)
                    {
                        color.ChCol(ConsoleColor.Red);
                        Console.WriteLine("Wrong Enter or Point is already fired!!!");
                        color.ChCol(ConsoleColor.White);
                    }
                    Console.Write("\nEnter X coordinate to fire:");
                    bool xCoordChk = Int32.TryParse(Console.ReadLine(), out int xCoord);
                    Console.Write("\nEnter Y coordinate to fire:");
                    bool yCoordChk = Int32.TryParse(Console.ReadLine(), out int yCoord);
                    xCoord--;
                    yCoord--;
                    if (xCoordChk && yCoordChk && xCoord >= 0 && xCoord < mapSize && yCoord >= 0 && yCoord < mapSize && attackingPlayer.MyActionField[yCoord, xCoord] == 0)
                    {
                        attackingPlayer.MyActionField[yCoord, xCoord] = defendingPlayer.CheckAction(xCoord, yCoord);
                        attackingPlayer.MyActionField = defendingPlayer.CheckField();
                        Console.Clear();
                        attackingPlayer.ShowField();
                        switch (attackingPlayer.MyActionField[yCoord, xCoord])
                        {
                            case 1:
                                Console.WriteLine("You have Missed , Time for oponent to strike !!!");
                                chkPlayersChange = true;
                                break;
                            case 2:
                                color.ChCol(ConsoleColor.Yellow);
                                Console.WriteLine("You have Injered a Ship , Strike One More time !!!");
                                color.ChCol(ConsoleColor.White);
                                break;
                            case 3:
                                color.ChCol(ConsoleColor.Red);
                                Console.WriteLine("You destroyed a Ship Strike One More time !!!");
                                color.ChCol(ConsoleColor.White); 
                                break;
                            default:
                                break;
                        }
                        chkMove = true;
                        Console.ReadKey();
                    }
                    else { chkMove = false; };

                } while (!chkMove);
                if (!defendingPlayer.IsAlive()) 
                {
                    winChk = true;
                }
            }
            while (!winChk);

            do
            {
                Console.Clear();
                color.ChCol(ConsoleColor.Yellow);
                Console.WriteLine($"\n{new string(' ', 20)} Player {attackingPlayer.Name} WINS !!!!");
                color.ChCol(ConsoleColor.Red);
                Console.WriteLine($"\n{new string(' ', 20)} Congratulations !!!!".ToUpper());
                color.ChCol(ConsoleColor.Green);
                Console.WriteLine($"\n{new string(' ', 20)} Press Enter to Exit");
                key = Console.ReadKey();
            } while (key.Key.ToString() != "Enter");
        }
    }
}
