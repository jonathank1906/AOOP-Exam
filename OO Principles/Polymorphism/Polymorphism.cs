// Base class
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("The animal makes a sound.");
    }
}

// Derived class 1
public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("The dog barks.");
    }
}

// Derived class 2
public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("The cat meows.");
    }
}

// Derived class 3
public class Cow : Animal
{
    public override void Speak()
    {
        Console.WriteLine("The cow moos.");
    }
}

// Program entry
public class Program
{
    public static void Main()
    {
        // Polymorphic list
        List<Animal> animals = new List<Animal>
        {
            new Dog(),
            new Cat(),
            new Cow()
        };

        // Loop through and call Speak() on each animal
        foreach (Animal animal in animals)
        {
            animal.Speak(); // Calls the overridden method based on the actual type
        }
    }
}