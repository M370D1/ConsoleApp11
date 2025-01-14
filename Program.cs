class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelect a task to run:");
            Console.WriteLine("1. Task 1: Parse and Extract Data");
            Console.WriteLine("2. Task 2: Complex Object Serialization and Deserialization");
            Console.WriteLine("3. Task 3: Dynamic JSON Handling");
            Console.WriteLine("4. Task 4: Complex JPath Filtering");
            Console.WriteLine("5. Task 5: Advanced Serialization with Custom Converters");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Executing Task 1...");
                    Task1.Execute();
                    break;

                case "2":
                    Console.WriteLine("Executing Task 2...");
                    Task2.Execute();
                    break;

                case "3":
                    Console.WriteLine("Executing Task 3...");
                    Task3.Execute();
                    break;

                case "4":
                    Console.WriteLine("Executing Task 4...");
                    Task4.Execute();
                    break;

                case "5":
                    Console.WriteLine("Executing Task 5...");
                    Task5.Execute();
                    break;

                case "0":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
