using System;

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
        Console.WriteLine("{0} grows to {1} years old.", name, age);
    }
}

class TestApp {

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
        string[] stringArray = {"one", "two", "three"};
        object[] objectArray1 = new object[4];
        object[,] objectArray2= new object[4,4];        // rectangular multi-dimensional array
        object[][] objectArray3 = new object[5][];      // jagged multi-dimensional array
        // Note the system.Array class (clear, sort, reverse, etc.)
    }

    static void enumTest()
    {
        Console.WriteLine("\n======== Testing Enum Class ========");
        LetterEnum letter = LetterEnum.a;
        Console.WriteLine((int) letter);
    }

    static void structTest()
    {
        Console.WriteLine("\n======== Testing Struct ========");
        Animal dog = new Animal("BYellow", 6);
        dog.grow();
    }


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
    }
}