using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActorsMovies.Data;
using ActorsMovies.Models;

namespace ActorsMovies.Pages.ActorsInMovies
{
    public class EditModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public EditModel(ActorsMovies.Data.ActorsMoviesContext context)
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
           ViewData["ActorId"] = new SelectList(_context.Actors, "ID", "ID");
           ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
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

            _context.Attach(ActorsInMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorsInMovieExists(ActorsInMovie.Id))
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

        private bool ActorsInMovieExists(int id)
        {
            return _context.ActorsInMovies.Any(e => e.Id == id);
        }
    }
}
