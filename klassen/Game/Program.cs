using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rDirection = new Random();
            Gameboard level1 = new Gameboard(5,5,5);
            level1.DrawGame();
            do
            {
                for (int i = 0; i < MapElement.allElements.Count; i++)
                {
                    //player movement
                    if (MapElement.allElements[i] is Player)
                    {
                        Player player = (Player)MapElement.allElements[i];
                        player.Move(Console.ReadKey());
                    }

                    //monster momevent, kill player if player is left of the monster
                    if (MapElement.allElements[i] is Monster && !(MapElement.allElements[i] is RockDestroyer))
                    {
                        Monster monster = (Monster)MapElement.allElements[i];
                        if (monster.PlayerLeft())
                        {
                            monster.ShootPlayer();
                        }
                        else
                        {
                            monster.Move(rDirection.Next(0,4));
                        }
                    }

                    //rockdestroyer movement, kills rocks or players if they are left of the rockdestroyer
                    if (MapElement.allElements[i] is RockDestroyer)
                    {
                        RockDestroyer destroyer = (RockDestroyer)MapElement.allElements[i];
                        if (destroyer.ItemLeft())
                        {
                            destroyer.Shoot();
                        }
                        else
                        {
                            destroyer.Move(rDirection.Next(0, 4));
                        }
                    }
                }

                //clear console, draw updated level
                Console.Clear();
                level1.DrawGame();

            } while (!IsGameLost() || !IsGameWon());//reapeat game
            Console.Clear();
            if (IsGameLost())
            {
                Console.WriteLine("You Lost!");
            }
            else
            {
                Console.WriteLine("You Won!");
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
                if (item is Player && item.Location.X >=20)
                {
                    condition = true;
                }
            }
            return condition;
        }
    }
}
