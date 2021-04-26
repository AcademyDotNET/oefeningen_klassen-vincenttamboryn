using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextBasedRPG
{
    class GameManager
    {
        public GameManager()
        {
            InitGame();
        }
        private Location currentLocation = null;
        public bool Exit { get; set; }

        public void DescribeLocation()
        {
            this.currentLocation.Describe();
        }

        public void VerwerkActie()
        {
            string actie = Console.ReadLine();
            bool error = false;
            if (actie == "n")
            {
                currentLocation = currentLocation.GettLocationOnMove(Directions.North, playerInventory);
            }
            else if (actie == "o")
            {
                currentLocation = currentLocation.GettLocationOnMove(Directions.East, playerInventory);
            }
            else if (actie == "w")
            {
                currentLocation = currentLocation.GettLocationOnMove(Directions.West, playerInventory);
            }
            else if (actie == "z")
            {
                currentLocation = currentLocation.GettLocationOnMove(Directions.South, playerInventory);
            }
            else if (actie == "p")
            {
                if (currentLocation.ObjectsInRoom.Count > 0)
                {
                    foreach (var item in currentLocation.ObjectsInRoom)
                    {
                        playerInventory.Add(item);
                        currentLocation.ObjectsInRoom.Remove(item);
                        Console.WriteLine($"je raapt {item.Name} op.");
                        Console.WriteLine(item.Description);
                        Thread.Sleep(500);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Er is hier niets om op te rapen.");
                    Thread.Sleep(500);
                }
            }
            else if (actie == "e")
                Exit = true;
            else
            {
                error = true;
            }
            Console.Clear();
            if (error)
                Console.WriteLine("Onbekende actie");
        }

        public void ToonActies()
        {
            Console.WriteLine("Mogelijke acties: (typ bijvoorbeeld n indien u naar het noorden wil)");
            Console.WriteLine("n= noord");
            Console.WriteLine("o= oost");
            Console.WriteLine("z= zuid");
            Console.WriteLine("w= west");

            Console.WriteLine("p= oprapen");

            Console.WriteLine("e= exit");
        }

        private List<Location> GameLocation = new List<Location>();
        private List<GameObjects> Objects = new List<GameObjects>();
        private List<GameObjects> playerInventory = new List<GameObjects>();
        private void InitGame()
        {
            //Maak Locaties
            Location l1 = new Location()
            {
                Title = "De poort",
                Description =
                                      "Je staat voor een grote grijze poort die op een kier staat. Rondom je is prikkeldraad, je kan enkel naar het noorden, door de poort gaan. "
            };

            Location l2 = new Location()
            {
                Title = "Receptie",
                Description =
                                      "De receptie....veel blijft er niet meer over van wat eens een bruisende omgeving was. Hier en daar zie je skeletten van , waarschijnlijk, enkele studenten. Een grote poort staat op een kier naar het zuiden. Je ziet twee deuren aan de westelijke en noordelijke zijde."

            };

            Location l3 = new Location()
            {
                Title = "Koffieruime",
                Description =
                    "Je staat in de koffieruimte achter de receptie. Menig pralinetje is hier vroeger met veel gusto opgesmikkeld. Een lege pralinedoos is het enige bewijs dat het hier ooit gezellig was. Een deur is de enige uitgang uit deze kamer naar het oosten."
            };

            Location l4 = new Location()
            {
                Title = "Tuin",
                Description =
                    "Het is duidelijk herfst. Een kale boom en vele bruine bladeren op de grond...mistroosteriger kan eigenlijk niet. Je ziet een deur in het zuiden en in het westen en een grote klapdeur naar het noorden."

            };

            Location l5 = new Location()
            {
                Title = "Cafetaria",
                Description =
                    "Ooit was dit een bruisende locati: veel eten, geroezemoes en licht door de grote ruiten. Nu enkel stof en lege tafel. Enkel een klapdeur is zichtbaar naar het zuiden."
            };

            Location l6 = new Location()
            {
                Title = "Gang",
                Description =
                    "Een brede gang waar makkelijk 5 mensen schouder aan schouder door kunnen. Zowel in het oosten als het westen zie je een deur."

            };

            Location l7 = new Location()
            {
                Title = "Computerruimte",
                Description =
                    "Eindelijk; je hebt het gehaald. De plek waar iedereen naar toe wil: het computerlabo!"
            };

            //Place objects in rooms
            GameObjects keytol7 = new GameObjects() { Description = "Verroest en groot", Name = "Sleutel" };
            l5.ObjectsInRoom.Add(keytol7);

            //Place exits
            l1.Exits.Add(new Exit() { ExitDirection = Directions.North, GoesToLocation = l2 });

            l2.Exits.Add(new Exit() { ExitDirection = Directions.South, GoesToLocation = l1 });
            l2.Exits.Add(new Exit() { ExitDirection = Directions.West, GoesToLocation = l3 });
            l2.Exits.Add(new Exit() { ExitDirection = Directions.North, GoesToLocation = l4 });

            l3.Exits.Add(new Exit() { ExitDirection = Directions.East, GoesToLocation = l2 });

            l4.Exits.Add(new Exit() { ExitDirection = Directions.South, GoesToLocation = l2 });
            l4.Exits.Add(new Exit() { ExitDirection = Directions.West, GoesToLocation = l6 });
            l4.Exits.Add(new Exit() { ExitDirection = Directions.North, GoesToLocation = l5 });

            l5.Exits.Add(new Exit() { ExitDirection = Directions.South, GoesToLocation = l4 });

            l6.Exits.Add(new Exit() { ExitDirection = Directions.West, GoesToLocation = l4 });
            l6.Exits.Add(new Exit() { ExitDirection = Directions.East, GoesToLocation = l7, NeedsObject = new List<GameObjects>() { keytol7 } }); //needs key condition

            l7.Exits.Add(new Exit() { ExitDirection = Directions.East, GoesToLocation = l6 }); //Winning room

            //Voeg locatie toe
            GameLocation.Add(l1);
            GameLocation.Add(l2);
            GameLocation.Add(l3);
            GameLocation.Add(l4);
            GameLocation.Add(l5);
            GameLocation.Add(l6);
            GameLocation.Add(l7);

            currentLocation = l1;
        }
    }
}
