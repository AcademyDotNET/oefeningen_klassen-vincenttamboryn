using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Manager
    {
        public List<Card> cards;
        public readonly int openingHandSize;
        public Manager()
        {
            Random drawRandom = new Random();
            for (int i = 0; i < openingHandSize; i++)
            {
                int draw = drawRandom.Next(0, 3);
                switch (draw)
                {
                    case 0:
                        cards.Add(new Creature());
                        break;
                    case 1:
                        cards.Add(new Spell());
                        break;
                    case 2:
                        cards.Add(new Land());
                        break;
                }
            }
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
    }
}
