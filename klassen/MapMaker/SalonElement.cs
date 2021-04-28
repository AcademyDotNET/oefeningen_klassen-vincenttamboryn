using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class SalonElement : MapObject
    {
        private List<MapObject> elementen = new List<MapObject>();
        public int breedte { get; set; }
        public int hoogte { get; set; }

        public SalonElement(Point salonLoc, int width, int hight)
        {
            breedte = width;
            hoogte = hight;
            elementen.Add(new ZetelElement(new Point(salonLoc.X + 2, salonLoc.Y + 2), 3, '+'));
            elementen.Add(new ZetelElement(new Point(salonLoc.X + 5, salonLoc.Y + 9), 3, '+'));
            elementen.Add(new TafelElement(new Point(salonLoc.X + 10, salonLoc.Y + 15), 3, 8));
            Location = salonLoc;
        }
        private void DrawWalls()
        {
            for (int i = 0; i < elementen.Count; i++)
            {
                if (elementen[i] is WallElement)
                {
                    elementen.Remove(elementen[i]);
                    i--;
                }
            }
            for (int i = 0; i < breedte; i++)
            {
                elementen.Add(new WallElement(new Point(Location.X + i, Location.Y),'#'));
                elementen.Add(new WallElement(new Point(Location.X + i, Location.Y + hoogte), '#'));
            }
            for (int i = 0; i <= hoogte; i++)
            {
                elementen.Add(new WallElement(new Point(Location.X, Location.Y + i), '#'));
                elementen.Add(new WallElement(new Point(Location.X + breedte, Location.Y + i), '#'));
            }
        }
        public void Update()
        {
            // just a 'copy' of constructor
            elementen.Clear();
            elementen.Add(new ZetelElement(new Point(Location.X + 2, Location.Y + 2), 3, '+'));
            elementen.Add(new ZetelElement(new Point(Location.X + 5, Location.Y + 9), 3, '+'));
            elementen.Add(new TafelElement(new Point(Location.X + 10, Location.Y + 15), 3, 8));

        }

        public override void Paint()
        {
            //still need to update other objects in elements
            Update();
            DrawWalls();
            for (int i = 0; i < elementen.Count; i++)
            {
                elementen[i].Paint();
            }

        }
    }
}
