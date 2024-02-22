using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test;

internal class ManualResetEventClass
{
    private static ManualResetEvent manualEvent = new ManualResetEvent(false);
    public void Call()
    {
        var thread = new Thread(CheckTheThread)
        {
            IsBackground = true,
        };

        thread.Start();

        Console.ReadLine();

        manualEvent.Set();
    }

    void CheckTheThread()
    {
        Console.WriteLine("Entering in to the Thread check method.....");
        manualEvent.WaitOne();
        Console.WriteLine("Closing the Thread check method.....");
        Console.ReadLine();
    }
}
