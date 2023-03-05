using cgi_tollgate_assignment_book_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.DAL
{
    public class BookDataContext : DbContext
    {
        public BookDataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Define Books entity of type DbSet<Book>
        
    }
}
