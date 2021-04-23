using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Playership : Block
    {
        private int health;

        public int Health
        {
            get { return health; }
        }
        public List<Bullet> bulletfired = new List<Bullet>();

        public Playership(int xin, int yin, int healthin) : base(xin, yin)
        {
            health = healthin;
            drawChar = '@';
        }
        public void Fire()
        {
            bulletfired.Add(new Bullet(X, Y - 1, false));
        }
        public void Update(ConsoleKeyInfo richting)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            switch (richting.Key)
            {
                case ConsoleKey.UpArrow:
                    Fire();
                    break;
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                default:
                    break;
            }
        }
        public void Hit()
        {
            health -= 1;
            if (health <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            Console.Clear();
            Console.WriteLine("You lost!");
            Console.ReadLine();
        }
    }
}
