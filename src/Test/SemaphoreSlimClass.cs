namespace Test;

internal class SemaphoreSlimClass
{
    // Create the semaphore.
    private static SemaphoreSlim semaphore = new SemaphoreSlim(0, 3);

    // A padding interval to make the output more orderly.
    private static int padding;

    public void Call()
    {
        Console.WriteLine($"{semaphore.CurrentCount} tasks can enter the semaphore");
        Task[] tasks = new Task[5];

        // Create and start five numbered tasks.
        for (int i = 0; i <= 4; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                Console.WriteLine($"Task {Task.CurrentId} begins and waits for the semaphore");

                int semaphoreCount;
                semaphore.Wait();
                try
                {
                    Interlocked.Add(ref padding, 100);
                    Console.WriteLine($"Task {Task.CurrentId} enters the semaphore");
                    // The task just sleeps for 1+ seconds.
                    Thread.Sleep(50000 + padding);
                }
                finally
                {
                    semaphoreCount = semaphore.Release();
                }
                Console.WriteLine($"Task {Task.CurrentId} releases the semaphore; previous count: {semaphoreCount}");
            });
        }

        // Wait for one second, to allow all the tasks to start and block.
        Thread.Sleep(1000);

        // Restore the semaphore count to its maximum value.
        Console.Write("Main thread calls Release(3) --> ");
        semaphore.Release(3);
        Console.WriteLine($"{semaphore.CurrentCount} tasks can enter the semaphore");
        // Main thread waits for the tasks to complete.
        Task.WaitAll(tasks);

        Console.WriteLine("Main thread Exits");
        Console.ReadKey();
    }
}
