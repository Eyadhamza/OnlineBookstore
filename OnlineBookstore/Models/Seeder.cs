using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace OnlineBookstore.Models
{
    public class Seeder
    {

        public static void Run(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            Seed(context);
        }

        private static void Seed(AppDbContext context)
        {
            if (context.Books.IsNullOrEmpty())
            {
                for (int i = 0; i < 10; i++)
                {
                    Book book = new Book
                    {
                        Title = $"Book {i}",
                        Description = $"Description {i}",
                        PublishedOn = new DateTime(2020, 1, 1),
                    };
                    book.Authors = new Author[]
                    {
                        new Author
                        {
                            Name = $"Author {i}",
                            Bio = $"Bio {i}",
                        },
                        new Author
                        {
                            Name = $"Author {i + 1}",
                            Bio = $"Bio {i}",
                        }
                    };
                    book.Categories = new Category[]
                    {
                        new Category
                        {
                            Title = $"Title {i}",
                            Description = $"Description {i}"
                        },
                    };
                    context.Books.Add(book);
                }
                context.SaveChanges();
            }
        }
    }
}
