using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class CoffeeTableBook:Book
    {
        public override double Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                if (value > 35 && value < 100)
                {
                    base.Price = value;
                }
            }
        }
        public CoffeeTableBook(string author, string title, double price, int isbn) : base(author, title, price, isbn)
        { 
        }
    }
}
