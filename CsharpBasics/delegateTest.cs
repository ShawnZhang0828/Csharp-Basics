using System;

/*                                          NOTE
 *  Definition: type-safe object that points to another method (or a list of methods) in the application, which
 *              can be invoked at a later time
 *  Kept information: 1. address of the method on which it makes calls
 *                    2. arguments of this method
 *                    3. return value of this method
 *  Can cast the return value for a delegate up or down
 *  Can make the delegate general by specifying public delegate void <DelegateName><T>(T arg)
 */ 


public class MathOperation
{
    // this can also be passed to class methods as parameters
    public delegate void RandomDelegate(int output);

    private RandomDelegate randomDelegateList;

    public void onOperation(RandomDelegate randomDelegate)
    {
        randomDelegateList += randomDelegate;
    }

    public int Add(int x, int y)
    {
        if (randomDelegateList != null)
        {
            randomDelegateList(x + y);
        }
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        if (randomDelegateList != null)
        {
            randomDelegateList(x + y);
        }
        return x - y; 
    }
}

public class Car
{
    // public delegate void CarEventHandler(string msg);
    public delegate void CarEventHandler(object sender, CarEventArgs e);

    // public event EventHandler<CarEventArgs> exploded;
    public event CarEventHandler exploded;
    public event CarEventHandler aboutToExplode;

    private bool carIsDead;
    private int speed;

    public Car()
    {
        carIsDead = false;
        speed = 0;
    }

    public void accelerate(int delta)
    {
        if (carIsDead)
        {
            if (exploded != null)
            {
                // exploded("this car is dead");
                exploded(this, new CarEventArgs("this car is dead"));
            }
        }
        else
        {
            speed += delta;

            if (10 == 100 - speed && aboutToExplode != null)
            {
                aboutToExplode(this, new CarEventArgs("this car is about to die"));
            }

            if (speed > 100)
            {
                carIsDead = true;
            }
            else
            {
                Console.WriteLine("speed up to {0}", speed);
            }
        }
    }
}

public class CarEventArgs : EventArgs
{
    public readonly string msg;
    public CarEventArgs(string msg)
    {
        this.msg = msg;
    }
}
