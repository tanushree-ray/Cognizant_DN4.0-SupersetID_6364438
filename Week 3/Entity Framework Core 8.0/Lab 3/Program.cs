using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        if (!context.Categories.Any())
        {
            var electronics = new Category { Name = "Electronics" };
            var books = new Category { Name = "Books" };

            context.Categories.AddRange(electronics, books);

            context.Products.AddRange(
                new Product { Name = "Laptop", Price = 55000, Category = electronics },
                new Product { Name = "Smartphone", Price = 20000, Category = electronics },
                new Product { Name = "C# Programming Book", Price = 750, Category = books }
            );

            context.SaveChanges();
            Console.WriteLine("Sample data added to the database.");
        }

        var products = context.Products.Include(p => p.Category).ToList();

        Console.WriteLine("Product Inventory:");
        foreach (var p in products)
        {
            Console.WriteLine($"- {p.Name} (₹{p.Price}) | Category: {p.Category.Name}");
        }
    }
}
