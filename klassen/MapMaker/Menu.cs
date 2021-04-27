using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
    class Menu
    {
        public Menu()
        { }

        public void ShowMenu()
        {
            //Tekenen
            TekenBalk(1);
            TekenOpties(2);
            TekenBalk(5);
        }
        private void TekenBalk(int hoogte)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, hoogte);
                Console.Write('*');
            }
        }
        private void TekenOpties(int hoogte)
        {
            Console.SetCursorPosition(5, hoogte);
            Console.Write("A) Voeg zetel toe op willekeurige locatie");
            Console.SetCursorPosition(5, hoogte + 1);
            Console.Write("B) Beweeg kaart naar beneden");
            Console.SetCursorPosition(5, hoogte + 2);
            Console.Write("Wat wilt u doen?...");
        }
        public void GetInput(List<MapObject> list)
        {
            string input = Console.ReadLine();
            if (input == "A" || input == "a")
            {
                //Voeg randomzetel toe
                Random randlocation = new Random();
                list.Add(new ZetelElement(new Point(randlocation.Next(2, Console.WindowWidth - 15), randlocation.Next(10, Console.WindowHeight - 15)), 5));
            }
            if (input == "B" || input == "b")
            {
                //Beweeg kaart naar beneder
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Location = new Point(list[i].Location.X, list[i].Location.Y + 1);
                }
            }
        }
    }
}
