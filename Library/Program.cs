using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;

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
            //SelectBooks();
            //Select("book_id, title, last_name, first_name", "Books, Authors", "author = author_id");

            //Console.Write("Введите имя: ");
            //string first_name = Console.ReadLine();
            //Console.WriteLine("Введите фамилию: ");
            //string last_name = Console.ReadLine();
            //InsertAuthor(first_name, last_name);
            //SelectAuthors();

            Console.WriteLine("Введите название книги: ");
            string title = Console.ReadLine();
            Console.WriteLine("Введите имя автора: ");
            string first_name = Console.ReadLine();
            Console.WriteLine("Введите фамилию автора: ");
            string last_name = Console.ReadLine();
            InsertBook(title, first_name, last_name);
            SelectBooks();
        }
        static int GetAuthorID(string first_name, string last_name)
        {
            string cmd = $"(SELECT author_id FROM Authors WHERE first_name = '{first_name}' AND last_name = '{last_name}')";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            int author_id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return author_id;
        }
        static void InsertBook(string title, string first_name, string last_name)
        {   
            
            int author = GetAuthorID(first_name, last_name);
            string cmd = $"INSERT Books(title, author) VALUES ('{title}', {author})";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        static void InsertAuthor(string first_name, string last_name)
        {
            string cmd = $"INSERT Authors(first_name, last_name) VALUES ('{first_name}', '{last_name}')";
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
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
        //static void Select(string fields, string from, string where)
        //{
        //    fields = fields.Trim();
        //    from = from.Trim();
        //    where = where.Trim();
        //    string cmd = $"Select {fields} FROM {from} WHERE {where}";
        //    //Console.WriteLine(cmd);
        //    SqlCommand command = new SqlCommand(cmd, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows) 
        //    {
        //        int padding = 32;
        //        for (int i = 0; i < reader.FieldCount; i++)
        //        {
        //            Console.Write(reader.GetName(i).PadRight(padding));
        //        }
        //        Console.WriteLine();
        //        while (reader.Read())
        //        {
        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                Console.Write(reader.GetValue(i).ToString().PadRight(padding));
        //            }
        //            Console.WriteLine("\n-----------------------------------------------------------------------------------\n");
        //        }
        //        connection.Close();
        //        Console.WriteLine("End of Connection");
        //    }
        //}
        static void SelectBooks()
        {
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
        static void Select(string columns, string tables, string condition)
        {
            string cmd = $"SELECT {columns} FROM {tables} WHERE {condition}";
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
                    for(int i = 0;i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i].ToString().PadRight(padding));
                    }
                    Console.WriteLine();
                }
            }
            reader.Close();
            connection.Close();
        }
    }
}
