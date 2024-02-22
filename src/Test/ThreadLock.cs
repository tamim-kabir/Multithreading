namespace Test;

internal class ThreadLock
{
    private static readonly object _Lock = new object();
    public void Call()
    {
        Thread thread1 = new Thread(SharedResource)
        {
            Name = "Thread 1"
        };
        Thread thread2 = new Thread(SharedResource)
        {
            Name = "Thread 2"
        };
        Thread thread3 = new Thread(SharedResource)
        {
            Name = "Thread 3"
        };
        thread1.Start();
        thread2.Start();
        thread3.Start();
    }
    void SharedResource()
    {
        lock (_Lock)
        {
            Console.WriteLine("Before ");
            Thread.Sleep(1000);
            Console.WriteLine("After ");
        }
    }
}
