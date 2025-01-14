using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Task3
{
    public static void Execute()
    {
        string json = @"
        {
            ""store"": {
                ""products"": [
                    { ""id"": 1, ""name"": ""Laptop"", ""price"": 1200, ""category"": ""Electronics"", ""stock"": 10 },
                    { ""id"": 2, ""name"": ""Tablet"", ""price"": 800, ""category"": ""Electronics"", ""stock"": 0 },
                    { ""id"": 3, ""name"": ""Notebook"", ""price"": 15, ""category"": ""Stationery"", ""stock"": 50 },
                    { ""id"": 4, ""name"": ""Pen"", ""price"": 2, ""category"": ""Stationery"", ""stock"": 100 }
                ],
                ""lastUpdated"": ""2025-01-01T10:00:00Z""
            }
        }";

        JObject parsedJson = JObject.Parse(json);

        var newProduct = new JObject
        {
            ["id"] = 5,
            ["name"] = "Headphones",
            ["price"] = 150,
            ["category"] = "Electronics",
            ["stock"] = 25
        };
        parsedJson["store"]["products"].Last.AddAfterSelf(newProduct);

        foreach (var product in parsedJson["store"]["products"])
        {
            if ((string)product["category"] == "Electronics" && (int)product["stock"] == 0)
            {
                product["stock"] = 50;
            }
        }

        int totalStock = parsedJson["store"]["products"]
            .Sum(product => (int)product["stock"]);
        parsedJson["store"]["totalStock"] = totalStock;

        var products = parsedJson["store"]["products"] as JArray;
        var filteredProducts = new JArray(products.Where(product => (int)product["price"] >= 10));
        parsedJson["store"]["products"] = filteredProducts;

        string modifiedJson = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        Console.WriteLine("Modified JSON:");
        Console.WriteLine(modifiedJson);

        Console.WriteLine("\nStationery Products (Name and Price):");
        var stationeryProducts = parsedJson["store"]["products"]
            .Where(product => (string)product["category"] == "Stationery")
            .Select(product => new KeyValuePair<string, decimal>(
                (string)product["name"],
                (decimal)product["price"]
            )).ToList();

        foreach (var product in stationeryProducts)
        {
            Console.WriteLine($"Name: {product.Key}, Price: {product.Value}");
        }
    }
}
