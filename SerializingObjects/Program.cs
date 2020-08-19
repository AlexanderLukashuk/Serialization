using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerializingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("книга 1", 3000, "автор 1", 1998);
            Book book2 = new Book("книга 2", 2500, "автор 2", 1990);
            Book book3 = new Book("книга 3", 4500, "автор 3", 1993);
            List<Book> books = new List<Book>() { book1, book2, book3 };

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("books.txt", FileMode.OpenOrCreate))
            {
                foreach (var book in books)
                {
                    formatter.Serialize(stream, book);
                }
                stream.Close();
            }


            Book newBook = new Book();
            List<Book> newBooks = new List<Book>();
            using (FileStream stream = new FileStream("books.txt", FileMode.OpenOrCreate))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    newBook = (Book)formatter.Deserialize(stream);
                    newBooks.Add(newBook);
                }
            }

            foreach (var book in newBooks)
            {
                Console.WriteLine($"Name: {book.name}");
                Console.WriteLine($"Price: {book.price}");
                Console.WriteLine($"Author: {book.author}");
                Console.WriteLine($"Publish year: {book.pubYear}");
            }

            User user = new User("Georg", 20);
            User admin = new User("admin", 28);

            bool userIsValid = ValidateUser(user);
            bool adminIsValid = ValidateUser(admin);

            Console.WriteLine($"Реультат валидации {user.Name}: {userIsValid}");
            Console.WriteLine($"Реультат валидации {admin.Name}: {adminIsValid}");
        }

        static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (NameValidationAtribute attr in attrs)
            {
                if (user.Name == attr.Name) return true;
                else return false;
            }
            return true;
        }
    }
}
