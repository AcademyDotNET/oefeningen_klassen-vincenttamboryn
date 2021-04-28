using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class SalonElement : MapObject, IComposite
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
            elementen.Add(new TafelElement(new Point(salonLoc.X + 15, salonLoc.Y + 2), 3, 8));
            Location = salonLoc;
        }
        private void DrawWalls()
        {
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
        public void UpdateElements(Point offset)
        {
            for (int i = 0; i < elementen.Count; i++)
            {
                Point elementLoc = elementen[i].Location;
                elementLoc.X += offset.X;
                elementLoc.Y += offset.Y;
                elementen[i].Location = elementLoc;
            }
        }
        public override void Paint()
        {
            DrawWalls();
            for (int i = 0; i < elementen.Count; i++)
            {
                elementen[i].Paint();
            }

        }
    }
}
