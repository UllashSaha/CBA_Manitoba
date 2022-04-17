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