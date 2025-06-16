using System;

// Base class
public class Animal
{
    public string Name { get; set; }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

// Interfaces
public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

// Derived class: Bird
public class Bird : Animal, IFlyable
{
    public void Fly()
    {
        Console.WriteLine($"{Name} is flying.");
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} chirps.");
    }
}

// Derived class: Duck
public class Duck : Animal, IFlyable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine($"{Name} flaps its wings and flies.");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} swims in the pond.");
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} quacks.");
    }
}

// Derived class: Fish
public class Fish : Animal, ISwimmable
{
    public void Swim()
    {
        Console.WriteLine($"{Name} swims in the water.");
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} makes bubbling sounds.");
    }
}

// Test program
public class Program
{
    public static void Main()
    {
        Bird bird = new Bird { Name = "Sparrow" };
        bird.MakeSound();
        bird.Fly();

        Duck duck = new Duck { Name = "Daffy" };
        duck.MakeSound();
        duck.Fly();
        duck.Swim();

        Fish fish = new Fish { Name = "Nemo" };
        fish.MakeSound();
        fish.Swim();
    }
}
