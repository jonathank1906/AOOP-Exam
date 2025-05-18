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
*/
```

