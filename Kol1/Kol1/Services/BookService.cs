using Kol1.Models.DTOs;

namespace Kol1.Services;

    public class BookService
    {
        private readonly List<Book> _books = new List<Book>();

        public BookService()
        {
            _books.Add(new Book
            {
                Id = 1,
                Title = "The Hobbit",
                Authors = new List<Author>
                {
                    new Author { Id = 1, FirstName = "John", LastName = "Tolkien" }
                }
            });
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }
    }

