using System;
using System.Linq;
using my_books.Data.Models;
using my_books.Data.ViewModel;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDBContext _context;
        public PublishersService(AppDBContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var  _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }
    }
}
