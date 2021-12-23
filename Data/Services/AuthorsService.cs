using System;
using System.Linq;
using my_books.Data.Models;
using my_books.Data.ViewModel;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDBContext _context;
        public AuthorsService(AppDBContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            var  _author = new Author()
            {
                FullName = book.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()

            }).FirstOrDefault();

            return _author;
            
        }
    }
}