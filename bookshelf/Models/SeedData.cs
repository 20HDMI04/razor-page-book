using Microsoft.EntityFrameworkCore;
using bookshelf.Data;
using bookshelf.Pages.Books;

namespace bookshelf.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new bookshelfContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<bookshelfContext>>()))
        {
            if (context == null || context.Book == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "And Then There Were None",
                    ReleaseDate = DateTime.Parse("1939-9-6"),
                    Genre = "Mistery Thriller"
                },

                new Book
                {
                    Title = "The Lord of the Rings",
                    ReleaseDate = DateTime.Parse("1954-6-29"),
                    Genre = "Adventure"
                },

                new Book
                {
                    Title = "The Great Gatsby",
                    ReleaseDate = DateTime.Parse("1925-4-10"),
                    Genre = "Tragedy"
                },

                new Book
                {
                    Title = "To Kill a Mockingbird",
                    ReleaseDate = DateTime.Parse("1960-7-11"),
                    Genre = "Southern Gothic"
                },
                new Book
                {
                    Title = "1984",
                    ReleaseDate = DateTime.Parse("1949-6-8"),
                    Genre = "Dystopian"
                }

            );
            context.SaveChanges();
        }
    }
}