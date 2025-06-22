using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"{ProductId}: {ProductName} ({Category})";
    }
}

class SearchDemo
{
    static void Main()
    {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Shirt", "Apparel"),
            new Product(309, "Phone", "Electronics"),
            new Product(410, "Shoes", "Footwear"),
            new Product(512, "Book", "Stationery")
        };

        Console.WriteLine("Linear Search Result:");
        Product foundLinear = LinearSearch(products, "Phone");
        Console.WriteLine(foundLinear != null ? foundLinear.ToString() : "Product not found.");

        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));
        Console.WriteLine("\nBinary Search Result:");
        Product foundBinary = BinarySearch(products, "Phone");
        Console.WriteLine(foundBinary != null ? foundBinary.ToString() : "Product not found.");
    }

    static Product LinearSearch(Product[] products, string name)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    static Product BinarySearch(Product[] sortedProducts, string name)
    {
        int low = 0;
        int high = sortedProducts.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(name, sortedProducts[mid].ProductName, true);

            if (comparison == 0)
                return sortedProducts[mid];
            else if (comparison < 0)
                high = mid - 1;
            else
                low = mid + 1;
        }

        return null;
    }
}
