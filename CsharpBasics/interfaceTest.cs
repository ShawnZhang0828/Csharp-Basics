using System;

public interface MyInterface1
{

    // may have fields, but no constructors

    void method1();
    public void method2()
    {
        Console.WriteLine("Defautly call method 2");
    }
}

public interface MyInterface2
{

    // may have fields, but no constructors

    void method3();
    void method4();
}

public class MyClass1 : MyInterface1, MyInterface2
{
    public void method1()
    {
        Console.WriteLine("Class 1 calls method 1.");
    }

    public void method3()
    {
        Console.WriteLine("Class 1 calls method 3.");
    }

    public void method4()
    {
        Console.WriteLine("Class 1 calls method 4.");
    }
}

public class Class1Instance : MyClass1
{

}

/*                                          NOTE
 *  1. For both abstract classes and interfaces, if we don't provide an implementation for all methods,
 *  we have to declare the sub-class or implementation as abstract.
 * 
 *  2. If there is an interface A with a default implementation of a method, and there is an abstract class B
 *  with a concrete method, then a sub-class cannot access both the default implementation and the concrete method
 * 
 *  3. To check if we can cast an object to an interface type, use either "as" and check for null or "is"
 * 
 *  4. Bind the implementation of a specific class using InterfaceName.MethodName() {}
 * 
 *  5. Implement the ICloneable interface to make the class objects cloneable using .Clone() -> shallow copy,
 *  implement public object Clone() { return this.MemberwiseClone(); }
 *      - note the objects owned by the cloned class will be deep copied
 *      
 *  6. Implement the IComparable interface to make the objects comparable (sort, compare, etc.)
 *  implement int CompareTo() { return positive/zero/negative; }
 */