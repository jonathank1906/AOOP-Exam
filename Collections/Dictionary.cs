var fruitPrices = new Dictionary<string, decimal>(); // New dictionary with string keys and decimal values

var printPrices = () => { 
    foreach (var kvp in fruitPrices) 
        Console.WriteLine($"{kvp.Key}: ${kvp.Value}"); 
};

// Adding items
fruitPrices.Add("melon", 3.99m);
fruitPrices.Add("avocado", 2.49m);
fruitPrices["banana"] = 0.59m; // Alternative way to add/update
fruitPrices["plum"] = 1.29m;
printPrices();

// Updating values
fruitPrices["melon"] = 4.25m; // Update existing
fruitPrices["peach"] = 1.99m; // Adds new if doesn't exist
printPrices();

// Removing items
fruitPrices.Remove("melon"); // Remove by key
printPrices();

// Remove all fruits priced under $1.00
fruitPrices = fruitPrices.Where(kvp => kvp.Value >= 1.00m)
                         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
printPrices();

// Accessing values
if (fruitPrices.TryGetValue("avocado", out decimal avocadoPrice))
{
    Console.WriteLine($"Avocado price: {avocadoPrice}");
}

// Keys and values collections
foreach (string fruit in fruitPrices.Keys) Console.WriteLine(fruit);
foreach (decimal price in fruitPrices.Values) Console.WriteLine(price);

// Conversion
Dictionary<string, string> priceDescriptions = fruitPrices.ToDictionary(
    kvp => kvp.Key,
    kvp => $"The price of {kvp.Key} is ${kvp.Value}"
);
foreach (var desc in priceDescriptions) Console.WriteLine(desc.Value);