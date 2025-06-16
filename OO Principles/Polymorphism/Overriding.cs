class Base
{
    public virtual void Foo()
    {
        Console.WriteLine("Base.Foo called");
    }
}

class Derived : Base
{
    public override void Foo()
    {
        Console.WriteLine("Derived.Foo called");
    }
}

class Test2
{
    public static void Main()
    {
        Base x = new Derived();
        x.Foo();
    }
}