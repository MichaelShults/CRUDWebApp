using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDWebApp.Data;
using CRUDWebApp.Models;

namespace CRUDWebApp.Pages.Models.Books
{
    public class IndexModel : PageModel
    {
        private readonly CRUDWebApp.Data.CRUDWebAppContext _context;

        public IndexModel(CRUDWebApp.Data.CRUDWebAppContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books
                .Include(b => b.Author).ToListAsync();
            }
        }
    }
}
