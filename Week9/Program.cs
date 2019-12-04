using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=MARIA-PC\\SQLEXPRESS;Initial Catalog=Week9;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            connection.Close();
        }
            private static void SelectAll(SqlConnection connection)
            {
                try
                {
                    var query = "select top 10 * from Publisher where PublisherId<10 ";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var currentRow = dataReader;
                        var id = currentRow["PublisherId"];
                        var name = currentRow["Name"];
                        Console.WriteLine($"{id}-{name}");
                    }
                dataReader.Close();

                }
                catch (SqlException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            //private static void DeleteCommand(SqlConnection connection)
            //{

            //    try
            //    {
            //        Console.WriteLine("Introduceti id:");
            //        int id = int.Parse(Console.ReadLine());
            //        var commandQuery3 = "delete from Publisher where PublisherId=@PubIdParam";
            //        SqlParameter param = new SqlParameter("@PubIdParam", id);
            //        SqlCommand deleteCommand = new SqlCommand(commandQuery3, connection);
            //        deleteCommand.Parameters.Add(param);
            //        deleteCommand.ExecuteNonQuery();
            //    }
            //    catch (SqlException e)
            //    {

            //        Console.WriteLine(e.Message);
            //    }
               
            //}

            ////insertrow
            //try
            //{
            //    var commandQuery = "insert into Publisher values(4,'Bianca')";
            //    SqlCommand insertCommand = new SqlCommand(commandQuery, connection);
            //    insertCommand.ExecuteNonQuery();
            //}
            //catch (SqlException e)
            //{

            //    Console.WriteLine(e.Message); 
            //}

            ////updaterow
            
            //try
            //{
            //    var commandQuery1 = "update Publisher set Name='Dan 2' where PublisherId=2 ";
            //    SqlCommand updateCommand = new SqlCommand(commandQuery1, connection);
            //    updateCommand.ExecuteNonQuery();
            //}
            //catch (SqlException e)
            //{

            //    Console.WriteLine(e.Message); ;
            //}

            ////count
            //try
            //{
            //    var commandQuery2 = "select count(PublisherId) from Publisher ";
            //    SqlCommand countCommand = new SqlCommand(commandQuery2, connection);
            //    var count = countCommand.ExecuteScalar();
            //    Console.WriteLine($"Count is:{count}");
            //}
            //catch (SqlException e)
            //{

            //    Console.WriteLine(e.Message); ;
            //}

               
            
        
    }
}
