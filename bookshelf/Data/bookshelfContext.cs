using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookshelf.Models;

namespace bookshelf.Data
{
    public class bookshelfContext : DbContext
    {
        public bookshelfContext (DbContextOptions<bookshelfContext> options)
            : base(options)
        {
        }

        public DbSet<bookshelf.Models.Book> Book { get; set; } = default!;
    }
}
