/* 
    <--- Note these concepts --->
    default constructor (with no input), constructor chaining (Animal() : this(params) {}),
    keywords: static (data shared by all instances), static constructor (unknown value at compile time),
              static class (only contain static members),
    overriding: child class has methods with same name, but different implementation,
    access modifiers: public, private, protected, internal, protected internal,
    C# property syntax for getter and setter (add modifier, write/read-only),
    constants, readonly, partial, 
 */

abstract class Animals
{
    private string name;
    private int age;

    public Animals()
    {
        Name = "ShaB";
        Age = 1;
    }

    public Animals(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get { return name; } set { name = value; } }
    public int Age { get { return age; } set { age = value; } }

    // need the virtual keyword if not abstract classes
    public abstract void speak();

    public void fight(Animals animalB)
    {
        Console.WriteLine("{0} fights {1}", Name, animalB.Name);
    }
}

// sealed: prevents the class from being extended
//         - can also seal overriden methods to prevent them from being overriden again
class Dog : Animals
{
    // Object containment -> using a function/property of the object is called delegation
    public BodyPart tail = new BodyPart("tail");

    public Dog(string name, int age) : base(name, age) { }

    // Shadowing: using the same signature without override keyword (resolve using override or new)
    public override void speak()
    {
        Console.WriteLine("Wooof! I have a {0}", tail.Name);
    }
}

// must be declared as abstract if not implementing all the abstract methods
abstract class Cat : Animals
{
    public Cat(string name, int age) : base(name, age) { }
}

class BodyPart
{
    private string name;

    public string Name { get { return name; } set { name = value; } }

    public BodyPart(string name)
    {
        Name = name;
    }
}

/*
    Nested types allows us to gain complete control over the access level of the inner type
    Inner classes are meant to be the helper of the outer classes
 */

