using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Task1
{
    public static void Execute()
    {
        string json = @"
        {
            ""departments"": [
                {
                    ""name"": ""Engineering"",
                    ""employees"": [
                        { ""name"": ""Alice"", ""age"": 30, ""skills"": [""C#"", ""SQL""] },
                        { ""name"": ""Bob"", ""age"": 35, ""skills"": [""Java"", ""AWS""] }
                    ]
                },
                {
                    ""name"": ""HR"",
                    ""employees"": [
                        { ""name"": ""Charlie"", ""age"": 28, ""skills"": [""Recruitment"", ""Communication""] },
                        { ""name"": ""Diana"", ""age"": 32, ""skills"": [""Onboarding"", ""Training""] }
                    ]
                }
            ]
        }";

        JObject parsedJson = JObject.Parse(json);

        var engineeringEmployees = parsedJson
            .SelectTokens("$.departments[?(@.name == 'Engineering')].employees[*].name")
            .Select(e => e.ToString())
            .ToList();

        Console.WriteLine("Employees in Engineering:");
        engineeringEmployees.ForEach(Console.WriteLine);

        var allSkills = parsedJson
            .SelectTokens("$.departments[*].employees[*].skills[*]")
            .Select(skill => skill.ToString())
            .Distinct()
            .ToList();

        Console.WriteLine("Unique skills across all employees:");
        allSkills.ForEach(Console.WriteLine);

        var employeesOlderThan30 = parsedJson
            .SelectTokens("$.departments[*]")
            .SelectMany(dept => dept["employees"]
            .Where(emp => (int)emp["age"] > 30)
            .Select(emp => new
                {
                    Department = dept["name"].ToString(),
                    EmployeeName = emp["name"].ToString()
                })).ToList();

        Console.WriteLine("Employees older than 30:");
        foreach (var employee in employeesOlderThan30)
        {
            Console.WriteLine($"Department: {employee.Department}, Name: {employee.EmployeeName}");
        }
    }
}
