using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speelkaarten
{
    class GeschudPakKaarten
    {
        public Stack<Speelkaart> GeschudPak;
        public GeschudPakKaarten()
        {
            GeschudPak = new Stack<Speelkaart>();
            List<Speelkaart> cards = new List<Speelkaart>();
            foreach (var item in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    cards.Add(new Speelkaart(item, (i)));
                }
            }
            cards = KaartenSchudden(cards);
            for (int i = 0; i < cards.Count(); i++)
            {
                GeschudPak.Push(cards[i]);
            }
        }
        public List<Speelkaart> KaartenSchudden(List<Speelkaart>ongeschudPak)
        {
            List<Speelkaart> cards = new List<Speelkaart>();
            Random schudder = new Random();
            for (int i = 1; i < ongeschudPak.Count();)
            {
                int newCard = schudder.Next(0, ongeschudPak.Count);
                cards.Add(ongeschudPak[newCard]);
                ongeschudPak.Remove(ongeschudPak[newCard]);
            }
            return cards;
        }
    }
}
