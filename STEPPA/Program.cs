using Microsoft.Data.Sqlite;
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

        using var connection = new SqliteConnection("Data Source=steppa.db");
        connection.Open();

        var createTableCmd = connection.CreateCommand();
        createTableCmd.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS Products (
            ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT,
            Color TEXT,
            Price REAL,
            StockQuantity INTEGER
        );
        ";
        createTableCmd.ExecuteNonQuery();

        Console.WriteLine("Table created!");

        var countCmd = connection.CreateCommand();
        countCmd.CommandText = "SELECT COUNT(*) FROM Products;";
        long count = (long)countCmd.ExecuteScalar();

        if (count == 0)
        {
            var insertCmd1 = connection.CreateCommand();
            insertCmd1.CommandText = "INSERT INTO Products (Name, Color, Price, StockQuantity) VALUES ('Ankle Sock', 'Red', 25, 2);";
            insertCmd1.ExecuteNonQuery();

            var insertCmd2 = connection.CreateCommand();
            insertCmd2.CommandText = "INSERT INTO Products (Name, Color, Price, StockQuantity) VALUES ('Long Sock', 'White', 20, 1);";
            insertCmd2.ExecuteNonQuery();

            var insertCmd3 = connection.CreateCommand();
            insertCmd3.CommandText = "INSERT INTO Products (Name, Color, Price, StockQuantity) VALUES ('Colorful Sock', 'Yellow', 30, 1);";
            insertCmd3.ExecuteNonQuery();
        }

        var selectCmd = connection.CreateCommand();
        selectCmd.CommandText = "SELECT * FROM Products;";

        using var reader = selectCmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"] + " - " + reader["Color"] + " - " + reader["Price"] + " - " + reader["StockQuantity"]);
        }
    }
}