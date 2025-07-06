using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        Console.WriteLine("All Products:");
        var allProducts = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        foreach (var p in allProducts)
            Console.WriteLine($"- {p.Name} (₹{p.Price}) | Category: {p.Category.Name}");

        Console.WriteLine("\n Products in 'Groceries' Category:");
        var groceriesProducts = await context.Products
            .Include(p => p.Category)
            .Where(p => p.Category.Name == "Groceries")
            .ToListAsync();

        foreach (var p in groceriesProducts)
            Console.WriteLine($"- {p.Name} (₹{p.Price})");

        Console.WriteLine("\n Products Sorted by Price (Descending):");
        var sortedProducts = await context.Products
            .Include(p => p.Category)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        foreach (var p in sortedProducts)
            Console.WriteLine($"- {p.Name} (₹{p.Price}) | Category: {p.Category.Name}");
    }
}
