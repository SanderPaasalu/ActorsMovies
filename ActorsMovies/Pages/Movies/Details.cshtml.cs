using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActorsMovies.Data;
using ActorsMovies.Models;

namespace ActorsMovies.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public DetailsModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies
                .Include(s => s.ActorsInMovies)
                .ThenInclude(e => e.Actors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
