using DataAccess;
using DataAccessConnection;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Ora2
{
    class Program
    {
        static void Main(string[] args)
        {
           // ConnectionManager.GetSqlConnection();

            BookRepository bookRepository = new BookRepository();
            List<Book> books = bookRepository.GetAllBooks();
            foreach (var book in books)
            {
              Console.WriteLine($"{book.Title}---{book.Price}");      
            }
            Console.ReadLine();
        }
    }
}
