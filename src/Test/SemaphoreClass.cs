namespace Test;

internal class SemaphoreClass
{
    public void Call()
    {
        Semaphore? semaphore = new Semaphore(2, 3, "Test");


        Console.WriteLine("External Thread Trying to Acquiring");
        semaphore.WaitOne();

        //This section can be access by maximum two external threads: Start
        Console.WriteLine("External Thread Acquired");
        Console.ReadKey();

        //This section can be access by maximum two external threads: End
        semaphore.Release();
    }
}
