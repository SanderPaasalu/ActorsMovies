using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActorsMovies.Data;
using ActorsMovies.Models;

namespace ActorsMovies.Pages.ActorsInMovies
{
    public class DeleteModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public DeleteModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActorsInMovie ActorsInMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActorsInMovie = await _context.ActorsInMovies
                .Include(a => a.Actors)
                .Include(a => a.Movie).FirstOrDefaultAsync(m => m.Id == id);

            if (ActorsInMovie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActorsInMovie = await _context.ActorsInMovies.FindAsync(id);

            if (ActorsInMovie != null)
            {
                _context.ActorsInMovies.Remove(ActorsInMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
