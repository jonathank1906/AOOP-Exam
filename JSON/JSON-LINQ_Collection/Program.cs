using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public List<string> Skills { get; set; } = new List<string>();
    public bool IsFullTime { get; set; }
}

class Program
{
    static void Main()
    {
        string filePath = "employees.json";
        
        try
        {
            // 1. Read and parse JSON
            string jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(jsonString, options)
                ?? throw new Exception("No employee data found");

            // 2. Basic statistics LINQ
            Console.WriteLine($"Total Employees: {employees.Count}");
            Console.WriteLine($"Full-time: {employees.Count(e => e.IsFullTime)}");
            Console.WriteLine($"Part-time: {employees.Count(e => !e.IsFullTime)}");

            // 3. Salary analysis LINQ
            Console.WriteLine($"\nSalary Overview:");
            Console.WriteLine($"- Highest: ${employees.Max(e => e.Salary):N0}");
            Console.WriteLine($"- Average: ${employees.Average(e => e.Salary):N0}");
            Console.WriteLine($"- Lowest: ${employees.Min(e => e.Salary):N0}");

            // 4. Group by position
            Console.WriteLine("\nPositions:");
            foreach (var group in employees.GroupBy(e => e.Position))
            {
                Console.WriteLine($"- {group.Key}: {group.Count()} employees");
            }

            // 5. Skill frequency LINQ
            Console.WriteLine("\nMost Common Skills:");
            var allSkills = employees.SelectMany(e => e.Skills);
            foreach (var skill in allSkills
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(3))
            {
                Console.WriteLine($"- {skill.Key}: {skill.Count()} people");
            }

            // 6. Find specific employees LINQ
            Console.WriteLine("\nDevelopers with Python Skills:");
            var pythonDevs = employees
                .Where(e => e.Skills.Contains("Python"))
                .Select(e => $"{e.Name} ({e.Position})");
            
            foreach (var dev in pythonDevs)
            {
                Console.WriteLine($"- {dev}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}