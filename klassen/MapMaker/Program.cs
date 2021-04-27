using System;
using System.Collections.Generic;

namespace MapMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            SalonElement salon1 = new SalonElement(new Point(6, 5), 40, 20);
            salon1.Paint();
            Console.ReadLine();
            //List<MapObject> allObjects = new List<MapObject>();
            //Menu menu = new Menu();
            //do
            //{
            //    menu.ShowMenu();
            //    menu.GetInput(allObjects);
            //    Console.Clear();
            //    //Teken alle objecten
            //    for (int i = 0; i < allObjects.Count; i++)
            //    {
            //        allObjects[i].Paint();
            //    }
            //} while (true);

            //ZetelElement zetel1 = new ZetelElement();
            //zetel1.Paint();
            //List<MapObject> allObjects = new List<MapObject>(); //lang leve polymorfisme

            //Muurtje
            //for (int i = 0; i < 10; i++)
            //{
            //    Point tempLoc = new Point(2 + i, 3);
            //    WallElement tempWall = new WallElement(tempLoc, '=', 10.0);
            //    allObjects.Add(tempWall);
            //}

            //Zetel
            //allObjects.Add(new ZetelElement(new Point(6, 8), 3));

            //Teken alle objecten
            //for (int i = 0; i < allObjects.Count; i++)
            //{
            //    allObjects[i].Paint();
            //}
        }
    }
}
