namespace Test;

internal class JoinThread
{
    public void Call()
    {
        Thread thread1 = new Thread(Method1);
        Thread thread2 = new Thread(Method2);
        Thread thread3 = new Thread(Method3);

        

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Main Thread End");
    }
    static void Method1()
    {
        Console.WriteLine("Method1");
        Thread.Sleep(1000);
    }
    static void Method2()
    {
        Console.WriteLine("Method2");
        Thread.Sleep(1000);
    }
    static void Method3()
    {
        Console.WriteLine("Method3");
        Thread.Sleep(1000);
    }

}
