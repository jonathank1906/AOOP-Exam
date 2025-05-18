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
---

**Interfaces** define contracts for behavior, but without implementing that behavior.
- Interfaces
- Interfaces are indicated by the 'inteface' keyword.



# Design Patterns
---

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


