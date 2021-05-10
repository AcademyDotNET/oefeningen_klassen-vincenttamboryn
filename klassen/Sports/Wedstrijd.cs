using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports
{
    class Wedstrijd
    {
        List<ISpeler> Spelers;
        public Wedstrijd()
        {
            Spelers = new List<ISpeler>();
            Spelers.Add(new BeerPongPlayer("Vincois", Beers.Duvel, 55, false, "HotHands"));
            Spelers.Add(new BeerPongPlayer("Wampa", Beers.Duvel, 50, false, "HotHands"));
            Spelers.Add(new BeerPongPlayer("Koube", Beers.Duvel, 45, false, "Lamzakken"));
            Spelers.Add(new BeerPongPlayer("Trikkendoedel", Beers.Duvel, 60, false, "Lamzakken"));
        }
        public void start()
        {
            BeerPongPlayer.SimulateGame(Spelers[0] as BeerPongPlayer);
            BeerPongPlayer.SimulateGame(Spelers[1] as BeerPongPlayer);
            BeerPongPlayer.SimulateCompetition(Spelers[0] as BeerPongPlayer, Spelers[1] as BeerPongPlayer);

            BeerPongPlayer champion = BeerPongPlayer.BestPlayer(Spelers[0] as BeerPongPlayer, Spelers[1] as BeerPongPlayer);
            champion.ThrowBall();
            champion.DrinkBeer();
        }
    }
}
