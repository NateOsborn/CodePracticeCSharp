class Car
{
    public void fullThrottle()
    {
        Console.WriteLine("The car is going as fast as it can!");
    }

    static void Main(string[] args)
    {
        Car myObj = new Car();
        myObj.fullThrottle();
    }
}