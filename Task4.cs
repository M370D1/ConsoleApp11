using System;
using System.Linq;
using Newtonsoft.Json.Linq;

public class Task4
{
    public static void Execute()
    {
        string json = @"
        {
            ""orders"": [
                {
                    ""orderId"": 1,
                    ""customer"": ""John Doe"",
                    ""items"": [
                        { ""product"": ""Laptop"", ""price"": 1200 },
                        { ""product"": ""Mouse"", ""price"": 25 }
                    ]
                },
                {
                    ""orderId"": 2,
                    ""customer"": ""Jane Smith"",
                    ""items"": [
                        { ""product"": ""Phone"", ""price"": 800 },
                        { ""product"": ""Headphones"", ""price"": 100 }
                    ]
                }
            ]
        }";

        JObject parsedJson = JObject.Parse(json);

        Console.WriteLine("All Customers' Names:");
        var customerNames = parsedJson.SelectTokens("$.orders[*].customer").Select(name => name.ToString());
        foreach (var name in customerNames)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nProducts with Price Greater Than 100:");
        var expensiveProducts = parsedJson.SelectTokens("$.orders[*].items[?(@.price > 100)]");
        foreach (var product in expensiveProducts)
        {
            Console.WriteLine($"Product: {product["product"]}, Price: {product["price"]}");
        }

        Console.WriteLine("\nTotal Price of Items in the First Order:");
        var firstOrderTotal = parsedJson
            .SelectTokens("$.orders[0].items[*].price")
            .Sum(price => (decimal)price);
        Console.WriteLine($"Total Price: {firstOrderTotal}");
    }
}
