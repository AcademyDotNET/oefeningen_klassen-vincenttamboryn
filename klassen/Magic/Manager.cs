using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Manager
    {
        public List<Card> cards = new List<Card>();
        public readonly int openingHandSize = 5;
        public Manager()
        {
            
        }
        public void UseCard(int index)
        {
            if (index >= cards.Count || index <0)
            {
                index = 0;
            }
            if (cards[index] is Creature)
            {
                Creature cardToPlay = (Creature)cards[index];
                cardToPlay.Use();
            }
            else if (cards[index] is Spell)
            {
                Spell cardToPlay = (Spell)cards[index];
                cardToPlay.Use();
            }
            else
            {
                Land cardToPlay = (Land)cards[index];
                cardToPlay.Use();
            }
        }
        public void DrawOpeningHand()
        {
            Random drawRandom = new Random();
            for (int i = 0; i < openingHandSize; i++)
            {
                int draw = drawRandom.Next(0, 3);
                switch (draw)
                {
                    case 0:
                        Card newdraw = new Creature();
                        cards.Add(newdraw);
                        break;
                    case 1:
                        Card newdraw1 = new Spell();
                        cards.Add(newdraw1);
                        break;
                    case 2:
                        Card newdraw2 = new Land();
                        cards.Add(newdraw2);
                        break;
                }
            }
        }
    }
}
