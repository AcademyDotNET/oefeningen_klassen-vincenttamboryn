using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Book
    {
        private double price;
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public virtual double Price
        {
            get { return price; }
            set { price = value; }
        }
        public Book(string author, string title, double price, int isbn)
        {
            Author = author;
            Title = title;
            Price = price;
            ISBN = isbn;
        }
        public static Book TelOp(Book book1, Book book2)
        {
            if (book1.Author == book2.Author)
            {
                Book omnibus = new Book(book1.Author, $"Omnibus of {book1.Author}", (book1.price + book2.price) / 2, book1.ISBN+book2.ISBN);
                return omnibus;
            }
            else
            {
                Book omnibus = new Book($"{book1.Author}, { book2.Author}", $"Omnibus of {book1.Author}, {book2.Author}", (book1.price + book2.price) / 2, book1.ISBN + book2.ISBN);
                return omnibus;
            }
        }
        public override string ToString()
        {
            return $"{Title} - {Author} ({ISBN}) {Price}";
        }
        public override bool Equals(object obj)
        {
            //bedankt Michiel
            if (this == null || obj == null || obj.GetType().BaseType != typeof(Book))
            {
                return false;
            }
            else
            {
                Book test = (Book)obj;
                if (this.ISBN == test.ISBN)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
