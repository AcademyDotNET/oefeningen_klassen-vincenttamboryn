using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Gameboard
    {
        public MapElement[,] board = new MapElement[21,21];
        public Gameboard()
        {
            MapElement.allElements.Add(new Player());
            PlaceXRocks(15);
            PlaceXMonsters(10);
            PlaceXRockDestroyers(5);
            Update();
        }
        public Gameboard(int rocks, int monsters, int rockDestroyers)
        {
            MapElement.allElements.Add(new Player());
            PlaceXRocks(rocks);
            PlaceXMonsters(monsters);
            PlaceXRockDestroyers(rockDestroyers);
            Update();
        }
        static void PlaceXRocks(int thisManyRocks)
        {
            for (int i = 0; i < thisManyRocks; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, 20);
                int randY = randPlacement.Next(0, 20);
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
                    MapElement.allElements.Add(new Rock(new Point(randX, randY)));
                }
            }
        }
        static void PlaceXMonsters(int thisManyMonsters)
        {
            for (int i = 0; i < thisManyMonsters; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, 20);
                int randY = randPlacement.Next(0, 20);
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
                    MapElement.allElements.Add(new Monster(new Point(randX, randY)));
                }
            }
        }
        static void PlaceXRockDestroyers(int thisManyRockDestroyers)
        {
            for (int i = 0; i < thisManyRockDestroyers; i++)
            {
                Random randPlacement = new Random();
                int randX = randPlacement.Next(1, 20);
                int randY = randPlacement.Next(0, 20);
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
                    MapElement.allElements.Add(new RockDestroyer(new Point(randX, randY)));
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
            board = new MapElement[21, 21];
            foreach (var item in MapElement.allElements)
            {
                board[item.Location.Y, item.Location.X] = item;
            }
        }
    }
}
