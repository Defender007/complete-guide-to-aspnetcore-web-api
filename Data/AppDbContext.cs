using System;
using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books {get; set;}
    }
}
