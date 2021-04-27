﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class SalonElement : MapObject
    {
        private List<MapObject> elementen = new List<MapObject>();

        public SalonElement(Point salonLoc, int breedte, int hoogte)
        {
            DrawWalls(breedte, hoogte);
            elementen.Add(new ZetelElement(new Point(Location.X + 2, Location.Y + 2), 3, '+'));
            elementen.Add(new ZetelElement(new Point(Location.X + 5, Location.Y + 9), 3, '+'));
            elementen.Add(new TafelElement(new Point(Location.X + 10, Location.Y + 15), 3, 8));
            Location = salonLoc;
        }
        private void DrawWalls( int breedte, int hoogte)
        {
            for (int i = 0; i < breedte; i++)
            {
                elementen.Add(new WallElement(new Point(Location.X + i, Location.Y),'#'));
                elementen.Add(new WallElement(new Point(Location.X + i, Location.Y + hoogte), '#'));
            }
            for (int i = 0; i < hoogte; i++)
            {
                elementen.Add(new WallElement(new Point(Location.X, Location.Y + i), '#'));
                elementen.Add(new WallElement(new Point(Location.X + breedte, Location.Y + i), '#'));
            }
        }

        public override void Paint()
        {
            for (int i = 0; i < elementen.Count; i++)
            {
                elementen[i].Paint();
            }

        }
    }
}
