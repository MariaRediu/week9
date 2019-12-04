using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a new console app named SummaryPublisherApp.Here print to console:
//Number of rows from the Publisher table (Execute scalar)
//Top 10 publishers (Id, Name) (SQL Data Reader)
//Number of books for each publisher(Publisher Name, Number of Books)
//The total price for books for a publisher
namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MARIA-PC\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True";
            SqlConnection connetion = new SqlConnection(connectionString);
            connetion.Open();
            // NumberRow(connectionString);
            // SelectTop10(connectionString);
            // SelectNumberOfBook(connectionString);
            CalculatePrice(connectionString);
            Console.ReadLine();

        }

        public static int NumberRow(string connectionString)
        {
            string query = "SELECT COUNT(*) AS Counts FROM [Publisher];";
            int count = 0;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand commandCount=new SqlCommand(query, connection))
                {
                    connection.Open();
                    count = (int)commandCount.ExecuteScalar();
                    Console.WriteLine($"Number of rows from the Publisher table is {count}");

                }
            }
            return count;
        }

        private static void SelectTop10(string connectionString)
        {
            string query = "SELECT TOP 10 *FROM  [Publisher];";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandSelect = new SqlCommand(query, connection);
                connection.Open();
                    using (SqlDataReader reader=commandSelect.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             var row = reader;
                             var id = row["PublisherId"];
                             var name = row["Name"];
                             Console.WriteLine($"{id}-{name}");
                         }
                    }
            }
           
            
        }
        private static void SelectNumberOfBook(string connectionString)
        {
            string query = "select p.PublisherId, p.Name ,COUNT(p.PublisherId) as NumberOfBook"
                            +"from[Publisher] as p "
                            +" join Book as b on b.PublisherId = p.PublisherId"
                            +"group by p.PublisherId, p.Name";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand commandNumber = new SqlCommand(query, connection);
                connection.Open();
                using(SqlDataReader reader = commandNumber.ExecuteReader())
                {
                    var moreResults = true;
                    while (reader.Read())
                    {
                        var row = reader;
                        var id = row["PublisherId"];
                        var name = row["Name"];
                        var count = row["NumberOfBook"];
                        Console.WriteLine($"{id}-{name}-{count}");
                    }
                    moreResults = reader.NextResult();
                }
            }                                                                                      


        }
        private static void CalculatePrice(string connectionString)
        {
            string query = "select  PublisherId,sum(Price) as SumOfPrice "
                            + "from Book group by PublisherId";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand commandPrice = new SqlCommand(query, connection);
                connection.Open();
                using(SqlDataReader reader = commandPrice.ExecuteReader())
                {
                    var moreResults = true;
                    while (reader.Read())
                    {
                        var row = reader;
                        var id = row["PublisherId"];
                        var price = row["SumOfPrice"];
                        Console.WriteLine($"The price of books for publisher with id {id} is {price}");

                    }
                    moreResults = reader.NextResult();
                }
                    
            }
        }
    }
}
