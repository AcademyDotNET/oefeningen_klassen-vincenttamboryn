using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Gameboard
    {
        public MapElement[,] board;
        public static int BoardSize { get; set; } = 20;
        public Gameboard()
        {
            new Player();
            PlaceXRocks(15);
            PlaceXMonsters(10);
            PlaceXRockDestroyers(5);
            PlaceWallsInit(20);
            Update();
        }
        public Gameboard(int rocks, int monsters, int rockDestroyers, int boardSize = 20)
        {
            BoardSize = boardSize;
            new Player();
            PlaceXRocks(rocks, BoardSize);
            PlaceXMonsters(monsters, BoardSize);
            PlaceXRockDestroyers(rockDestroyers, BoardSize);
            PlaceWallsInit(BoardSize);
            Update();
        }
        static void PlaceXRocks(int thisManyRocks, int boardSize = 20)
        {
            for (int i = 0; i < thisManyRocks; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);
                bool freeSpace = true;
                foreach (var item in MapElement.allElements)
                {
                    if (item.Location.X == randX && item.Location.Y == randY)
                    {
                        freeSpace = false;
                    }
                }
                if (freeSpace)
                {
                    new Rock(new Point(randX, randY));
                }
            }
        }
        static void PlaceXMonsters(int thisManyMonsters, int boardSize = 20)
        {
            for (int i = 0; i < thisManyMonsters; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);
                bool freeSpace = true;
                foreach (var item in MapElement.allElements)
                {
                    if (item.Location.X == randX && item.Location.Y == randY)
                    {
                        freeSpace = false;
                    }
                }
                if (freeSpace)
                {
                    new Monster(new Point(randX, randY));
                }
            }
        }
        static void PlaceXRockDestroyers(int thisManyRockDestroyers, int boardSize = 20)
        {
            for (int i = 0; i < thisManyRockDestroyers; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);
                bool freeSpace = true;
                foreach (var item in MapElement.allElements)
                {
                    if (item.Location.X == randX && item.Location.Y == randY)
                    {
                        freeSpace = false;
                    }
                }
                if (freeSpace)
                {
                   new RockDestroyer(new Point(randX, randY));
                }
            }
        }
        static void PlaceWallsInit(int boardSize)
        {
            for (int i = 0; i < boardSize + 1; i++)
            {
                if (i != 10)
                {
                    new Rock(new Point(0, i));
                    new Rock(new Point(i, 0));
                    new Rock(new Point(boardSize, i));
                    new Rock(new Point(i, boardSize));
                }
                else
                {
                    new Rock(new Point(i, 0));
                    new Rock(new Point(i, boardSize));
                }
            }
        }
        public void DrawGame()
        {
            foreach (var item in MapElement.allElements)
            {
                item.Draw();
            }
        }
        public void Update()
        {
            //isn't used

            //board = new MapElement[BoardSize, BoardSize];
            //foreach (var item in MapElement.allElements)
            //{
            //    board[item.Location.Y, item.Location.X] = item;
            //}
        }
    }
}
