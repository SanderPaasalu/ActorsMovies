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
    public class IndexModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public IndexModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

        public IList<ActorsInMovie> ActorsInMovie { get;set; }

        public async Task OnGetAsync()
        {
            ActorsInMovie = await _context.ActorsInMovies
                .Include(a => a.Actors)
                .Include(a => a.Movie).ToListAsync();
        }
    }
}
