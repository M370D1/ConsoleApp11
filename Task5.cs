using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Event
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
}

public class EventDateConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "yyyy-MM-dd";

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString(DateFormat));
    }

    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        string dateString = reader.Value.ToString();
        return DateTime.ParseExact(dateString, DateFormat, null);
    }
}

public class Task5
{
    public static void Execute()
    {
        var events = new List<Event>
        {
            new Event { Date = new DateTime(2025, 1, 15), Name = "Conference" },
            new Event { Date = new DateTime(2025, 2, 20), Name = "Workshop" },
            new Event { Date = new DateTime(2025, 3, 10), Name = "Seminar" }
        };

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new EventDateConverter() },
            Formatting = Formatting.Indented
        };

        string json = JsonConvert.SerializeObject(events, settings);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        var deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(json, settings);

        Console.WriteLine("\nDeserialized Events:");
        foreach (var e in deserializedEvents)
        {
            Console.WriteLine($"Name: {e.Name}, Date: {e.Date:yyyy-MM-dd}");
        }
    }
}
