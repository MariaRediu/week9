using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Use SQL parameters for that
//Print the inserted id (Execute scalar with select identity)
//Update a book(read id from console)
//Delete a book(read id from console)
//Select a book(read id from console)

namespace CrudBookApp
{
    public class BookData
    {
        string connectionString = GetConnectionString();
        public BookData()
        {
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }
        }

        static private string GetConnectionString()
        {
            
            return "Data Source=MARIA-PC\\SQLEXPRESS;Initial Catalog=BookCRUD;Integrated Security=True";
        }
        public int InsertBook(Book book)
        {
           
           
                string query = "Insert into Book (Title ,PublisherId, Year,Price) Values(@0, @1, @2, @3);"
                                           + "select scope_identity();";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand commandInsert = new SqlCommand(query, connection);

                SqlParameter titleParam = new SqlParameter("@0", book.Title);
                SqlParameter PublisherIdParam = new SqlParameter("@1", book.PublisherId);
                SqlParameter YearParam = new SqlParameter("@2", book.Year);
                SqlParameter PriceParam = new SqlParameter("@3", book.Price);

                commandInsert.Parameters.Add(titleParam);
                commandInsert.Parameters.Add(PublisherIdParam);
                commandInsert.Parameters.Add(YearParam);
                commandInsert.Parameters.Add(PriceParam);

                int newBookId = (int)commandInsert.ExecuteScalar();

                commandInsert.Dispose();
                connection.Close();
                connection.Dispose();

                return newBookId;        
        }
        public List<Book> GetBooks()
        {
            List<Book> result = new List<Book>();
            string query = "select *from  Book";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand commandSelect = new SqlCommand(query, connection);

            SqlDataReader reader = commandSelect.ExecuteReader();
            Book b = null;

            while (reader.Read())
            {
                b = new Book();
                var row = reader;
                b.Title = (string)row["Title"];
                b.PublisherId =(int)row["PublisherId"];
                b.Year =(int)row["Year"];
                b.Price =(decimal)row["Price"];
                Console.WriteLine($"{b.Title} {b.PublisherId} {b.Year} {b.Price}");
            }
            return result;
                

        }

        public bool deleteBooks()
        {
            bool result = false;
            string query = "delete from Book";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand commandDelete = new SqlCommand(query, connection);

            int rowDelete = commandDelete.ExecuteNonQuery();
            if (rowDelete != 0)
              {
                result = true;
              }

            commandDelete.Dispose();
            connection.Close();
            connection.Dispose();

            return result;
        }

        public int SaveUpdate(Book book)
        {
            var queryCreate  = String.Format("insert into Book([Title],[PublisherId],[Year],[Price]) values('{0}',{1},{2},{3} ); "
                                    + "Select @@Identity", book.Title, book.PublisherId, book.Year, book.Price);

            var updateQuery = String.Format("Update Book SET Title='{0}', PublisherId = {1}, Year ={2}, Price = {3} Where BookId = {4};",
                                     book.Title, book.PublisherId, book.Year, book.Price, book.BookId);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = null;
            if (book.BookId != 0)
            {
                command = new SqlCommand(updateQuery, connection);
            }
            else
            {
                command = new SqlCommand(queryCreate, connection);
            }
            int saveBookID = 0;
            try
            {
                var commandExecute = command.ExecuteScalar();
                if (commandExecute != null)
                {
                    saveBookID= Convert.ToInt32(commandExecute);
                }
                else
                {
                    saveBookID = book.BookId;

                }

            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message); ;
            }

            command.Dispose();
            connection.Close();
            connection.Dispose();

                return saveBookID;
        }
    }
}



