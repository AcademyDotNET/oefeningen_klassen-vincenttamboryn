using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        /*
         * to do
         * better draw function (no more console. clear)
         * new enemy, following enemy?
         * menu?
         */
        static void Main(string[] args)
        {
            Random rDirection = new Random();
            Gameboard level1 = new Gameboard(35,20,10,25);
            level1.DrawGame();
            int score = 0;

            do
            {
                for (int i = 0; i < MapElement.allElements.Count; i++)
                {
                    //player movement
                    if (MapElement.allElements[i] is Player)
                    {
                        Player player = MapElement.allElements[i] as Player;
                        player.Move(Console.ReadKey());
                        score = player.Score;
                        //clear console, draw updated level
                        //ClearGameBoard(MapElement.allElements);
                        Console.Clear();
                        level1.DrawGame();
                    }

                    //rockdestroyer movement, kills rocks or players if they are left of the rockdestroyer
                    else if (MapElement.allElements[i] is RockDestroyer)
                    {
                        RockDestroyer destroyer = MapElement.allElements[i] as RockDestroyer;
                        if (destroyer.ItemLeft())
                        {
                            destroyer.Shoot();
                        }
                        else
                        {
                            destroyer.Move(rDirection.Next(0, 4));
                        }
                    }

                    //monster momevent, kill player if player is left of the monster
                    else if (MapElement.allElements[i] is Monster && !(MapElement.allElements[i] is RockDestroyer))
                    {
                        Monster monster = MapElement.allElements[i] as Monster;
                        if (monster.PlayerLeft())
                        {
                            monster.ShootPlayer();
                        }
                        else
                        {
                            monster.Move(rDirection.Next(0,4));
                        }
                    }
                }

                //clear console, draw updated level
                //ClearGameBoard(MapElement.allElements);
                Console.Clear();
                level1.DrawGame();

            } while (!IsGameLost() && !IsGameWon());//reapeat game

            //how did the game end
            Console.Clear();
            if (IsGameLost())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lost!");
                Console.WriteLine($"Your final score was {score}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won!");
                Console.WriteLine($"Your final score was {score}");
            }
        }

        public static bool IsGameLost()
        {
            bool condition = true;
            foreach (var item in MapElement.allElements)
            {
                if (item is Player)
                {
                    condition = false;
                }
            }
            return condition;
        }
        public static bool IsGameWon()
        {
            bool condition = false;
            foreach (var item in MapElement.allElements)
            {
                if (item is Player && item.Location.X >=Gameboard.BoardSize)
                {
                    condition = true;
                }
            }
            return condition;
        }
        public static void ClearGameBoard(List<MapElement> elements)
        {//doesn't work
            foreach (var item in elements)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(item.Location.X * 2, item.Location.Y);
                Console.WriteLine("_");
            }
        }
    }
}
