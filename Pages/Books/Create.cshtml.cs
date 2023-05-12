using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRUDWebApp.Data;
using CRUDWebApp.Models;

namespace CRUDWebApp.Pages.Models.Books
{
    public class CreateModel : PageModel
    {
        private readonly CRUDWebApp.Data.CRUDWebAppContext _context;
        public SelectList AuthorList { get; set; } = default!;
        public CreateModel(CRUDWebApp.Data.CRUDWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            AuthorList = new SelectList(_context.Authors, nameof(Author.AuthorId), nameof(Author.LastName));
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            }
            int authorId = Book.AuthorId;
            Author author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            Book.Author = author;
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
