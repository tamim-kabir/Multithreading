namespace Test;

internal class ThreadPriorityClss
{
    public void Call()
    {
        var thread = new Thread(Display)
        {
            Name = "Thread 1",
            Priority = ThreadPriority.BelowNormal,
        };
        var thread2 = new Thread(Display)
        {
            Name = "Thread 2",
            Priority = ThreadPriority.Normal,
        };
        var thread3 = new Thread(Display)
        {
            Name = "Thread 3",
            Priority = ThreadPriority.AboveNormal,
        };
        var thread4 = new Thread(Display)
        {
            Name = "Thread 4",
            Priority = ThreadPriority.Highest,
        };
        var thread5 = new Thread(Display)
        {
            Name = "Thread 4",
            Priority = ThreadPriority.Lowest,
        };

        thread5.Start();
        thread.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

    }
    static void Display()
    {
        Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name} and Priority: {Thread.CurrentThread.Priority}");
    }
}
