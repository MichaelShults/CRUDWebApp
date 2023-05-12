using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDWebApp.Data;
using CRUDWebApp.Models;
using Microsoft.Identity.Client;

namespace CRUDWebApp.Pages.Models.Books
{
    public class EditModel : PageModel
    {
        public SelectList AuthorList { get; set; } = default!;
        private readonly CRUDWebApp.Data.CRUDWebAppContext _context;

        public EditModel(CRUDWebApp.Data.CRUDWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            AuthorList = new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.LastName));
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book =  await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
   
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int authorId = Book.AuthorId;
            Author author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            Book.Author = author;
            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
