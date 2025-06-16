class Test
{
    static void Foo(object a)
    {
        Console.WriteLine("Object overload called");
    }

    static void Foo(string a)
    {
        Console.WriteLine("String overload called");
    }

    public static void Main()
    {
        object x = "hello";
        Foo(x);
    }
}