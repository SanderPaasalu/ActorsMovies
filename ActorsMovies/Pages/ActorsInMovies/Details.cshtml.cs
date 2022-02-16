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
    public class DetailsModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public DetailsModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

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
    }
}
