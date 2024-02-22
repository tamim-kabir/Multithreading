namespace Test;

internal class MonitorClass
{
    private static readonly object _lock = new object();
    public void Call()
    {
        Thread thread1 = new Thread(PrintDisplay)
        {
            Name = "Thread 1"
        };
        Thread thread2 = new Thread(PrintDisplay)
        {
            Name = "Thread 2"
        };
        Thread thread3 = new Thread(PrintDisplay)
        {
            Name = "Thread 3"
        };

        thread1.Start(1);
        thread2.Start(2);
        thread3.Start(3);
    }

    void PrintDisplay(object? i)
    {
        bool isLocked = false;
        try
        {
            Monitor.Enter(_lock, ref isLocked);
            if (isLocked)
            {
                Console.WriteLine($"{i} Before");
                Thread.Sleep(1000);
                Console.WriteLine(" After");
            }
        }
        finally
        {
            if (isLocked)
                Monitor.Exit(_lock);
        }
    }
}
