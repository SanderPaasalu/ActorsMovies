using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActorsMovies.Data;
using ActorsMovies.Models;

namespace ActorsMovies.Pages.ActorsInMovies
{
    public class CreateModel : PageModel
    {
        private readonly ActorsMovies.Data.ActorsMoviesContext _context;

        public CreateModel(ActorsMovies.Data.ActorsMoviesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ActorId"] = new SelectList(_context.Actors, "ID", "ID");
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ActorsInMovie ActorsInMovie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActorsInMovies.Add(ActorsInMovie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
