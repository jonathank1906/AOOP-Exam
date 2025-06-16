using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<GameCharacter> characters = new()
        {
            new GameCharacter { Id = 1, Name = "Kratos", Game = "God of War", Class = "Warrior",
                Level = 50, Health = 1200, IsPlayable = true,
                Abilities = new() { "Blade of Chaos", "Spartan Rage", "Leviathan Axe" } },
            new GameCharacter { Id = 2, Name = "Aloy", Game = "Horizon Zero Dawn", Class = "Hunter",
                Level = 45, Health = 950, IsPlayable = true,
                Abilities = new() { "Focus Scan", "Bow Mastery", "Tripcaster" } },
            new GameCharacter { Id = 3, Name = "Ganondorf", Game = "Zelda", Class = "Warlock",
                Level = 99, Health = 5000, IsPlayable = false,
                Abilities = new() { "Dark Magic", "Sword of Demise", "Telekinesis" } },
            new GameCharacter { Id = 4, Name = "Ellie", Game = "The Last of Us", Class = "Survivor",
                Level = 30, Health = 600, IsPlayable = true,
                Abilities = new() { "Stealth", "Crafting", "Knife Combat" } },
            new GameCharacter { Id = 5, Name = "Mario", Game = "Super Mario", Class = "Plumber",
                Level = 60, Health = 800, IsPlayable = true,
                Abilities = new() { "Jump", "Fireball", "Super Strength" } }
        };

        // 1. Basic Filtering: Get all playable characters
        var playablecharacters = characters.Where(chars => chars.IsPlayable == true);
        Console.WriteLine("1. Playable Characters:");
        foreach (var playable in playablecharacters)
        {
            Console.WriteLine(playable.Name);
        }

        // 2. Sorting: Get characters sorted by Level (highest first)
        var sortedCharacterLevel = characters.OrderByDescending(chars => chars.Level);
        Console.WriteLine("2. Character levels sorted by highest first:");
        foreach (var playable in sortedCharacterLevel)
        {
            Console.WriteLine(playable.Name);
        }

        // 3. Projection: Get just character names and their game
        var namesandgames = characters.Select(chars => (chars.Name, chars.Game));
        Console.WriteLine("3. Character name and their game:");
        foreach (var character in namesandgames)
        {
            Console.WriteLine(character.Name + " - " + character.Game);
        }

        // 4. Aggregation: Find the average health of all characters
        decimal averageHealth = (decimal)characters.Average(chars => chars.Health);
        Console.WriteLine($"4. Average health of all characters: {averageHealth}");

        // 5. Conditional: Find characters with health > 1000
        var healthAbove1000 = characters.Where(chars => chars.Health > 1000);
        Console.WriteLine("5. Characters with health > 1000:");
        foreach (var character in healthAbove1000)
        {
            Console.WriteLine(character.Name);
        }

        // 6. Collection Search: Find characters who have "Bow" in any ability
        var bowAbility = characters.Where(chars => chars.Abilities.Any(ability => ability.Contains("Bow")));
        Console.WriteLine("6. Characters who have Bow in any ability:");
        foreach (var character in bowAbility)
        {
            Console.WriteLine(character.Name);
        }

        // 7. Grouping: Group characters by their game
        var groubedByGame = characters.GroupBy(chars => chars.Game);
        Console.WriteLine("7. Group characters by their game:");
        foreach (var group in groubedByGame)
        {
            Console.WriteLine(group.Key);
            foreach (var chars in group)
            {
                Console.WriteLine($"{chars.Name} - {chars.Game}");
            }
        }

        // 8. Combination: Get playable characters from "God of War" or "Zelda"
        var playableCharactersFrom = characters.Where(chars => chars.IsPlayable == true && (chars.Game == "God of War" || chars.Game == "Zelda")); // The () around the or statements is very important!
        Console.WriteLine("8. Get playable characters from God of War or Zelda");
        foreach (var character in playableCharactersFrom)
        {
            Console.WriteLine(character.Name);
        }

        // 9. Advanced: Get the highest level character name and level
        var topLevel = characters.OrderByDescending(c => c.Level)
                        .Select(c => new { c.Name, c.Level })
                        .First();
        Console.WriteLine($"9. Highest level character: {topLevel.Name} (Level {topLevel.Level})");

        // 10. Count: How many characters have "Stealth" as an ability?
        Console.WriteLine($"10. Characters with Stealth ability: {characters.Count(c => c.Abilities.Contains("Stealth"))}");
    }
}

public class GameCharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Game { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Health { get; set; }
    public List<string> Abilities { get; set; } = new List<string>();
    public bool IsPlayable { get; set; }
}

/*
1. Basic Filtering: Get all playable characters
2. Sorting: Get characters sorted by Level (highest first)
3. Projection: Get just character names and their games
4. Aggregation: Find the average health of all characters
5. Conditional: Find characters with health > 1000
6. Collection Search: Find characters who have "Bow" in any ability
7. Grouping: Group characters by their game
8. Combination: Get playable characters from "God of War" or "Zelda"
9. Advanced: Get the highest level character name and level
10. Count: How many characters have "Stealth" as an ability?
*/