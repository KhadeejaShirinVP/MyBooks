using BooksWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
    }
}
