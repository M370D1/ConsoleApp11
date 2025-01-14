using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

public class Company
{
    public string Name { get; set; }
    public Address Location { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Company Employer { get; set; }
    public List<string> Skills { get; set; }
}


public class Task2
{
    public static void Execute()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Employer = new Company
                {
                    Name = "TechCorp",
                    Location = new Address { Street = "123 Main St", City = "New York" }
                },
                Skills = new List<string> { "C#", "SQL", "Azure" }
            },
            new Employee
            {
                Id = 2,
                Name = "Bob",
                Employer = new Company
                {
                    Name = "Innovatech",
                    Location = new Address { Street = "456 Elm St", City = "San Francisco" }
                },
                Skills = new List<string> { "Java", "AWS", "Docker" }
            },
            new Employee
            {
                Id = 3,
                Name = "Charlie",
                Employer = new Company
                {
                    Name = "CodeWorks",
                    Location = new Address { Street = "789 Oak St", City = "New York" }
                },
                Skills = new List<string> { "Python", "Django", "Machine Learning" }
            }
        };

        string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        List<Employee> deserializedEmployees = JsonConvert.DeserializeObject<List<Employee>>(json);

        Console.WriteLine("\nDeserialized Employee Details:");
        foreach (var employee in deserializedEmployees)
        {
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Company: {employee.Employer.Name}");
            Console.WriteLine($"Address: {employee.Employer.Location.Street}, {employee.Employer.Location.City}");
            Console.WriteLine($"Skills: {string.Join(", ", employee.Skills)}");
        }

        Console.WriteLine("\nEmployees in New York:");
        var employeesInNewYork = deserializedEmployees
            .Where(e => e.Employer.Location.City == "New York")
            .Select(e => e.Name)
            .ToList();

        employeesInNewYork.ForEach(Console.WriteLine);
    }
}
