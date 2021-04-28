using System;
using System.Collections.Generic;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameboard level1 = new Gameboard();
            level1.DrawGame();
            do
            {
                foreach (var item in MapElement.allElements)
                {
                    if (item is Player)
                    {
                        Player player = (Player)item;
                        player.Move(Console.ReadKey());
                    }
                    Random rDirection = new Random();
                    if (item is Monster)
                    {
                        Monster monster = (Monster)item;
                        if (monster.PlayerLeft())
                        {
                            monster.ShootPlayer();
                        }
                        else
                        {
                            monster.Move(rDirection.Next(0,4));
                        }
                    }
                    if (item is RockDestroyer)
                    {
                        RockDestroyer destroyer = (RockDestroyer)item;
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
                Console.Clear();
                level1.DrawGame();
            } while (true);
        }
    }
}
