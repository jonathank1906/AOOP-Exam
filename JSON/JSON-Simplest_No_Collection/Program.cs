using System;
using System.IO;
using System.Text.Json;

public class Person
{
    // Initialize lists to avoid null references
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsEmployed { get; set; }
    public List<string> Hobbies { get; set; } = new List<string>();
}

class Program
{
    static void Main()
    {
        string filePath = "person.json";
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File not found at {Path.GetFullPath(filePath)}");
            Console.WriteLine("Make sure the file exists in your executable directory.");
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(filePath);
            
            // Add JsonSerializerOptions to handle missing fields
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip
            };
            
            Person person = JsonSerializer.Deserialize<Person>(jsonString, options) 
                ?? throw new Exception("Deserialization returned null");
            
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Employed: {person.IsEmployed}");
            
            if (person.Hobbies != null && person.Hobbies.Count > 0)
            {
                Console.WriteLine("Hobbies:");
                foreach (var hobby in person.Hobbies)
                {
                    Console.WriteLine($"- {hobby}");
                }
            }
            else
            {
                Console.WriteLine("No hobbies listed");
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Error: {ex.Message}");
            Console.WriteLine("Make sure your JSON is properly formatted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}