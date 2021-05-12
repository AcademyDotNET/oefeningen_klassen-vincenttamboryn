using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameManager
    {
        public Gameboard level;
        public int playerScore;
        public GameManager(int rocks, int monsters,int rockDestroyers, int boardSize = 20)
        {
            level = new Gameboard(rocks, monsters, rockDestroyers, boardSize);
        }
        public void Start()
        {
            level.DrawGame();
            do
            {
                for (int i = 0; i < MapElement.allElements.Count; i++)
                {
                    PlayerMovement(i);

                    RockDestroyerMovement(i);

                    MonsterMovement(i);
                }

                Console.Clear();
                level.DrawGame();

            } while (!IsGameLost() && !IsGameWon());//reapeat game

            //how did the game end
            Console.Clear();
            Ending();
        }
        void Ending()
        {
            if (IsGameLost())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lost!");
                Console.WriteLine($"Your final score was {playerScore}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won!");
                Console.WriteLine($"Your final score was {playerScore}");
            }
        }
        void PlayerMovement(int i)
        {
            if (MapElement.allElements[i] is Player)
            {
                Player player = MapElement.allElements[i] as Player;
                player.Move(Console.ReadKey());
                playerScore = player.Score;
            }
        }
        void RockDestroyerMovement(int i)
        {//rockdestroyer movement, kills rocks or players if they are left of the rockdestroyer
            if (MapElement.allElements[i] is RockDestroyer)
            {
                Random rDirection = new Random();
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
        }
        void MonsterMovement(int i)
        {//monster momevent, kill the player if the player is left of the monster
            if (MapElement.allElements[i] is Monster && !(MapElement.allElements[i] is RockDestroyer))
            {
                Random rDirection = new Random();
                Monster monster = MapElement.allElements[i] as Monster;
                if (monster.PlayerLeft())
                {
                    monster.ShootPlayer();
                }
                else
                {
                    monster.Move(rDirection.Next(0, 4));
                }
            }
        }
        static bool IsGameLost()
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
        static bool IsGameWon()
        {
            bool condition = false;
            foreach (var item in MapElement.allElements)
            {
                if (item is Player && item.Location.X >= Gameboard.BoardSize)
                {
                    condition = true;
                }
            }
            return condition;
        }
    }
}
