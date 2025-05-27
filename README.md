# Table of Contents
- [Object-Oriented Analysis](#object-oriented-analysis)
  - [OO Principles](#oo-principles)
  - [SOLID Principles](#solid-principles)
  - [Design Patterns](#design-patterns)
  - [Dependency Injection](#dependency-injection)
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
- [Search and Sorting in C#](#search-and-sorting-in-c)
- [Multithreading](#multithreading)
  - [Tasks and Async / Await](#tasks-and-async--await)
  - [Avalonia UI Thread](#avalonia-ui-thread)
  - [Locking, Concurrent Collections](#locking-concurrent-collections)
  - [Task Cancellation, Task.WhenAll(), Periodic Timer](#task-cancellation-taskwhenall-periodic-timer)
 

# OO Principles
## Abstraction
Abstraction is the idea of hiding complexity.
Abstract classes are one way to achieve it, it can also be implemented using: 
- Interfaces

## Encapsulation
Encapsulation protects data

Implemented using:

- Properties
- Access modifiers

## Inheritance
> C# supports single inheritance only, meaning a class can only inherit from a single class.

## Polymorphism
- Overriding can be used on properties also!
### Method Overriding (Run-Time Polymorphism)

### Method Overloading (Compile-Time Polymorphism)

Implemented using:

- Interfaces
- Types



# SOLID Principles
[link1](https://bool.dev/blog/detail/solid-principles)
[video](https://www.youtube.com/watch?v=rylaiB2uH2A&t=6321s)
## S - Single Responsibility Principle (SRP)
> A class should have only one reason to change. In other words, a class should only have one responsibility.
- A class should oonly have 1 reason/place where it can change.
- 	If a class has 2 places where it can change then it voilates s
- it can be reslved by splotting it into a SEPERATE class COVERT it to some business logic or service.

## O - Open/Closed Principle (OCP)
> Software entities should be open for extension but closed for modification. This means you should be able to add new functionality without altering existing code.
Superclass: Higher up class.
Subclass: Lower class. This inherits from the superclass.

 The issue (violation):
 - The code has to be edited in two places if you want to add a new feature.

- Encoursges abstraction and polymorphism to achieve this. inheritance or composition

1. Create an abstract class.
2. Create concrete classes that inherit from this abstract class.
	3. Each of these concrete classes will override the method from the abstract class, which allows the class to provide its own implementation.

What this solves:
- Now the Shape class does not need to be changed if a new shape is added (triangle).
- The code becomes loosely coupled and more maintainable.

## L - Liskov Substitution Principle (LSP)
> Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.
The problem (violation):
Similar class inherits from another class.

How its solved:
- Remove the complex inheritance (the 3rd level)
- Replace it to only have a 2nd level inheritance

## I - Interface Segregation Principle (ISP)
> Clients should not be forced to depend on interfaces they do not use.

- The client is simply the classes that are using the interface.

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
[video](https://www.youtube.com/watch?v=rylaiB2uH2A&t=6321s)

There are 3 categories of design patterns:
1. Creational
	- Singleton
2. Structural
	- Facade
	- Bridge
3. Behavioral
	- Command
	- Observer
	- Strategy

*Dependency injection


## Singleton
- A class of which only a single instance can exist
## Facade
- The primary objective of the Facade pattern is to provide a simplified interface to a complex subsyste, reducing client-side complexity.

## Bridge

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

# Dependency Injection
- You don’t instantiate stuff inside of a class, but outside of a class and then you give it to the class. Meaning, you inject the dependency of the class from outside.

# Classes, Constructors & Object Initializers

## Abstract Classes
- Abstract classes cannot be instantiated.

# Properties

# Interfaces
- Interfaces define contracts for behavior, but without implementing that behavior.

- An interface is a "can-do" relationship.
- Interfaces cannot be instantiated, but can be referenced.

> A class can implement multiple interfaces.


# Collections

``` cs
using System.Collections.Generic;
```
``` cs
// Observable collections for UI
```

## Arrays
``` cs
// Arrays
```

``` cs
// Generics
/* 
Generics provide a way to define classes, methods, 
and interfaces with a placeholder for the data type.
*/
class List<T>
{
    public T[] items {get; set;}
}
```

## Lists
``` cs
// Lists
/*
- Dynamic arrays
T is the generic type
*/
```



``` cs
// Dictionary
Dictionary<string, int> args = 
new Dictionary<string, int>
{
    {"Alice", 25}, {"Bob", 30}
};

Console.WriteLine(args["Alice"]);
// 25
```

## Queue




## Stack

## Hashset


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
> Operates on the rows. A Where operation results in the same # of columns but fewer rows.
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

## Combining Operations

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

Other LINQ queries:  
Contains:
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
- `IComparable` is an interface which can be used for sorting.
- You are forced to implment the `CompareTo()` method.

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

/* !!!!!!!! Preliminary Step: Install CSV helper with the NuGet command!!!!!! 
- In either case of a console application or Avalonia app,
you will need to check if CSVhelper exists in the .csproj file. 
*/

``` cs
// Step 1: Prepare the data
using CSVHelper;
using CsvHelper.Configuration.Attributes;

public class Comic
{
    [Name("Title")]
    public string Title { get; set; } = string.Empty;
    
    [Name("Author")]
    public string Author { get; set; } = string.Empty;
    
    [Name("ReleaseYear")]
    public int Year { get; set; }
}
```

``` cs
// Step 2: Read data using CsvReader
/*
Inputs:
- String filepath

Outputs:
- Data

*/



// Step 3 (optional): Write data using CsvWriter
```

## JSON

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



# MVC and MVVM

# MVVM Toolkit


# Data-Binding

Pre-check:
- The ViewModelBase.cs (located inside the ViewModels folder) should inherit from either observableobject or reactiveui




Bindings in the view follow:
- Capital (first letter/word and all words)

``` xml
<!-- In axaml view -->
<TextBlock Text="{Binding ProductName}" />
```

- Each viewmodel should inherit from viewmodelbase
```cs
// In ViewModel
[ObservableProperty]
private string _productName;
```

ObservableProperty or variables should start:
- Lowercase first letter/word, then uppercase for all words after. 


# Layout

# Styling and Animations

# Unit Testing and Avalonia Headless Testing
## Xunit
To setup Xunit testing:
- Have 2 folders
- 1 folder with the name of the other folder + .Tests

## Avalonia Headless Testing
[Avalonia Headless Testing](https://github.com/AvaloniaUI/Avalonia.Samples/tree/main/src/Avalonia.Samples/Testing/TestableApp.Headless.XUnit)

# Search and Sorting


# Multithreading
[video](https://www.youtube.com/watch?v=88e9uMlLCf8&t=1174s)

## Task
- `Task` is a class that is built upon threads (note: threads should never be used).

A task can be run using a function call or a lambda expression. In the case of the lambda expresion we just put whatever needs to be run inside there.

Simple task
Call `Task.Run()`

`task.Wait();`

### Task Exceptions


## Async and Await
By default programs are executed synchronously, if not specified,
By default (synchronous), when a computer reaches a task that is external it waits unril that task is completed, so that current thread just stops and waits.

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

## Locking
**Thread Safety**
- Code that can have race conditions is usually called "not thread-safe". Goal is to avoid potential race conditions. 

Locking is directly related to thread safety. Locking ensures that only one thread can ever enter this part of the code at the same time. So, multiple threads are coming, but as soon as one thread goes in there, no other threads are allowed.

### Dead Lock
- An issue can arrise with locking, which is called dead locks. How this happens is basically when you lock something with one thread and then lock another thing with the other thread and then lock the threads each other lock eachother and now they can never unlock.
- The easiest way to avoid it is by always locking in the same order (locks are inside of each other).



## Concurrent Collections
Include:
```cs
using System.Collections.Concurrent;
```

### Locking Collections
- Standard (generic) collections are not thread-safe for writing or enumeration. What this means is if you change a list for example, and you have another thread going through each item in the list (enumeration - for loop) and you change it in a different thread your program will either do something weird or will throw an exception.
    - This is done on purpose (why the collections are not thread-safe by default) as making a collection thread safe by locking is not for free. The disadvantage is that is makes it a little slower to compute. 

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
- We can manage concurrent asycnhronous operations by using `Task.WhenAll()`
- It allows you to execute multiple tasks at the same time and it waits for all of them to be finished.

Downsides:
- Runs in any order, which cant be tracked. The problem with this is that often processes have to executed in a certain order.
    - No exception handling feedback. It cannot be determined which task threw the exception.

It ok to use for:
- Fire and forget tasks, where the tasks can be executed in any order. It runs tasks in parallel. Saves time.

## Periodic Timer
- Used for when you want a task to occur for example every 5 seconds or every 5 hours. This could be a task that keeps downloading something or keeps updating something from a database.
    - The essential idea is that this task does not run the whole time but only does something every certain amount of time.
- Another use case is for it to be used to run work in the background and do updates all the time.

It is better to use a periodic timer instead of the traditoinal way where you would use a while true loop that waits for five milliseconds for example.
