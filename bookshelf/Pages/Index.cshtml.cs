using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookshelf.Data;
using bookshelf.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookshelf.Pages;

public class IndexModel : PageModel
{
     private readonly bookshelf.Data.bookshelfContext _context;

        public IndexModel(bookshelf.Data.bookshelfContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
}
