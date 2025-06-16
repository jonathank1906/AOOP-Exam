var fruitInventory = new Dictionary<string, int>(); // Key: fruit name, Value: quantity

// Helper method to print dictionary contents
void PrintInventory()
{
    Console.WriteLine("\nCurrent Inventory:");
    foreach (var item in fruitInventory)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
    Console.WriteLine(); // Blank line for spacing
}

// Adding items
fruitInventory.Add("apple", 10);
fruitInventory.Add("orange", 5);
fruitInventory["banana"] = 7; // Alternative way to add/update
PrintInventory();

// Updating quantities
fruitInventory["apple"] += 2; // Increase apple count
fruitInventory["orange"] = 8; // Set new value
fruitInventory["pear"] = 3;   // Adds new item
PrintInventory();

// Safe removal
if (fruitInventory.ContainsKey("banana"))
{
    fruitInventory.Remove("banana");
}
PrintInventory();

// Conditional removal - remove all fruits with quantity < 5
foreach (var item in fruitInventory.Where(kvp => kvp.Value < 5).ToList())
{
    fruitInventory.Remove(item.Key);
}
PrintInventory();

// Safe access
if (fruitInventory.TryGetValue("apple", out int appleCount))
{
    Console.WriteLine($"We have {appleCount} apples");
}
else
{
    Console.WriteLine("No apples in inventory");
}

// Collection views
Console.WriteLine("\nFruit names:");
foreach (string fruit in fruitInventory.Keys) Console.WriteLine(fruit);

Console.WriteLine("\nQuantities:");
foreach (int quantity in fruitInventory.Values) Console.WriteLine(quantity);

// Transformation
var inventoryReport = fruitInventory.ToDictionary(
    kvp => kvp.Key.ToUpper(),
    kvp => $"Qty: {kvp.Value}"
);

Console.WriteLine("\nInventory Report:");
foreach (var item in inventoryReport)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}