using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new RetailContext();

        var electronics = new Category { Name = "Electronics" };
        context.Categories.Add(electronics);
        context.SaveChanges();

        var product = new Product
        {
            Name = "Smartphone",
            Quantity = 10,
            CategoryId = electronics.CategoryId
        };
        context.Products.Add(product);
        context.SaveChanges();

        var products = context.Products.ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"Product: {p.Name}, Quantity: {p.Quantity}");
        }
    }
}
