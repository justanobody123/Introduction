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

            //Console.WriteLine("Введите название книги: ");
            //string title = Console.ReadLine();
            //Console.WriteLine("Введите имя автора: ");
            //string first_name = Console.ReadLine();
            //Console.WriteLine("Введите фамилию автора: ");
            //string last_name = Console.ReadLine();
            Library.InsertBook("Windows via C/C++ 5th Edition", "Jeffrey", "Richter");
            Library.SelectBooks();
            //Library.Select("title, first_name, last_name", "Authors, Books", "author = author_id");
            //Library.SelectAuthors();
            //Console.WriteLine(Library.GetAuthorID("James", "Cameron").ToString());
        }
        
    }
}
