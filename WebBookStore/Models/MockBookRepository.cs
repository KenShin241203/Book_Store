using System.Collections.Generic;
using System.Linq;
using WebBookStore.Models;
namespace WebBookStore.Models
{
    public class MockBookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        public MockBookRepository()
        {
            _books = new List<Book>();
            {
                new Book
                {
                    ID = 1,
                    Title = "Death in the Clan",
                    Author = "Carly Reid",
                    PublishYear = 2023,
                    Price = 2.5,
                    Cover = "images/book1.jpg"
                };
            }
        }
        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(p => p.ID == id);
        }
        public void Add(Book book)
        {
            book.ID = _books.Max(p => p.ID)+1;
            _books.Add(book);
        }


        public void Update(Book book)
        {
            var index = _books.FindIndex(p => p.ID == book.ID);
            if (index != -1)
            {
                _books[index] = book;
            }
        }

        public void Delete(int id)
        {
            var book = _books.FirstOrDefault(p => p.ID == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }   

    }

}
