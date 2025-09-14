using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBookId(int id);
        List<Book> GetAllBooks();
        List<Book> GetBooksByAuthor(string author);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
    }
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        
        public Book(int id, string title, string author, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Id},{Title},{Author},{Year}");
        }
    }

    class InMemomoryBookRepository : IBookRepository
    {
        private List<Book> _books = new List<Book>();

        public void AddBook( Book book )
        {
            _books.Add( book );
        }

        //Я узнал что для нахождения книги по id, при помощи LINQ я могу использовать
        //методы FirstOrDefault() или SingleOrDefault(). Я выбрал второе т.к. в
        //библиотеке каждая книга имеет уникальный id. Немного изучив LINQ я пришел
        //к мнению, что будет проще использовать его чем я бы искал нужный id книги
        //через foreach
        public Book GetBookId(int id)
        {
            var resultFinfBook = _books.SingleOrDefault(book => book.Id == id);
            return resultFinfBook;
        }

        public List<Book> GetAllBooks()
        {
            //var allBooks = _books.Select(book => new Book { Id = book.Id, Title = book.Title, Author = book.Author, Year = book.Year }).ToList;
            return _books;
        }
    }
}
