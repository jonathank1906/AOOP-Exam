# Table of Contents
- [Object-Oriented Analysis](#object-oriented-analysis)
  - [OO Principles](#oo-principles)
  - [SOLID Principles](#solid-principles)
  - [Design Patterns](#design-patterns)
- [Programming](#programming)
  - [Classes, Constructors & Object Initializers](#classes-constructors--object-initializers)
  - [Properties](#properties)
  - [Interfaces](#interfaces)
  - [Collections](#collections)
  - [LINQ](#linq)
  - [Object, ToString, IComparable](#object-tostring-icomparable)
  - [File Handling (Read and Write)](#file-handling-read-and-write)
  - [Parsing JSON and CSV](#parsing-json-and-csv)
  - [Exception Handling](#exception-handling)
- [UI](#ui)
  - [MVC and MVVM](#mvc-and-mvvm)
  - [MVVM Toolkit](#mvvm-toolkit)
  - [Data Binding](#data-binding)
  - [Layout](#layout)
  - [Styling and Animations](#styling-and-animations)
- [Unit Testing and Avalonia Headless Testing](#unit-testing-and-avalonia-headless-testing)
- [Search and Sorting in C#](#search-and-sorting)
- [Multithreading](#multithreading)
  - [Tasks and Async / Await](#tasks-and-async--await)
  - [Avalonia UI Thread](#avalonia-ui-thread)
  - [Locking, Concurrent Collections](#locking)
  - [Task Cancellation, Task.WhenAll(), Periodic Timer](#task-cancellation-taskwhenall-periodic-timer)
 

# OO Principles
## Abstraction
### Conceptually:
Abstraction is a design principle. Abstraction is the idea of hiding complexity by exposing only essential features.

Abstract classes are a tool that supports both abstraction and inheritance — but their most defining characteristic is that they require inheritance to be useful.

Implemented using:
- Abstract classes 
- Interfaces
## Encapsulation
Encapsulation protects data. Implemented using:

- Properties
- Access modifiers

## Inheritance
> C# supports single inheritance only, meaning a class can only inherit from a single class.
- The derived class copies all members from the base class. Most often you dont want the method to act the same way as in the base class, so therefore a way to override it is needed.
- When a class inherits from a base class, it gains access to all non-private members of the base class:
    - `public` - accessible everywhere
    - `protected` - accessible in derived classes only
    - `internal` - accessible in the same assembly
    - `private` - not accessible in the derived class

### Abstract Classes
- The `abstract` keyword can be applied to classes, properties, and methods.
- Abstract classes are incomplete by design and they must inherited by a derived class.
- Abstract classes cannot be instantiated, meaning it is not allowed to create a new object using `new`.
    - However, only the concrete subclasses can be instantiated. They must implement all abstract members; otherwise, they stay abstract.
- That means theoretically you could have multiple abstract classes inheriting from another abstract class but at some point you will have a non-abstract class that you can create an object from.

Rules to follow:
- Fields (variables) cannot be marked as abstract.
    - Only methods, properties, indexers, and events can be `abstract`.
- An abstract class can have methods with or without implementation. Concrete members (fully implemented methods, properties, fields, etc.)
- A class can still be `abstract` even if it has no abstract members.


## Polymorphism
- Overriding can be used on properties also!
- Implemented using:
    - Interfaces
    - Types

Upcasting and downcasting
### Method Overriding (Run-Time Polymorphism)
- Both methods have the same signature
- `virtual` base class
- `override` derived class

- Only works with inheritance.

### Method Overloading (Compile-Time Polymorphism)
- `new`

(2 options): Works in the same class and with inheritance:
- The method parameters dont have to match in the derived class, they can be different.
- You can overload a method within the same class (multiple methods with same name, but different parameters).


Method overloading is fine for a single class. But for multiple layers of inheritance it should be avoided.


# SOLID Principles
[link1](https://bool.dev/blog/detail/solid-principles)
[video](https://www.youtube.com/watch?v=rylaiB2uH2A&t=6321s)
## S - Single Responsibility Principle (SRP)
> A class should have only one reason to change. In other words, a class should only have one responsibility or purpose.
The issue (violation):
- If a class has 2 reasons/places where it can change (if something has to be updated later on) then it voilates SRP.
- A single class has too many responsibilites.
    - `User` class contains 2 reponsibilites: logic for registering a user and holding user data fields. 

How its solved:
- It can be resolved by splitting it into a seperate class.
    - `User` class is refactored such that it is solely responsible for representing user data. The user registration logic is moved into a new class called `UserService`.
- A class should only have 1 reason/place where it can change.

## O - Open/Closed Principle (OCP)
> Software entities should be open for extension but closed for modification.
- This means you should be able to add new functionality without altering existing code.
Superclass: Higher up class.
Subclass: Lower class. This inherits from the superclass

The issue (violation):
 - The code has to be edited in two places if you want to add a new feature.

How its solved (1 possible solution):
- Encourages the use of abstraction and polymorphism to achieve this, through inheritance or composition.
1. Define an abstract class or interface. Abstract Shape class with an abstract method calculateArea().
2. Create concrete classes (rectangle, circle) that inherit from this abstract class.
3. Each of these concrete classes will override the method from the abstract class, which allows the class to provide its own implementation.

What this solves:
- Now the Shape class does not need to be changed if a new shape is added (triangle).
- The code becomes loosely coupled and more maintainable.

## L - Liskov Substitution Principle (LSP)
> Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
The problem (violation):
Similar class inherits from another class.

How its solved:
- Remove the complex inheritance (the 3rd level).
- Replace it to only have a 2nd level inheritance.

## I - Interface Segregation Principle (ISP)
> Clients should not be forced to depend on interfaces they do not use.
- From the definition, the client is simply the classes that are using the interface.

The problem (violation):
- A class is forced to implment the methods defined in an interface. The problem arises when this class has to implement the methods it doesnt need/or that are invalid/irrelevant.

The solution:
- Implement seperate interfaces (nothing wrong with this)
    - Split the larger interface into seperate more specific interfaces.
- A class can even implement several interfaces...

## D - Dependency Inversion Principle (DIP)
> High-level modules should not depend on low-level modules. Both should depend on abstractions.

The problem (violation):
- Tight coupling between two classes.


Solution:
- Implement an interface or abstraction (not a concrete implementation)

What it solves:
- Promotes loose coupling between components by removing direct dependencies (more flexibile).
- Easier unit testing with dependency injection, by allowing components to be replaced.
    - Dependencies can be swapped at runtime.

``` cs
var car = new Car(new Engine());
```


# Design Patterns
[video](https://www.youtube.com/watch?v=rylaiB2uH2A&t=6321s),
[video2](https://www.youtube.com/watch?v=YM_Xl77bVWw),
[link](https://www.dofactory.com/net/design-patterns)  
There are 3 categories of design patterns:
1. Creational
	- Singleton
2. Structural
	- Facade
3. Behavioral
	- Command
	- Observer
	- Strategy

*Dependency injection


## Singleton
- A class of which only a single instance can exist.

## Facade
- The primary objective of the Facade pattern is to provide a simplified interface to a complex subsystem, reducing client-side complexity.
    - Note: The word "interface" in the definition does mean it requires interfaces. It can be implemented using regular classes.

## Command
- Is part of the MVVM toolkit
- The command pattern encapsulates any operation into an object, supporting operations such as undo/redo. Also, it is primarily used for queing operations.
## Observer
- The Observer Pattern involes an object, known as the subject, maintaining a list of its dependent objects, called observers, and notifiying them automatically of any state changes.
- It can be implemented both with and without MVVM toolkit.
	- There is also a basic one.
- It is a UI design pattern
- The observer pattern is present behind anything that involves data binding.

## Strategy
- The Strategy pattern encapsulates an algorithm for interchangeability. Also, it it used for selecting algorithms at runtime.
It is recognized by these key features:
1. Interface Implementation: You define an interface that represents the strategy. Each concrete class implementing this interface represents a different algorithm or strategy.
2. Context Class: This class maintains a reference to the strategy interface. It uses this reference to execute the strategy, allowing the algorithm to be selected at runtime.

``` cs
// Strategy Interface
public interface IStrategy
{
    void Execute();
}

// Concrete Strategies
public class StrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy A");
    }
}

public class StrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy B");
    }
}

// Context Class
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        Context context = new Context(new StrategyA());
        context.ExecuteStrategy(); // Output: Executing Strategy A

        context.SetStrategy(new StrategyB());
        context.ExecuteStrategy(); // Output: Executing Strategy B
    }
}
```

## Dependency Injection
- You don’t instantiate stuff inside of a class, but outside of a class and then you give it to the class. Meaning, you inject the dependency of the class from outside.

# Classes, Constructors & Object Initializers
## Object Initializers

# Properties

# Interfaces
- Interfaces define contracts for behavior, but without implementing that behavior.

- An interface is a "can-do" relationship.
- Interfaces cannot be instantiated, but can be referenced.

> A class can implement multiple interfaces.


# Collections
[video1](https://www.youtube.com/watch?v=RWXehFD_KSw)  
In order to work with the collections (besides arrays), you must include:
``` cs
using System.Collections.Generic;
```
``` cs
// Observable collections for UI
```

## Arrays
- Fixed size collection. When you define an array, you have to define its size and it cannot be changed later.
```cs
// Character array
char[] hello; // Declare

char[] hello = new char[5]; // Define

// Initialize
hello[0] = 'h';
hello[1] = 'e';
hello[2] = 'l';
hello[3] = 'l';
hello[4] = 'o';

// Array initilization syntax
var hello = new[]
{
    'h','e','l','l','o'
};
```

Getting the legnth
- Returns the amount of elements within the array, NOT the size of the array.
```cs
hello.Length;
```
## Generics
- Generics provide a way to define classes, methods, 
and interfaces with a placeholder for the data type.
``` cs
class List<T>
{
    public T[] items {get; set;}
}
```

## Lists
- Dynamic arrays

Full example:
```cs
var words = new List<string>(); // New string-typed list

var printWords = () => {foreach (string s in words) Console.WriteLine (s);};

words.Add ("melon");
words.Add ("avocado");
words.AddRange (["banana", "plum"]);
printWords();
// Output:
// melon
// avocado
// banana
// plum
```
Introduction starts here
```cs
// Creating an empty list
var emptylist = new List<string>();

// Prepopulating a list
var names = new[]
{
    "John","Jane"
};

var nameslist = new List<string>(names);

// Initilizer syntax
var list = new List<string>
{
    "John","Jane"
};
```

Adding items to a list
- Tip: We can start by creating an empty list and add items to it afterwards.
```cs
var list3 = new List<string>();
list3.Add("John");
```
Return list size with:
```cs
Console.WriteLine(list3.Count);
```

Adding multiple items to a list at once
- The items that you want to add, need to be in a collection.
```cs
list3.AddRange(names); // Count is 3
```

Accessing specific entries using index notation
```cs
list3[0]; // Tim
list3[1]; // John
list3[2]; // Jane
```

Insert a new item at a certain position.
- For the index, it has to be an index that has a value.
- This will shift the existing items over after it inserts.
```cs
list3.Insert(2,"Sam");
```

Removing items from a list
- It will start from the beginning of the collection(left to right), and will remove the first match (if there are multiple of the same).
```cs
list3.Remove("John");
```

Removing all specific items from a list
```cs
list3.RemoveAll(s => s=="John");
```

Removing at a specific index
- The items to the right will shift to fill in the spot that was removed.
```cs
list3.RemoveAt(1);
```

Checking if a list contains a specific entry
- Returns true or false
```cs
list3.Contains("Tim");
```

Finding the index of a specific item
```cs
list3.IndexOf("Tim");
//list3.LastIndexOf();
```

Find items based upon a certain criteria
- Returns the first item that matches the criteria.
```cs
list3.Find(s => s.StartsWith("T")); // Returns 1
list3.FindAll(s => s.StartsWith("T")); // Returns all

// Remove all strings starting in 'n':
words.RemoveAll(s => s.StartsWith ("n"));
```

**Printing**
```cs
Console.WriteLine(words [0]); // first word
Console.WriteLine(words [words.Count - 1]); // last word
foreach (string s in words) Console.WriteLine (s); // all words
```
**Convert entire list to uppercase**
```cs
List<string> upperCaseWords = words.ConvertAll (s => s.ToUpper());
foreach (string s in upperCaseWords) Console.WriteLine (s);
// Output:
// PEACH
// LEMON
// BANANA
// PLUM
```
**Convert string to length**
```cs
List<int> lengths = words.ConvertAll (s => s.Length);
foreach (int s in lengths) Console.WriteLine (s);
// Output:
// 5
// 5
// 6
// 4
```


## Dictionary
- A dictionary is generic, meaning the key and value can be of any data type (value type or reference type).
- There are two ways to a initilize a dictionary and two ways to add key-value pairs.
``` cs
// Creating an empty dictionary
var types = new Dictionary<string,string>();
// Make it case-insensitive by adding:
// StringComparer.OrdinalIgnoreCase in the ()

// Prepopulating a dictionary with predefined key-value pairs (syntax style 1)
Dictionary<string, int> args = 
new Dictionary<string, int> // <key, value>
{
    {"Alice", 25}, 
    {"Bob", 30}
};

Console.WriteLine(args["Alice"]);
// 25

// Index notation predef (syntax style 2)
var types = new Dictionary<string,string>
{
    ["txt"] = "notepad.exe"
}
```

```cs
types["pdf"] = "acrobat.exe"
types.Add("docx","winword.exe");
```

## Queue (FIFO)
> FIFO: First In, First Out
```cs
// Creating an empty queue 
var queue = new Queue<string>();
```

Adding items to a queue
- Items have to be added one-by-one. If you had a collection of items that you want to add to the queue, then you would have to enumerate over that collection and add in each item one-by-one.
```cs
queue.Enqueue("Item1");
queue.Enqueue("Item2");
```

Checking on queue
```cs
if(queue.Count > 0)

// Using LINQ query
if(queue.Any())
```


Peeking
- Peek at the first item in the queue. 
```cs
queue.Peek()
```
- This returns the value without removing it from the queue.

Removing items from a queue 
```cs
queue.Dequeue();
```

Removing all items from a queue.
```cs
queue.Clear();
```

## Stack (LIFO)
> LIFO: Last In, First Out

Creating an empty stack
```cs
// string stack
var stack = new Stack<string>();

// int stack
Stack<int> stack = new Stack<int>();
```

Adding items to a stack
```cs
stack.Push("item1"); // Now the stack looks like: [item1]
stack.Push("item2"); // Now the stack looks like: [item1, item2]

stack.Push(10);  // Now the stack looks like: [10]
stack.Push(20);  // Now the stack looks like: [10, 20]
```


Peek
- Allows you to "peek" at the value of the last item in the stack. It will not remove that item.
```cs
stack.Peek();
```


Removing items from a stack
- Removes the top(last) items first
```cs
stack.Pop();

Console.WriteLine(stack.Pop());  // Pops and prints the top value
```

Removing all items from a stack.
```cs
stack.Clear();
```
## Hashset
- The hashset collection is rather specialized. It is not one that we use on a regular basis, however it provides a lot of useful functionality when need to work with multiple collections and you need to identify duplicate values. Its also useful when you need to remove all duplicate values from a collection or multiple collections.

# LINQ
What is a Query?
- Stands for Language Integrated Query
- Used for data manipulation.
- A query is essentially a question you ask about your data set about. It 
has to be in a certain order that you formulate the quesstion.
If there is x amount of students enrolled in a
a class/ 

They can be applied to Lists, databases.....

## Using LINQ
LINQ features can be used in a C# program by importing the `System.Linq` namespace.
```cs
using System.Linq;
```

### var
Since the type of an executed LINQ query’s result is not always known, it is common to store the result in an implicitly typed variable using the keyword var.
``` cs
var custQuery = from cust in customers
                where cust.City == "Phoenix"
                select new { cust.Name, cust.Phone };
```

A dataset can be seen below
- The rows represent single objects inside of the collection
- The columns represent the fields of the objects.

``` cs
public class Product // Column definitions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}

// Filling the rows with data
List<Product> products =
[
    new Product
    { Id = 1, Name = "Laptop", Price = 899.99m, Category = "Electronics" },
    new Product
    { Id = 2, Name = "Smartphone", Price = 599.99m, Category = "Electronics" },
    new Product
    { Id = 3, Name = "Tablet", Price = 499.99m, Category = "Electronics" },
    new Product
    { Id = 4, Name = "Shoes", Price = 59.99m, Category = "Apparel" }
];
```
| Id | Name       | Price  | Category    |
|----|------------|--------|-------------|
| 1  | Laptop     | 899.99 | Electronics |
| 2  | Smartphone | 599.99 | Electronics |
| 3  | Tablet     | 499.99 | Electronics |
| 4  | Shoes      | 59.99  | Apparel     |

## (Method Chaining / Lambda Syntax) & Query Syntax 
Two syntaxes for LINQ queries:
1. (Method Chaining / Lambda Syntax)
2. Query syntax
* You can always mix these syntaxes in your code. No restrictions on that!

**Method Chaining Syntax**
- Uses a . before the method (where, orderby, select, etc.)
``` cs
var output = books.Where(condition)  
                  .OrderBy(property)  
                  .Select(property);
```
**Query Syntax**
- Query must end with a Select or Group clause.

``` cs
var output = from b in books  
                    where condition  
                    orderby property  
                    select property;
```

## Where  
> Operates on the rows. A `Where` operation results in the same # of columns but fewer rows.
- "Give me the items from this list WHERE my condition is met"
- Used for SELECTION filtering
- Chooses the items.

Since the right side is a boolean value you can add mutliple condition using && 

``` cs
// Method chaining syntax for filtering
var cheapProductsMethod = products.Where(p => p.Price < 100).ToList();

// Query syntax for filtering
var cheapProductsQuery = from p in products
                         where p.Price < 100
                         select p;
foreach (var product in cheapProductsMethod)
{
    Console.WriteLine($"{product.Name} - {product.Price} - {product.Category}");
}
```

``` cs
using System;
using System.Collections.Generic;
using System.Linq;

var mynumbers = new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34};

var numbersOver5 = mynumbers.Where(n => n > 5); // Where expects a boolean value, to the right of the lambda operator

foreach (var num in numbersOver5)
{
    Console.WriteLine(num);
}
```

## Select
> Operates on the columns. A Select operation results in the same # of rows but fewer columns.
- Also called "Projection"
- Looks at the columns
- Chooses the fields we want to look at

``` cs
// Method chaining syntax for selecting product names
var productNamesMethod = products.Select(p => p.Name);

// Query syntax for selecting product names
var productNamesQuery = from p in products
                        select p.Name;
foreach (var name in productNamesMethod)
{
    Console.WriteLine(name);
}
```

### SelectMany
- Flattens

```cs
 var allSkills = employees.SelectMany(e => e.Skills);
```

## OrderBy, OrderByDescending, ThenBy (Sorting) 
Sort in ascending or descending order
- The fields must be int, double, float, etc: smallest to largest for example
- string alphabetical order maybe

- OrderBy - Ascending order  
- OrderByDescending - Descending order
- ThenBy

``` cs
var sortedProductsMethod = products.OrderBy(p => p.Price).ToList();

var sortedProductsQuery = from p in products
                          orderby p.Price
                          select p;

foreach (var product in sortedProductsMethod)
{
    Console.WriteLine($"{product.Name} - {product.Price}");
}
```

``` cs
//.ToList() // Execute it now.
```

## Sum, Average, Min, Max, Count (Aggregation)

``` cs
decimal totalPrice = products.Sum(p => p.Price);
decimal avgPrice = (decimal)products.Average(p => p.Price);
decimal maxPrice = products.Max(p => p.Price);
decimal minPrice = products.Min(p => p.Price);
int productCount = products.Count();

Console.WriteLine($"Total Price: {totalPrice}");
Console.WriteLine($"Average Price: {avgPrice}");
Console.WriteLine($"Max Price: {maxPrice}");
Console.WriteLine($"Min Price: {minPrice}");
Console.WriteLine($"Product Count: {productCount}");
```

## GroupBy 
- Grouping splits data into groups based on a common key.
If we wanted the average price of electronics and apparel. Notice the products are sorted into these 2 categories.
Steps:
1. Group the items by category

``` cs
// Method chaining syntax for grouping products by category
var groupedByCategoryMethod = products.GroupBy(p => p.Category).ToList();

// Query syntax for grouping products by category
var groupedByCategoryQuery = from p in products
                             group p by p.Category into g
                             select g;
                             
foreach (var group in groupedByCategoryMethod)
{
    Console.WriteLine(group.Key);
    foreach (var product in group)
    {
        Console.WriteLine($" {product.Name} - {product.Price}");
    }
}
```

## Combining Operations (Selection + Projection??)

2. Get the average price of each group
``` cs
// Method chaining syntax: Filter, Select, and Sort
var sortedCheapProductsMethod = products.Where(p => p.Price > 500)
                                        .Select(p => new {p.Name, p.Price})
                                        .OrderBy(p => p.Price)
                                        .Select(p => p.Name)
                                        .ToList();
// Query syntax: Filter, Select, and Sort
var sortedCheapProductsQuery = from p in products
                               where p.Price > 500
                               select (p.Name, p.Price) into np
                               orderby np.Price
                               select np.Name;
foreach (var name in sortedCheapProductsMethod)
{
    Console.WriteLine(name);
}
```

## Other LINQ queries:  
### Join
- `Join` is used when you have two databases that you want to combine. One database could contain the main fields and the other could contain several IDs.
    - **Important:** Both databases need to share some form of similar information (such as an ID) so they can be connected properly. Again, you match records from two sources using a shared value, typically an ID or another key field.

Example:
```cs
List<SalesReportItem> salesReport = [];

List<Product> Products = 
[
    new Product { Id = 1, Name = "Laptop", Price = 899.99m, Category = "Electronics" },
    new Product { Id = 2, Name = "Smartphone", Price = 599.99m, Category = "Electronics" },
    new Product { Id = 3, Name = "Tablet", Price = 499.99m, Category = "Electronics" },
    new Product { Id = 4, Name = "Shoes", Price = 59.99m, Category = "Apparel" }
];

List<Sale> Sales = 
[
    new Sale(1, 5, new DateTime(2024, 3, 1)),  // 5 Laptops sold
    new Sale(2, 10, new DateTime(2024, 3, 2)), // 10 Smartphones sold
    new Sale(3, 7, new DateTime(2024, 3, 3)),  // 7 Tablets sold
    new Sale(1, 3, new DateTime(2024, 3, 4)),  // 3 more Laptops sold
    new Sale(4, 20, new DateTime(2024, 3, 5))  // 20 Shoes sold
];

  
SalesReport = Sales!.Join(Products!, 
    sale => sale.ProductId,  
    product => product.Id, 
    (sale, product) => new SalesReportItem
    {
        Name = product.Name,
        Category = product.Category,
        Price = product.Price,
        QuantitySold = sale.QuantitySold,
        TotalRevenue = sale.QuantitySold * product.Price,
        Date = sale.Date
    }).ToList();
```
- Sales is the outer sequence (the one you're iterating through first)
- Products is the inner sequence (the one you're matching against).
- Note: The order can be reversed, but make sure to adjust the parameters correctly.

General structure breakdown:
```cs
outer.Join(
    inner,  
    outerKeySelector,
    innerKeySelector,
    resultSelector
)
```
- Outer sequence: "What you're starting with"
- Inner sequence: "What you're matching against"
- Outer key selector: "How to get the key from the sale"
- Inner key selector: "How to get the key from the product"
- Result selector: "How to combine both into a new object"

- The `!`
### Contains:
```cs
var query = names.Where(x => x.Contains("a"));
```

# Object, ToString, IComparable
## The Object Type
- Every class in C# automatically inherits from the object class, even through you dont specifiy that it inherits from `Object`.

## ToString()
- Useful for when printing an object to the console. It will convert the object to a string. Otherwise you will see the type.
    - Also useful for testing purposes to be able to check the fields that it is set to.
- Always remember to override the `ToString()` method.

```cs
// Without ToString()
public class Panda
{
    public string Name;
}

Panda p = new Panda { Name = "Petey" };
Console.WriteLine (p); // Panda

// With ToString()
public class Panda
{
    public string Name;
    public override string ToString() => Name;
}

Panda p = new Panda { Name = "Petey" };
Console.WriteLine (p); // Petey
```

## IComparable
- `IComparable` is an interface which can be used for sorting. When your class implements this interface, it can ....
- You are forced to implement the `CompareTo()` method.

# File Handling (Read and Write)
## Reading from a File  
The StreamReader class can be used to read data from a file. The code below demonstrates how to read all lines from a text file using StreamReader:
``` cs
using (StreamReader reader = new StreamReader("file.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
```

## Writing to a File  
The StreamWriter class can be used to write data to a file. The code below demonstrates how to write a string to a text file using StreamWriter:
``` cs
using (StreamWriter writer = new StreamWriter("file.txt"))
{
    writer.WriteLine("Hello, world!");
}
```

# Parsing JSON and CSV
## CSV

- Preliminary Step: Install CSV helper with the NuGet command or manually enter it into the .csproj file.
- In either case of a console application or Avalonia app,
you will need to check if CsvHelper exists in the .csproj file. 
```
<ItemGroup>
 <PackageReference Include="CsvHelper" Version="33.0.1" />
</ItemGroup>
```

**Step 1: Prepare the data**
- Create a class to represent
- `CsvHelper.Configuration.Attributes` contains the [Name] attribute.
- The `[Name("ColumnName")]` attribute directly maps a property in your class to a column in the CSV file.
- If the CSV column name matches the property name exactly, you can even omit `[Name]` (case-insensitive by default).
- Map the properties to the attributes of the CSV file using `[Name("ColumnName")]`
``` cs
using CsvHelper.Configuration.Attributes;

public class Comic
{
    [Name("Title")]  // Maps to the "Title" column in the CSV
    public string Name { get; set; }  // Property name differs from CSV column

    [Name("ReleaseYear")]  
    public int Year { get; set; }  // Maps "ReleaseYear" in CSV to "Year" property

    public int PageCount {get ; set; } // Exactly matches in the CSV file
}
```
**Step 2: Read data using CsvReader**  
Use `Streamreader`
``` cs
using CsvHelper;
using System.Globalization;

public class DataLoader
{
    public List<T> LoadCsv<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<T>().ToList();
    }
}

// Trigger - 2 options
var employees = dataLoader.LoadCsv<Employee>("employees.csv");
List<Employee> employees = dataLoader.LoadCsv<Employee>("employees.csv");
```
**Step 3 (optional): Write data using CsvWriter**
## JSON
- Include `using System.Text.Json;`
<details>
<summary>Handling Null During Deserialization</summary>

IF I DO CHECK FOR NULL DURING DESERIALIZATION  
- It is not necessary to set to empty.

IF I DON'T CHECK FOR NULL DURING DESERIALIZATION  
Callout  
- Strings must be set to empty  
    - Otherwise you will see: `Error reading file: Object reference not set to an instance of an object.`  
- `int`, `bool`, `double` can be left as is  
</details>

**Step 1: Define the Data Model (Structure)**
- Creates a C# class that mirrors the JSON structure. 
- Ensures properties are initialized to avoid null issues.

``` cs
public class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsEmployed { get; set; }
    public List<string> Hobbies { get; set; } = new List<string>();
}
```
**Step 2: Locate and Read the JSON File**
- Checks if the file exists (critical for error handling).
- Reads the raw JSON text into a string.
``` cs
string filePath = "person.json";
// Verify the file exists
if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File not found at {Path.GetFullPath(filePath)}");
    return;
}
// Read the file content
string jsonString = File.ReadAllText(filePath);
```

**Step 3: Configure Deserialization (Optional but Recommended)**
- Makes parsing more flexible (e.g., accepts "firstName" or "FirstName").
- Handles edge cases (like commented JSON).
```cs
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,  // Ignore property name casing
    ReadCommentHandling = JsonCommentHandling.Skip  // Allow comments in JSON
};
```

**Step 4: Deserialize JSON into Objects**
- Converts the JSON string into a Person object. 

``` cs
// The ?? operator throws a clear error if deserialization fails (returns null).
Person person = JsonSerializer.Deserialize<Person>(jsonString) 
    ?? throw new Exception("Deserialization failed: returned null");

// If using the options from step 3:
Person person = JsonSerializer.Deserialize<Person>(jsonString, options) 
    ?? throw new Exception("Deserialization failed: returned null");
```

**Step 5: Validate and Use the Data**

# UI

Setting up a new Avalonia MVVM project:
1. Create a new empty folder
2. Open this folder in VS Code
3. In the terminal, create a new Avalonia MVVM project: `dotnet new avalonia.mvvm`

## ViewModel
Connecting view to viewmodel:  
Top of the view (`Window` or `UserControl`):
``` xml
xmlns:vm="using:Layout.ViewModels"
x:Class="Layout.Views.MainWindow"
x:DataType="vm:MainWindowViewModel"
```
- The ViewModel class has `partial` in it.


## UI Elements
[Avalonia Docs - Controls](https://docs.avaloniaui.net/docs/reference/controls/)




# MVC and MVVM

# MVVM Toolkit
## `[RelayCommand]`
- Requires `using CommunityToolkit.Mvvm.Input;` at the top of the viewmodel

Examples:
| Method Name (ViewModel) | Generated Property Name (View) |
|----|-----------|
| Start  | StartCommand |
| Stop  | StopCommand |

## `[ObservableProperty]`
- Requires `using CommunityToolkit.Mvvm.ComponentModel;` at the top of the viewmodel. In addition, the class must inherit from `ObservableObject` (or from a custom base class that inherits from it, such as `ViewModelBase`).
- Observable properties can be updated at any time while the application is running. When you change their value in the ViewModel, the UI will automatically update to reflect the new value.
    - It automatically implements `INotifyPropertyChanged`.
- For static/constant values, a regular property is fine.
- Observable properties are setup in the ViewModel.

# Data-Binding
- Data binding is typically done between the View and ViewModel. However, it is also sometimes necessary to do bindig between the View and the code behind.
Pre-check:
- The ViewModelBase.cs (located inside the ViewModels folder) should inherit from either observableobject or reactiveui
- Each viewmodel should inherit from viewmodelbase


> **Bindings are case-sensitive!**  

Bindings in the view follow:
- Capital (first letter/word and all words)

``` xml
<!-- In axaml view -->
<TextBlock Text="{Binding ProductName}" />
```
## Code Behind Binding
- x:Name or Name

- Buttons: Click=""

```cs
// In ViewModel
[ObservableProperty]
private string _productName;
```

ObservableProperty or variables should start:
- Lowercase first letter/word, then uppercase for all words after. 

Examples:
| Field Name (ViewModel) | Generated Property Name (View) |
|----|-----------|
| _productName  | ProductName |
| productName  | ProductName |


# Layout
Rules to follow:
- Any `Window` or `UserControl` can only have a single child element as its Content.  

This can be solved by: If you want to display multiple UI elements, you must place them inside a parent container that supports multiple children, such as: - Surround entire code with any of the following:
- StackPanel
- Grid
- DockPanel
- WrapPanel
- Canvas

## Grid

- Add additional <Grid> </Grid> for each row or columns's individual content

- Defining rows and columns
    - Specify specific size
    - "*" means it will be locked in place (wont move)
    - "Auto" means

``` xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="45" />
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
</Grid>
```

- Grids can be nested to achieve more complex layouts

# Styling and Animations

# Unit Testing and Avalonia Headless Testing
## Xunit

### Setup
To setup Xunit testing:
- Have 2 folders
    - One with the name
    - Another with the name + .Tests


Sample folder structure using a console application:
```
CalculatorSolution/
├── CalculatorSolution.sln
├── CalculatorApp/
│   ├── CalculatorApp.csproj
│   └── Program.cs
└── CalculatorApp.Tests/
    ├── CalculatorApp.Tests.csproj
    └── CalculatorTests.cs
```

**1. Create the solution and projects**  
- Run all these commands from your root project directory
```
dotnet new sln -n CalculatorSolution
dotnet new console -n CalculatorApp
dotnet new xunit -n CalculatorApp.Tests
```

**2. Add projects to the solution**  
- Run these from the root directory where `CalculatorSolution.sln` is located
    - Also use the solution explorer extension.
```
dotnet sln add CalculatorApp/CalculatorApp.csproj
dotnet sln add CalculatorApp.Tests/CalculatorApp.Tests.csproj
```

**3. Add reference from test project to main project**
- Run this from inside the `CalculatorApp.Tests` directory
- Connecting the test project to the main application.
```
# Move into the test project directory
cd CalculatorApp.Tests

# Add reference to main project
dotnet add reference ../CalculatorApp/CalculatorApp.csproj

# Return to root directory (optional)
cd ..
```
- What this does is create a reference inside the `CalculatorApp.Tests.csproj` that looks like this:
```
<ItemGroup>
    <ProjectReference Include="..\CalculatorApp\CalculatorApp.csproj" />
</ItemGroup>
```

## Avalonia Headless Testing
[Avalonia Headless Testing](https://github.com/AvaloniaUI/Avalonia.Samples/tree/main/src/Avalonia.Samples/Testing/TestableApp.Headless.XUnit)

# Search and Sorting
## Searching Algorithms
- The main goal of searching algorithms is to search if a specific number exists in a set. 


### Sequential search
### Binary search
- Requires the set to be sorted before it can be searched.
- 
## Sorting Algorithms
[Link](https://www.bigocheatsheet.com)
### Selection sort
### Bubble sort
### Merge sort
### Quick sort

# Multithreading
[video](https://www.youtube.com/watch?v=88e9uMlLCf8&t=1174s)

## Task
- `Task` is a class that is built upon threads (note: threads should never be used).

A task can be run using a function call or a lambda expression. In the case of the lambda expresion we just put whatever needs to be run inside there.

Simple task
Call `Task.Run()`

`task.Wait();`

You can write async methods almost in the same way synchronous methods would be written.


Step 0: 
The top-level code should have an async method to call the async task in Step 1.


Step 1:
Keep the return type. Then add Task<return type>. For example Task<int> instead of int.

If the method should be void, dont write void.

Add the async keyword in the beginning.



Even though the method is declared to return Task<int>, it’s written as if it returned int directly. The return value automatically becomes the result of method’s task.

- It is possible to make a `List`, or even a `Dictionary` of tasks. 
### Task Exceptions


## async and await
- The most important feature specific to async methods is the `await` operator. In fact, the `async` modifier just makes the `await` work, and if a method is marked async and does not have any `await` in it’s body, compiler issues a warning.

| Sync declaration | Async declaration |
|----|-----------|
| `void DoWork()`  | `async Task DoWorkAsync()` |
| `int DoWork()`  | `async Task<int> DoWorkAsync()` |

### async Keyword

### await Keyword
By default programs are executed synchronously, if not specified,
By default (synchronous), when a computer reaches a task that is external it waits until that task is completed, so that current thread just stops and waits.

The problems this introduces:
- The current thread becomes "Blocked" from doing any other tasks.
    - If we have a UI application, the UI thread cannot update while a backend thread is doing a big task.

Only 1 problem is solved with async:
- The issue of the thread becoming blocked is solved. It makes UI applications responsive.

The concept of async and await:
How it does this? When the application arrives at a point whre you await something (marked with the await keyword), that thread is not blocked anymroe because it is released back to the "Thread pool". Only when the result from the external resource is available then we get kind of like a new thread that would resume execution from that point. In the meantime, in those seconds where actually the thread would not do anything is instead of sitting there and waiting it is released and can be actually used to perform some other work in the meantime.

> A common misconception is that async await will solve the issue of running tasks in parallel. However this is NOT the case. It will not execute any faster, it only solves the 1 problem stated before.

- One convention is to name the aync task with async at the end of the name.

What does asynchronous mean? Performing several tasks at once    
Synchronous means performing only one task at a time.

``` cs
using System;
using System.Threading.Tasks;
using System.Threading;

private async Task doSomethingAsync()
{
    await TaskAsync();
}

private Task TaskAsync()
{
    Task task = Task.Run(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Task {i}");
            Thread.Sleep(100);
        }   
    });
    return task;
}
```

- Methods are set as asynchronous because it might take time to execute. The await inside it ensures the method doesn’t block the UI while it runs. 
    - The `await` keyword provides a nonblocking way to start a task, then continue execution when the task completes.



## Avalonia UI thread (updating the UI)
- Dont update the UI from a different thread. Everytime you asynchronously do something in a seperate thread and you want to change something in the UI, you should explicitly go back to the UI thread. In other words, you should not change something about the UI from outside of the UI Thread.

``` cs
public async Task Update(int d1, int d2, int count)
{
    await Dispatcher.UIThread.InvokeAsync( () =>
    {
        DieOneImage = _images[d1 - 1];
        DieTwoImage = _images[d2 - 1];
        Result = count;
    });
}
```

``` cs
Dispatcher.UIThread.Post(() => SetText(text));

// Start the job on the ui thread and wait for the result.
var result = await Dispatcher.UIThread.InvokeAsync(GetText);
```


# Thread Safety
- Code that can have race conditions is usually called "not thread-safe". Goal is to avoid potential race conditions. 
> Two options to make your code thread safe:  
>1. Lock yourself (fields or collections).
>2. If working with a collection (list, dictinoary), use the thread safe version, which are concurrent collections.

## Race Conditions
- Race conditions occur when you have multiple threads that access some shared data at the same time. If at least once thread changes something about the data, you can have a race condition.
- Essentially, the threads race through the program and trigger operations in an unpredictable order. We usually dont like nondeterministic behavior in code because it is unpredicatable. You want your code to do what you programmed it to and not do something random unless you intentionally do so.
    - It is also hard to find bugs out of unpredictable code.     
- Code that can have race conditions is called **not thread-safe**.



## Locking
Locking is directly related to thread safety. 


Locking is done using a "Locked block":
```cs
lock (_counterLock)
{
    sharedCounter++;
}
```
- Locking ensures that only one thread can ever enter this part of the code at the same time (the locked block). So, multiple threads are coming, but as soon as one thread goes in there, no other threads are allowed.
- Any object in C# can be locked with the `lock` keyword. So any shared object can be used as a lock.
    - Tecnically you can use the shared variable and lock that. However, it is best practice to create a new lock object and use it to lock, not the variable. In order to be completely "safe", this lock object should be `readonly` so it can never be changed.
- Repetition: Lock everything that can be modified by multiple theads. If it is only being read by multiple threads, then there is no need to lock it.
### Dead Lock
- An issue can arrise with locking, which is called dead locks. How this happens is basically when you lock something with one thread and then lock another thing with the other thread and then lock the threads each other lock eachother and now they can never unlock.
- The easiest way to avoid it is by always locking in the same order (locks are inside of each other).



## Concurrent Collections
- Standard (generic) collections are not thread-safe for writing or enumeration. What this means is if you change a list for example, and you have another thread going through each item in the list (enumeration - for loop) and you change it in a different thread your program will either do something weird or will throw an exception.
    - This is done on purpose (why the collections are not thread-safe by default) as making a collection thread safe by locking is not for free. The disadvantage is that is makes it a little slower to compute.

> When doing tasks involving a collection, instead of using the traditional collection which are not thread safe, use the thread safe version called **concurrent collections**.
We want to avoid the issue for example:
- When looping through a list, while another thread adds an item or different items, problems might occur, might throw an exception.
    - Again, multiple threads modifing the same data in a collection.

Include:
```cs
using System.Collections.Concurrent;
```
- Concurrent collections are not very different from normal collcetions, in terms of syntax and usage. Concurrent collections, however, are only useful for multithreaded applications. In addition, only if you plan on using the collection over multiple threads. Otherwise the normal collections are still the way to go if you plan on using it with just one thread.

 

Concurrent collections:  
`ConcurrentBag<T>` 
- Unordered, like throwing something in a bag. Side note when an item gets added to a regular list, it gets added to the next index.

`ConcurrentQueue<T>`  
- If the order is important

`ConcurrentStack<T>`  
- If the order is important

`ConcurrentDictionary<TKey, TValue>`  
- Keys and values are used to 


# Concurrency
Here we actually want to run multiple things in parallel.

## Task Cancellation 
- Previously we have canceled a task by setting a boolean variable (isrunning) to false, however this is not the proper way to do it.
- To cancel a task from outside of a task: The proper way to do it, the thread safe way, is to use cancellation token source.
    - Note: if you are just canceling a task from inside the task itself then you can do something simpler like break.

## Concurrent Tasks - Task.WhenAll() 
- `Task.WhenAll()` used when you have multiple tasks running concurrently and you want to wait for all of them to complete. See the example below or when having a collection of tasks.

- We can manage concurrent asycnhronous operations by using `Task.WhenAll()`
- It allows you to execute multiple tasks at the same time and it waits for all of them to be finished.

- `Task.WhenAll()` is not Needed for a single task, so if you only have one task, you can just await it directly.
Downsides:
- Runs in any order, which cant be tracked. The problem with this is that often processes have to executed in a certain order.
    - No exception handling feedback. It cannot be determined which task threw the exception.

It ok to use for:
- Fire-and-forget tasks, where the tasks can be executed in any order. It runs tasks in parallel. Saves time.

```cs
// Simulate processing data sources in parallel
Task task1 = Task.Run(() => CountWords(new[] { "apple", "banana", "apple" }));
Task task2 = Task.Run(() => CountWords(new[] { "orange", "banana", "orange" }));
Task task3 = Task.Run(() => CountWords(new[] { "apple", "orange", "grape" }));

await Task.WhenAll(task1, task2, task3);
```
Also use `WhenAll()` with a collection of tasks:
```cs
List<Task> downloadTasks = new List<Task>();
```

## Periodic Timer
- Used for when you want a task to occur for example every 5 seconds or every 5 hours. This could be a task that keeps downloading something or keeps updating something from a database.
    - The essential idea is that this task does not run the whole time but only does something every certain amount of time.
- Another use case is for it to be used to run work in the background and do updates all the time.

It is better to use a periodic timer instead of the traditoinal way where you would use a while true loop that waits for five milliseconds for example.