using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcBook.Data;
using MvcBook.Models;
using System;
using System.Linq;

namespace MvcBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcBookContext>>()))
            {
                // Look for any books.
                if (context.Book.Any())
                {
                    // DB has been seeded
                }
                else
                {

                    context.Book.AddRange(
                        new Book
                        {
                            Title = "Harry Potter and the Chamber of Secrets",
                            Author = "J.K. Rowling",
                            PublishDate = DateTime.Parse("1998-2-07"),
                            Genre = "Fantasy literature",
                            Rating = "4.3",
                            Price = 7.99M
                        },

                        new Book
                        {
                            Title = "The Lost Symbol",
                            Author = "Dan Brown",
                            PublishDate = DateTime.Parse("1984-3-13"),
                            Genre = "Thriller",
                            Rating = "3.7",
                            Price = 8.99M
                        },

                        new Book
                        {
                            Title = "The Lord of the Rings",
                            Author = "J. R. R. Tolkien",
                            PublishDate = DateTime.Parse("2009-9-15"),
                            Genre = "Adventure fiction",
                            Rating = "4.4",
                            Price = 9.99M
                        },

                        new Book
                        {
                            Title = "Romeo and Juliet",
                            Author = "William Shakespeare",
                            PublishDate = DateTime.Parse("1597-01-01"),
                            Genre = "Play",
                            Rating = "4.5",
                            Price = 3.97M
                        }
                    );
                }

                if (context.Role.Any())
                {
                    // DB has been seeded
                }
                else
                {
                    context.Role.AddRange(
                        new Role

                        {
                            Id = "6",
                            Name = "User"

                        }
                       );

                }


                context.SaveChanges();
            }
        }
    }
}