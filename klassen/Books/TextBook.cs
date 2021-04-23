using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class TextBook:Book
    {
        public int GradeLevel { get; set; }
        public override double Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                if (value > 20 && value < 80)
                {
                    base.Price = value;
                } 
            }
        }
        public TextBook(string author, string title, double price, int isbn) : base(author, title, price, isbn)
        {
        }
    }
}
