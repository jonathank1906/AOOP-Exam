using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Dog dog1 = new Dog();
		dog1.Sleep();
		dog1.MakeSound();
	}
}

abstract class Animal
{
    // Abstract method (no implementation)
    public abstract void MakeSound();

    // Implemented method
    public void Sleep()
    {
        Console.WriteLine("Zzz...");
    }
}

class Dog : Animal
{
    public override void MakeSound() // Must implement
    {
        Console.WriteLine("Bark!");
    }
}