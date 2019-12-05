using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a console app named SummaryBookApp to connect to a local database.Here print to console: (*) - not yet
//All the books that are published in 2010
//The book that is published in the max year (can use multiple commands)
//Top 10 books(Title, Year, Price)


namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MARIA-PC\\SQLEXPRESS;Initial Catalog=BookCRUD;Integrated Security=True";
            SqlConnection connetion = new SqlConnection(connectionString);
            connetion.Open();
            // SelectYear(connectionString);
           // SelectTop10(connectionString);
            SelectMaxPrice(connectionString);

            Console.ReadLine();
        }
        private static void SelectYear(string connectionString)
        {
            string query = " select [Title], Year from Book where Year = 2010";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandSelect = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    var moreResults = true;
                    while (reader.Read())
                    {
                        var row = reader;
                        var title = row["Title"];
                        var year = row["Year"];
                        Console.WriteLine($"{title}-{year}");
                    }
                    moreResults = reader.NextResult();
                }
            }
        }

        private static void SelectTop10(string connectionString)
        {
            string query = "SELECT TOP 10 *FROM  Book;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandSelect = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    var moreResults = true;
                    while (reader.Read())
                    {
                        var row = reader;
                        var title = row["Title"];
                        var id = row["PublisherId"];
                        var year = row["Year"];
                        var price = row["Price"];
                        Console.WriteLine($"{title}-{id}-{year}-{price}");
                    }
                    moreResults = reader.NextResult();
                }
            }


        }

        private static void SelectMaxPrice(string connectionString)
        {
            // string query = "select  Title ,Year from Book where Price = (select MAX(Price) as MaxPrice from Book);";
            string query = "select Title,Year from Book";
            query += "select MAX(Price) as MaxPrice from Book";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand commandMax = new SqlCommand(query, connection);
                connection.Open();
                using(SqlDataReader reader = commandMax.ExecuteReader())
                {
                    var moreResults = true;
                    while (reader.Read())
                    {
                        var row = reader;
                        var title = row["Title"];
                        var year = row["Year"];
                        Console.WriteLine($"{title}-{year}");
                    }
                    moreResults = reader.NextResult();
                }

               
            }

        }
    }
}
