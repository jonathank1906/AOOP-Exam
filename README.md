# AOOP-Exam

# Table of contents
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

Implemented using:

- Interfaces

## Encapsulation

Implemented using:

- Properties
- Access modifiers

## Inheritance

## Polymorphism

Implemented using:

- Interfaces
- Types


# Interfaces

**Interfaces** define contracts for behavior, but without implementing that behavior.
- Interfaces
- Interfaces are indicated by the 'inteface' keyword.



# Design Patterns

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
Dependency injection


## Singleton

## Facade

## Bridge

## Command
- Is part of the MVVM toolkit
## Observer
- It can be implemented both with and without MVVM toolkit.
	- There is also a basic one.
- It is a UI design pattern
- The observer pattern is present behind anything that involves data binding.

## Dependency Injection
- You don’t instantiate stuff inside of a class, but outside of a class and then you give it to the class. Meaning, you inject the dependency of the class from outside.


# Parsing JSON and CSV
``` cs
/* !!!!!!!! Preliminary Step: Install CSV helper with the NuGet command!!!!!! 
- In either case of a console application or Avalonia app,
you will need to check if CSVhelper exists in the .csproj file. 
*/


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

// Step 2: Read data using CsvReader
/*
Inputs:
- String filepath

Outputs:
- Data

*/



// Step 3 (optional): Write data using CsvWriter
```


# LINQ
What is a Query?
- Stands for Language Integrated Query
- Used for data manipulation.
- A query is essentially a question you ask about your data set about. It 
has to be in a certain order that you formulate the quesstion.
If there is x amount of students enrolled in a
a class/ 

They can be applied to Lists, databases.....

A dataset can be seen below
- The rows represent single objects inside of the collection
- The columns represent the fields of the objects.

``` cs
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}

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

Two syntaxes for LINQ queries:
1. Method chaining
2. Query syntax
* You can always mix these syntaxes in your code. No restrictions on that!

**Method Chaining Syntax**
- Uses a . before the LINQ method (where, orderby, select, etc.)
``` cs
var output = books.Where(condition)  
                  .OrderBy(property)  
                  .Select(property);
```
**LINQ Query Syntax**
- Query must end with a Select or Group clause.

``` cs
var output = from b in books  
                    where condition  
                    orderby property  
                    select property;
```

### **Where**  
"Give me the items from this list WHERE my condition is met"
- Used for SELECTION filtering
- Looks at the rows
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

### **Select**
- Projection:
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

### **OrderBy, OrderByDescending, ThenBy**  (Sorting) 
Sort in ascending or descending order
- The fields must be int, double, float, etc: smallest to largest for example
- string alphabetical order maybe

OrderBy - Ascending order
OrderByDescending - Descending order
ThenBy

``` cs
//.ToList() // Execute it now.
```

### **Sum, Average, Min, Max, Count** (Aggregation)

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

### **GroupBy**  
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

### **Combining Operations**

2. Get the average price of each group

``` cs
### **Combining Operations**

2. Get the average price of each group
```

# Collections

``` cs
using System.Collections.Generic;


// Observable collections for UI

// Arrays


// -----------------------------


// Generics
/* 
Generics provide a way to define classes, methods, 
and interfaces with a placeholder for the data type.
*/
class List<T>
{
    public T[] items {get; set;}
}




// Lists
/*
- Dynamic arrays
T is the generic type
*/





// Dictionary
Dictionary<string, int> args = 
new Dictionary<string, int>
{
    {"Alice", 25}, {"Bob", 30}
};

Console.WriteLine(args["Alice"]);
// 25

// Queue




// Stack

// Hashset
```

# Data-Binding

Pre-check:
- The ViewModelBase.cs (located inside the ViewModels folder) should inherit from either observableobject or reactiveui
- Each viewmodel should inherit from viewmodelbase



Bindings in the view follow:
- Capital (first letter/word and all words)

The ObservableProperty or variables should start:
- Lowercase first letter/word, then uppercase for all words after. 
