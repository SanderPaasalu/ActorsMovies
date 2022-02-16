#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActorsMovies.Models;

namespace ActorsMovies.Data
{
    public class ActorsMoviesContext : DbContext
    {
        public ActorsMoviesContext (DbContextOptions<ActorsMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorsInMovie> ActorsInMovies { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().ToTable("Actors");
            modelBuilder.Entity<ActorsInMovie>().ToTable("ActorsInMovies");
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }
    }
}
