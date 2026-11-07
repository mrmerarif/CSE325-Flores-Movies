
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>());

        // Do not add duplicate movies if records already exist.
        if (context.Movie.Any())
        {
            return;
        }

        // Add our three favorite movies to a new database.
        context.Movie.AddRange(
            new Movie
            {
                Title = "Coco",
                ReleaseDate = new DateTime(2017, 11, 22),
                Genre = "Animation",
                Price = 9.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "Apollo 13",
                ReleaseDate = new DateTime(1995, 6, 30),
                Genre = "Docudrama / Historical Drama",
                Price = 12.99M,
                Rating = "PG"
            },
            new Movie
            {
                Title = "The Lion King",
                ReleaseDate = new DateTime(1994, 6, 24),
                Genre = "Animation",
                Price = 12.99M,
                Rating = "G"
            }
        );

        context.SaveChanges();
    }
}
