using System;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Stephen king", "The Shining", 50, 058481052);
            Book book2 = new Book("Stephen king", "IT", 25, 048481051);
            TextBook book3 = new TextBook("Griffiths","Intrioduction to Electrodynamics", 65, 047412348);
            CoffeeTableBook book4 = new CoffeeTableBook("Kath Stathers", "The Bucket List: 1000 Adventures Big & Small", 90, 045162156);
            Book book5 = new Book("James S.A. Corey", "Leviathan Wakes", 26, 045162156);

            Book omnibus1 = Book.TelOp(book1,book2);
            Book omnibus2 = Book.TelOp(book1, book4);

            Console.WriteLine(book4.Equals(book3));
            Console.WriteLine(book5.Equals(book4));

            Console.WriteLine(book1.ToString());
            Console.WriteLine(book2.ToString());
            Console.WriteLine(book3.ToString());
            Console.WriteLine(book4.ToString());
            Console.WriteLine(book5.ToString());
            Console.WriteLine(omnibus1.ToString());
            Console.WriteLine(omnibus2.ToString());

        }
    }
}
