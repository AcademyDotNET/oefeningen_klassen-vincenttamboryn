using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHouse
{
    class House
    {
        public Room[]theseRooms;
        public House(Room[]roomsInHouse) 
        {
            theseRooms = new Room[roomsInHouse.Length];
            for (int i = 0; i < roomsInHouse.Length; i++)
            {
                theseRooms[i] = roomsInHouse[i];
            }
        }
        public void AddRoom(Room toBeAdded) 
        {
            Array.Resize<Room>(ref theseRooms, theseRooms.Length+1);
            theseRooms[theseRooms.Length - 1] = toBeAdded;
        }
        public double CalculatePrice()
        {
            double totalCost = 0;
            for (int i = 0; i < theseRooms.Length; i++)
            {
                totalCost += theseRooms[i].Price;
            }
            return totalCost;
        }
    }
}
