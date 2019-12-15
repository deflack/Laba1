using System;

namespace Lab6
{
    class Book
    {
        [New("Описание для Name")]
        public string Name { get; set; }
        [New("Описание для NumberOfPages")]
        public int NumberOfPages { get; set; }
        public Book(string Name, int NumberOfPages)
        {
            this.Name = Name;
            this.NumberOfPages = NumberOfPages;
        }
        public void Info()
        {
            Console.WriteLine($"\nКнига называется \"{Name}\" и имеет число страниц: ~{NumberOfPages}.");
        }
    }
}
