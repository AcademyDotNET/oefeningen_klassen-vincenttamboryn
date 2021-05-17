using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Gameboard
    {
        public static int BoardSize { get; set; } = 20;
        public Gameboard()
        {
            MapElementFactory.Build("Player", Array.Empty<object>());
            PlaceXRocks(15);
            PlaceXMonsters(10);
            PlaceXRockDestroyers(5);
            PlaceWallsInit(20);
        }
        public Gameboard(int rocks, int monsters, int rockDestroyers, int boardSize = 20)
        {
            BoardSize = boardSize;
            MapElementFactory.Build("Player", Array.Empty<object>());
            PlaceXRocks(rocks, BoardSize);
            PlaceXMonsters(monsters, BoardSize);
            PlaceXRockDestroyers(rockDestroyers, BoardSize);
            PlaceWallsInit(BoardSize);
        }
        static void PlaceXRocks(int thisManyRocks, int boardSize = 20)
        {
            for (int i = 0; i < thisManyRocks; i++)
            {
                Random randPlacement = new();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);

                if (CheckForMapElements(randX, randY))
                {
                    Object[] location = { randX, randY };
                    Object[] point = { CoordinateFactory.Build("Point", location) };
                    MapElementFactory.Build("Rock", point);
                }
            }
        }
        static void PlaceXMonsters(int thisManyMonsters, int boardSize = 20)
        {
            for (int i = 0; i < thisManyMonsters; i++)
            {
                Random randPlacement = new();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);

                if (CheckForMapElements(randX, randY))
                {
                    Object[] location = { randX, randY };
                    Object[] point = { CoordinateFactory.Build("Point", location) };
                    MapElementFactory.Build("Monster", point);
                }
            }
        }
        static void PlaceXRockDestroyers(int thisManyRockDestroyers, int boardSize = 20)
        {
            for (int i = 0; i < thisManyRockDestroyers; i++)
            {
                Random randPlacement = new();
                int randX = randPlacement.Next(1, boardSize);
                int randY = randPlacement.Next(1, boardSize);

                if (CheckForMapElements(randX, randY))
                {
                    Object[] location = { randX, randY };
                    Object[] point = { CoordinateFactory.Build("Point", location) };
                    MapElementFactory.Build("RockDestroyer", point);
                }
            }
        }
        static bool CheckForMapElements(int randX, int randY)
        {
            bool freeSpace = true;
            foreach (var item in MapElement.allElements)
            {
                if (item.Location.X == randX && item.Location.Y == randY)
                {
                    freeSpace = false;
                }
            }
            return freeSpace;
        }
        static void PlaceWallsInit(int boardSize)
        {
            for (int i = 0; i < boardSize + 1; i++)
            {
                if (i != 10)
                {
                    Object[] point1 = { 0, i };
                    Object[] point2 = { i, 0 };
                    Object[] point3 = { boardSize, i };
                    Object[] point4 = { i, boardSize };
                    Object[] leftWall =  { CoordinateFactory.Build("Point", point1) };
                    Object[] upperWall = { CoordinateFactory.Build("Point", point2) };
                    Object[] rightWall = { CoordinateFactory.Build("Point", point3) };
                    Object[] lowerWall = { CoordinateFactory.Build("Point", point4) };
                    MapElementFactory.Build("Rock", leftWall);
                    MapElementFactory.Build("Rock", upperWall);
                    MapElementFactory.Build("Rock", rightWall);
                    MapElementFactory.Build("Rock", lowerWall);
                    // or in 1 line: MapElementFactory.Build("Rock", new Object[] { CoordinateFactory.Build("Point", new Object[] { 0, i }) });
                }
                else
                {
                    Object[] upperMiddlePoint = { i, 0 };
                    Object[] lowerMiddlePoint = { i, boardSize };
                    Object[] upperMiddle = { CoordinateFactory.Build("Point", upperMiddlePoint) };
                    Object[] lowerMiddle = { CoordinateFactory.Build("Point", lowerMiddlePoint) };
                    MapElementFactory.Build("Rock", upperMiddle);
                    MapElementFactory.Build("Rock", lowerMiddle);
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
    }
}
