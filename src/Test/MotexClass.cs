namespace Test;

internal class MotexClass
{
    public void Call()
    {
        using var motex = new Mutex(false, "Test");
        if(!motex.WaitOne(5000, false))
        {
            Console.WriteLine("An Application Instance is running");
            Console.Read();
            return;
        }
        
        Console.WriteLine("Application Is Running....");
            Console.Read();
    }
}
