using DataAccessConnection;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookRepository
    {
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                var query = "select * from Book";
                var connection = ConnectionManager.GetSqlConnection();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    Book book = new Book();
                    book.BookId=(int)currentRow["BookId"];
                    book.Title = (string)currentRow["Title"];
                    book.PublisherId = (int)currentRow["PublisherId"];
                    book.Year = currentRow["Year"] as int? ?? default(int);
                    if (!currentRow.IsDBNull(4))
                    {
                        book.Price = (decimal)currentRow["Price"];
                    }

                   

                    books.Add(book);
                }
               
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return books;
        }

    }
}
