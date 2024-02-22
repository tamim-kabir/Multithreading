using System.Diagnostics;

namespace Test;

internal class PerformanceTestingMultipleThread
{
    public void Call()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch = Stopwatch.StartNew();
        Thread thread1 = new Thread(EvenNumber);
        Thread thread2 = new Thread(OddNumber);
        
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        stopwatch.Stop();
        Console.WriteLine($"Total time in milliseconds : {stopwatch.ElapsedMilliseconds}");
        Console.ReadKey();
    }

    void EvenNumber()
    {
        double Evensum = 0;
        for (int count = 0; count <= 50000000; count++)
        {
            if (count % 2 == 0)
            {
                Evensum = Evensum + count;
            }
        }
        Console.WriteLine($"Sum of even numbers = {Evensum}");
    }

    void OddNumber()
    {
        double Oddsum = 0;
        for (int count = 0; count <= 50000000; count++)
        {
            if (count % 2 == 1)
            {
                Oddsum = Oddsum + count;
            }
        }
        Console.WriteLine($"Sum of odd numbers = {Oddsum}");
    }
}
