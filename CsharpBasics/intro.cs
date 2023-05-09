using System;
using System.Collections;   // includes ICollection, IComparer, IDictionary, IDictionaryEnumerator,
// IEnumerable, IEnumerator, IHashCodeProvider, IList

// includes ArrayList, HashTable, Queue, SortedList, Stack

enum LetterEnum
{
    a = 10,
    b = 20,
    c = 30,
    d = 40
}

struct Animal
{
    public String name;
    public int age;

    public Animal(String name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void grow()
    {
        age++;
        Console.WriteLine("{0} is now {1} years old.", name, age);
    }
}

class TestApp
{

    class DogHouse
    {
        public Dog[] dogs = new Dog[4];

        public DogHouse()
        {
            dogs[0] = new Dog("a", 1);
            dogs[1] = new Dog("b", 2);
            dogs[2] = new Dog("c", 3);
            dogs[3] = new Dog("d", 4);
        }
    }

    static void varTest()
    {
        Console.WriteLine("\n======== Testing Variable Types ========");
        char c = 'a';
        Console.WriteLine(c);
        string s = "true";
        bool b = bool.Parse(s);
        Console.WriteLine(b);
        Console.WriteLine(@"zero line
            first line
                second line
                    third line");
        /*
            <--- this section also includes: --->
            string builder, date time and time spans, 
            narrowing and widening data types -> check/uncheck,
         */
    }

    /*
        <--- also talks about: --->
        loops (for, foreach, while, do while),
        conditional statements (if/else, switch)
            - switch (n) {case x: }
     */

    static void funcTest1(out int intAns, out string strAns)
    {
        Console.WriteLine("\n======== Testing Functions ========");
        intAns = 1;
        strAns = "2345";
        // use ref rather than out to pass an actual reference to the variables
        // use params to input an array of data with unlimited size
        // e.g., double average(params double[] values);    average(1.2, 3,9, 8.3, 0.3);
        // overloading: creating methods with the same name but different signatures
        // e.g., int Add(int x, int y);     
    }

    static void arrayTest()
    {
        string[] stringArray = { "one", "two", "three" };
        object[] objectArray1 = new object[4];
        object[,] objectArray2 = new object[4, 4];        // rectangular multi-dimensional array
        object[][] objectArray3 = new object[5][];      // jagged multi-dimensional array
        // Note the system.Array class (clear, sort, reverse, etc.)
    }

    static void enumTest()
    {
        Console.WriteLine("\n======== Testing Enum Class ========");
        LetterEnum letter = LetterEnum.a;
        Console.WriteLine((int)letter);
    }

    static void structTest()
    {
        Console.WriteLine("\n======== Testing Struct ========");
        Animal dog = new Animal("BYellow", 6);
        dog.grow();
    }

    /*
        <--- also talks about: --->
        value types (extends obejct/struct - copy) and reference types (classes - alias),
        nullable types (?? operator to assign default values)
     */

    static void classCastingTest()
    {
        Console.WriteLine("\n======== Class Casting Struct ========");
        // Dog dog = new Animal(); doesnt work
        Animals dog = new Dog("WangCai", 5);
        object cat = new Dog("ChouJuanBao", 3);
        /*
         * cast cat to an Animal since an object may not be an animal
         * use Dog dog2 = cat as Dog to test for casting compatability
         * is keyword
         */
        dog.fight((Dog)cat);
    }

    static void errorHandlingTest()
    {
        // Console.WriteLine();
        /*      <--- Things to Note --->
         *  throw new Exception({message});
         *  try {} 
         *  catch(Exception1 e1) 
         *      {Console.WriteLine(e.TargetSite)} 
         *  catch(Exception2 e2) 
         *      {Handling}
         *  finally
         *      {will always be executed}
         *  TargetSite.MemberType/DeclaringType
         *  System-level exception and Application-level exception
         */
    }

    static void objectLifetimeTest()
    {
        /*      <--- Things to Note --->
         *  garbage collector disposes of an object if it is unreachable by any part of the code
         *  garbage collector examines objects in terms of their likelyhood to be used:
         *      - given by the assumption that the longer an object exists, the more likely it will be used again
         *      - generation 0: recently added -> generation 2: added long enough
         */
    }

    static void interfaceTest()
    {
        Console.WriteLine("\n======== Interface Testing ========");
        MyInterface1 myClass1 = new MyClass1();
        myClass1.method1();
        myClass1.method2();
    }

    static void classEnumerationTest()
    {
        Console.WriteLine("\n======== Class Enumeration Testing ========");

        DogHouse dogHouse = new DogHouse();

        /*          NOTE
         *  -> implement IEnumerator for DogHouse <-
         *  pulbic IEnumerator GetEnumerator()
         *  {
         *      return dogs.GetEnumerator();
         *  }
         *  ==> then, we can do foreach(Dog dog in dogHouse)
         *  
         *  -> alternatively <-
         *  pulbic IEnumerator GetEnumerator()
         *  {
         *      foreach (Dog dog in dogs)
         *      {
         *          yield return dog;
         *      }
         *  }
         */
        foreach (Dog dog in dogHouse.dogs)
        {
            Console.WriteLine("{0} is {1} years old", dog.Name, dog.Age);
        }
    }

    static void collectionTest()
    {
        /*                      NOTE
         *  Boxing: put primitive variables into project - define a new variable of type object
         *  Unboxing: cast objects to primitive variables
         *      - sometimes (un)boxing happens automatically, like in WriteLine, primitive variables will be converted to objects
         * 
         *  Can implement the IEnumerable interface to associated a specific type with an arraylist
         * 
         * 
         *  Avoid overhead of boxing/unboxing using the generic collection: ArrayList<int>();
         *  
         *  ************************ IMPORTANT ************************
         *  ************************  GENERIC  ************************
         *  class MyClass<T> {}; MyClass<string> c1 = new MyClass<string>();    
         *      ^^ in this way, we can substitute "string" to every appearance of T in the class
         *      
         *  1. T can be any defined types, we can use it to represent a specific family of classes
         *  
         *  2. We can also define generic types for methods, it will have the same effect
         *  
         *  3. Use default(T) to obtain the default value for a generic type
         *  
         *  4. Use where keyword to constraint the generic type
         *      - where T : struct/class/new() - have a default constructor/NameOfBaseClass/NameOfInterface
         */
        ArrayList myArrayList = new ArrayList();
        myArrayList.Add(10);

        short i = (short)myArrayList[0];
    }

    // Functions for delegate testing
    static void callbackFunc1(int output)
    {
        Console.WriteLine("The result is {0}", output);
    }

    static void callbackFunc2(int output)
    {
        Console.WriteLine("Again, the result is {0}", output);
    }


    // static void callbackFunc3(string msg)
    static void callbackFunc3(object sender, CarEventArgs e)
    {
        Console.WriteLine(e.msg);
    }

    static void delegateTest()
    {
        Console.WriteLine("\n======== Delegate Testing ========");

        MathOperation mo = new MathOperation();
        mo.onOperation(new MathOperation.RandomDelegate(callbackFunc1));
        mo.onOperation(new MathOperation.RandomDelegate(callbackFunc2));
        mo.Add(10, 10);
    }

    static void eventTest()
    {
        Console.WriteLine("\n======== Event and Delegate Testing ========");

        Car myCar = new Car();
        // myCar.aboutToExplode += new EventHandler<CarEventArgs>(callbackFunc3);
        myCar.aboutToExplode += new Car.CarEventHandler(callbackFunc3);
        myCar.exploded += new Car.CarEventHandler(callbackFunc3);

        // we can also add a delegate like the following:
        // note anoynomous functions can access outer variables
        myCar.aboutToExplode += delegate(object sender, CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        };

        // another way to add a delegate using method group conversion
        myCar.aboutToExplode += callbackFunc3;

        // we can also use a LAMBDA EXPRESSION
        // Difference between lambda and anonymous function
        // 1. syntax 2. compiler can infer the type for lambda parameters 3. Usage
        myCar.exploded += (object s, CarEventArgs e) => { Console.WriteLine(e.msg); };

        for (int i = 0; i < 12; i++)
        {
            myCar.accelerate(10);
        }

    }

    /*          NOTE FOR NDEXERS, OPERATORS, POINTERS
     *  Allowed to overload indexing, and binary operations
     */ 

    static void Main(string[] args)
    {
        foreach (string arg in args)
        {
            Console.WriteLine(arg);
        }

        Console.WriteLine("ppp format: {0:E}", 9999);

        varTest();
        int ans1;
        string ans2;

        funcTest1(out ans1, out ans2);
        Console.WriteLine(ans1 + ans2);

        enumTest();

        structTest();

        Animals dog = new Dog("WangCai", 5);
        dog.speak();

        classCastingTest();

        interfaceTest();

        classEnumerationTest();

        delegateTest();

        eventTest();
    }
}