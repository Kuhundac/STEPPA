/*/*Console.WriteLine("Hello, World!");
string name = "Ankle Sock", color = "red";
char size= 'M';
double price = 20;
int stockQuantity = 40;







//int menu=0;

Console.WriteLine("Menu");
Console.WriteLine("Type 1 for name 2. for color 3. for size 4. for price 5. for stock");
string input = Console.ReadLine();
int menu;
bool success = int.TryParse(input, out menu);


if (!success)
{
    Console.WriteLine("Please enter a valid number.");
}
else if (menu == 1)
{
    Console.WriteLine(name);
}
else if (menu == 2)
{
    Console.WriteLine(color);
}
else if (menu == 3)
{
    Console.WriteLine(size);
}
else if (menu == 4)
{
    Console.WriteLine(price);
}
else if (menu == 5)
{
    Console.WriteLine(stockQuantity);
}
else
{
    Console.WriteLine("invalid input");
} */

/*List<string> names = new List<string>();
List<string> colors = new List<string>();
List<double> prices = new List<double>();
List<int> stockQuantities = new List<int>();

AddProduct("Ankle sock", "Red", 25, 2);
AddProduct("Long sock", "White", 20, 1);
AddProduct("Colorful", "yellow", 30, 1);

ViewAllProducts();

void AddProduct(string name, string color, double price, int stock)
{
    names.Add(name);
    colors.Add(color);
    prices.Add(price);
    stockQuantities.Add(stock);
}

/*names.Add("Long sock");
colors.Add("White");
prices.Add(25);
stockQuantities.Add(1);*/

/*Console.WriteLine(names[0]);
Console.WriteLine(colors[0]);
Console.WriteLine(prices[0]);
Console.WriteLine(stockQuantities[0]);

Console.WriteLine(names[1]);
Console.WriteLine(colors[1]);
Console.WriteLine(prices[1]);
Console.WriteLine(stockQuantities[1]);*/

/*void ViewAllProducts()
{
    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine(names[i]);
        Console.WriteLine(colors[i]);
        Console.WriteLine(prices[i]);
        Console.WriteLine(stockQuantities[i]);
        Console.WriteLine("---");
    }
}
*/



//using System;

//class Product
//{
//    // 1. Four properties
//    public string Name { get; set; }
//    public string Color { get; set; }
//    public double Price { get; set; }
//    public int StockQuantity { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        // 2. Create one Product object
//        Product p1 = new Product();

//        // Set properties one at a time
//        p1.Name = "Ankle Sock";
//        p1.Color = "Red";
//        p1.Price = 25;
//        p1.StockQuantity = 2;

//        // 3. Print the product name
//        Console.WriteLine(p1.Name);
//    }
//}

using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public Product(string name, string color, double price, int stockQuantity)
    {
        Name = name;
        Color = color;
        Price = price;
        StockQuantity = stockQuantity;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        products.Add(new Product("Ankle Sock", "Red", 25, 2));
        products.Add(new Product("Long Sock", "White", 20, 1));
        products.Add(new Product("Colorful Sock", "Yellow", 30, 1));

        foreach (Product p in products)
        {
            Console.WriteLine("Name: " + p.Name);
            Console.WriteLine("Color: " + p.Color);
            Console.WriteLine("Price: " + p.Price);
            Console.WriteLine("Stock: " + p.StockQuantity);
            Console.WriteLine("----------------");
        }
    }
}