using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    
    internal class Library
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
        static Library()
        {
            connection = new SqlConnection(connectionString);
        }
        public static int GetAuthorID(string first_name, string last_name)
        {
            string cmd = $"(SELECT author_id FROM Authors WHERE first_name = @first_name AND last_name = @last_name)";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@first_name", SqlDbType.NVarChar, 150).Value = first_name;
            command.Parameters.Add("@last_name", SqlDbType.NVarChar, 150).Value = last_name;
            connection.Open();
            int author_id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return author_id;
        }
        public static void InsertBook(string title, string first_name, string last_name)
        {
            string cmd = $@"
            IF NOT EXISTS(SELECT book_id FROM BOOKS WHERE author = @author AND title = @title)
            BEGIN
                INSERT Books(title, author)
                VALUES (@title, @author)
            END";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@title", SqlDbType.NVarChar, 256).Value = title;
            command.Parameters.Add("@author", SqlDbType.Int).Value = GetAuthorID(first_name, last_name);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void InsertAuthor(string first_name, string last_name)
        {
            //string cmd = $"INSERT Authors(first_name, last_name) VALUES ('{first_name}', '{last_name}')";
            string cmd = "INSERT Authors(first_name, last_name) VALUES (@first_name, @last_name)";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.AddWithValue("@first_name", first_name);
            command.Parameters.AddWithValue("@last_name", last_name);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void SelectAuthors()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //Здесь в принципе параметризованный запрос не нужен, потому что у юзера нет возможности передать входные данные.
            //Параметры в условии отбора играют абсолютно номинальную роль и вместо них может быть что угодно, что вернет тру.
            command.CommandText = "SELECT * FROM Authors ";
            //Вроде как параметры предназначены только для конкретных значений, которые могут быть в полях таблиц, для самих имен таблиц их не завезли.
            //command.Parameters.AddWithValue("@Table", "Authors");
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
            reader.Close();
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
        public static void SelectBooks()
        {
            string cmd = "SELECT * FROM Books, Authors WHERE author = author_id";
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
            reader.Close();
            connection.Close();
            Console.WriteLine("End of Connection");
        }
        //А вот как параметризовать селект я понятия не имею, потому что надо интерпретировать строки как бул, таблицы и поля.
        //public static void Select(string columns, string tables, string condition)
        //{
        //    string cmd = $"SELECT {columns} FROM {tables} WHERE {condition}";
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
        //                Console.Write(reader[i].ToString().PadRight(padding));
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //    reader.Close();
        //    connection.Close();
        //}
    }
}
