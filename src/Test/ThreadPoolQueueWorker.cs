namespace Test;

internal class ThreadPoolQueueWorker
{
    public void Call()
    {
        foreach (var item in Enumerable.Range(0, 10))
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintThreadDetails));
        }
        Console.Read();
    }

    static void PrintThreadDetails(object? data)
    {
        Thread thread = Thread.CurrentThread;
        Console.WriteLine($"Thread Id: {thread.ManagedThreadId}  Name: {thread.Name}  IsBeckGround: {thread.IsBackground}");
    }
}
