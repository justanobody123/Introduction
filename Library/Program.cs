using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Library
{
    
    internal class Program
    {
        const string connectionString = @"
                        Data Source=(localdb)\MSSQLLocalDB;
                        Initial Catalog=Library_PD_311;
                        Integrated Security=True;
                        Connect Timeout=30;
                        Encrypt=False;
                        TrustServerCertificate=False;
                        ApplicationIntent=ReadWrite;
                        MultiSubnetFailover=False";
        static SqlConnection connection;
        static Program()
        {
            connection = new SqlConnection(connectionString);
        }
        static void Main(string[] args)
        {
            //SelectAuthors();
            string cmd = "SELECT title, first_name, last_name FROM Books, Authors WHERE author = author_id";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int padding = 32;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i).PadRight(padding));
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i).ToString().PadRight(padding));
                    }
                    Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
                }
            }
            connection.Close();
            Console.WriteLine("End of Connection");
        }
        static void SelectAuthors()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Authors";
            command.Connection = connection;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            const int padding = 32;
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i).PadRight(padding));
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    //Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i).ToString().PadRight(padding));
                    }
                    Console.WriteLine();
                }
            }
            connection.Close();
        }
    }
}
