using System;
using System.Collections.Generic;

class Program
{
    static List<Product> products = new List<Product>()
    {
        new Product(1, "Milk", 20),
        new Product(2, "Bread", 25),
        new Product(3, "Butter", 50),
        new Product(4, "Sugar", 40)
    };

    static List<Product> cart = new List<Product>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== SUPERMARKET BILLING SYSTEM =====");
            Console.WriteLine("1. Show Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
            Console.Write("Choose Option: ");
            
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: ShowProducts(); break;
                case 2: AddToCart(); break;
                case 3: ViewCart(); break;
                case 4: Checkout(); break;
                case 5: return;
                default: Console.WriteLine("Invalid Choice!"); break;
            }
        }
    }

    static void ShowProducts()
    {
        Console.WriteLine("\n--- Available Products ---");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}. {p.Name} - Rs {p.Price}");
        }
    }

    static void AddToCart()
    {
        Console.Write("\nEnter Product ID: ");
        int id = int.Parse(Console.ReadLine());

        Product selected = products.Find(p => p.Id == id);

        if (selected != null)
        {
            cart.Add(selected);
            Console.WriteLine($"{selected.Name} added to cart!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static void ViewCart()
    {
        Console.WriteLine("\n--- Your Cart ---");
        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Name} - Rs {item.Price}");
        }
    }

    static void Checkout()
    {
        Console.WriteLine("\n--- BILLING ---");
        int total = 0;

        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Name} - Rs {item.Price}");
            total += item.Price;
        }

        Console.WriteLine($"\nTOTAL AMOUNT = Rs {total}");
        Console.WriteLine("Thank you for shopping!");
        cart.Clear();
    }
}

class Product
{
    public int Id;
    public string Name;
    public int Price;

    public Product(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}
