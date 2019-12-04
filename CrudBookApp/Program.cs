using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a console app named CrudBookApp to connect to a local database.
//Use SQL parameters for that
//Print the inserted id (Execute scalar with select identity)
//Update a book(read id from console)
//Delete a book(read id from console)
//Select a book(read id from console)
namespace CrudBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
                Book book = new Book();
                book.Title = "Amintiri din copilarie";
                book.PublisherId = 1;
                book.Year = 1980;
                book.Price = 10;
                BookData obj = new BookData();
            // obj.InsertBook(book);
            // obj.GetBooks();
           // obj.deleteBooks();

        Console.ReadLine();
        }
    }
}
