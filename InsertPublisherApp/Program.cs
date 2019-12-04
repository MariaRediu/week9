using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a console app named InsertPublisherApp to connect to a local database.
//With this console read the name of the publisher and insert a new publisher to the database.
//Use SQL parameters for that.
//Print the inserted id (Execute scalar with select identity)
namespace InsertPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MARIA-PC\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //Console.WriteLine("Introduceti id:");
            //int id = int.Parse(Console.ReadLine());
             InsertName(connection);
           // SelectName(connectionString);
            Console.ReadLine();
        }

        private static void SelectName(string connectionString)
        {

            string query = "select Name from [Publisher]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
            }
        }

        private static void InsertName(SqlConnection connection)
        {
            string name = "Mihai Eminescu";

            try
            {
                
                var command = "insert into Publisher (Name) values (@NameParam);select scope_identity(); ";
                SqlParameter nameParam = new SqlParameter("@NameParam", name);
                SqlCommand insertCommand = new SqlCommand(command, connection);
                insertCommand.Parameters.Add(nameParam);
                var id =insertCommand.ExecuteScalar();

            }
            catch (SqlException e)
            {

                Console.WriteLine(e.Message); 
            }
        }
    }
}
