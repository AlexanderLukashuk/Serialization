using System;

namespace SerializingObjects
{
    [Serializable]
    public class Book
    {
        public string name;
        public int price;
        public string author;
        public int pubYear;
        public Book() {}
        public Book(string name, int price, string author, int pubYear)
        {
            this.name = name;
            this.price = price;
            this.author = author;
            this.pubYear = pubYear;
        }
    }
}