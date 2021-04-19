using System;

namespace Sports
{
    class Program
    {
        static void Main(string[] args)
        {
            BeerPongPlayer vincent = new BeerPongPlayer();
            BeerPongPlayer kobe = new BeerPongPlayer();
            BeerPongPlayer wom = new BeerPongPlayer();
            BeerPongPlayer hendrik = new BeerPongPlayer();

            vincent.StelIn("Vincois", BeerPongPlayer.Beers.Duvel, 55,false ,"HotHands");
            wom.StelIn("Wampa", BeerPongPlayer.Beers.Duvel, 50, false, "HotHands");
            kobe.StelIn("Koube", BeerPongPlayer.Beers.Duvel, 45, false, "Lamzakken");
            hendrik.StelIn("Trikkendoedel", BeerPongPlayer.Beers.Duvel, 60, false, "Lamzakken");
            /*
            vincent.ThrowBall();
            wom.ThrowBall();
            kobe.ThrowBall();
            hendrik.ThrowBall();

            for (int i = 0; i < 5; i++)
            {
                vincent.drinkBeer();
                wom.drinkBeer();
                kobe.drinkBeer();
                hendrik.drinkBeer();
            }
            */


            BeerPongPlayer.SimulateGame(vincent);
            BeerPongPlayer.SimulateGame(hendrik);
            BeerPongPlayer.SimulateCompetition(vincent, hendrik);

            BeerPongPlayer champion = BeerPongPlayer.BestPlayer(vincent, hendrik);
            champion.ThrowBall();
            champion.drinkBeer();

        }
    }
}
