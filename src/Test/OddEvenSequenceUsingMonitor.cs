namespace Test;

internal class OddEvenSequenceUsingMonitor
{
    private static readonly object _lock = new object();
    private static readonly int number = 20;

    public void Call()
    {
        Thread even = new Thread(EvenNumber);

        Thread odd = new Thread(OddNumber);
        even.Start();

        //Stop Main Thread for 100 ms
        Thread.Sleep(100);

        odd.Start();

        even.Join();
        odd.Join();
        Console.Read();
    }

    void EvenNumber()
    {
        try
        {
            Monitor.Enter(_lock);
            for (int i = 0; i <= number; i = i + 2)
            {
                Console.Write($"{i} ");


                //Notify other thread to complete the task then 
                Monitor.Pulse(_lock);

                if(!(i == number))
                    //Wait here until other group of threads notification
                    Monitor.Wait(_lock);
            }
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }

    void OddNumber()
    {
        try
        {
            Monitor.Enter(_lock);
            for (int i = 1; i <= number; i = i + 2)
            {
                Console.Write($"{i} ");


                //Notify other thread to complete the task then 
                Monitor.PulseAll(_lock);

                if (!(i == number - 1))
                    //Wait here until other group of threads notification
                    Monitor.Wait(_lock);
            }
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
}
