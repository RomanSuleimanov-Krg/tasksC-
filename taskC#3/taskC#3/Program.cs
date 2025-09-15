using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskC_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InMemomoryBookRepository repositoryBook = new InMemomoryBookRepository();
            repositoryBook.AddBook(new Book(1, "Ведьмак1", "Анджей Сапковский", 2003));
            repositoryBook.AddBook(new Book(2, "Ведьмак:Кровь эльфов", "Анджей Сапковский", 2004));
            repositoryBook.GetAllBooks();
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

        public void AddBook(Book book)
        {
            _books.Add(book);
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

        //Была мысль возвращать данным методом книги таким образом, что выводился список книг который
        //состоял бы из названия и автора, однако не вышло и решил просто вовращать коллек-
        //цию со всеми книгами

        public List<Book> GetAllBooks()
        {
            //var allBooks = _books.Select(book => new Book { Id = book.Id, Title = book.Title, Author = book.Author, Year = book.Year }).ToList;
            var output = string.Join(Environment.NewLine, 
                _books.Select(b => $"Название:{b.Title}, автор: {b.Author}" +
                $", год написания:{b.Year}"));
            Console.WriteLine(output);
            
            return _books;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            var bookByAuthor = _books.Where(book => book.Author == author).ToList();
            return bookByAuthor;
        }

        public bool UpdateBook(Book book)
        {
            var bookToUpdate = _books.Find(b => b == book);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Year = book.Year;
                Console.WriteLine("Такая книга в библиотеке успешно найдена!!!");
                Console.WriteLine("Изменения применены");
                return true;
            }
            else
            {
                Console.WriteLine("Такой книги не найдено.\nИзменения не" +
                    " применены(");
                return false;
            }

        }
        public bool DeleteBook(int id)
        {
            var bookToDelete = _books.Find(book => book.Id == id);
            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
                return true;
            }
            else { return false; }
        }

    }
}
