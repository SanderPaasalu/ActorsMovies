using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActorsMovies.Data;
using ActorsMovies.Models;

namespace ActorsMovies.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public DetailsModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors
                .Include(s => s.ActorsInMovies)
                .ThenInclude(e => e.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
