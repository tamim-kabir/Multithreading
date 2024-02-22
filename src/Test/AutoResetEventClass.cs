using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test;

internal class AutoResetEventClass
{
    private static AutoResetEvent resetEvent = new AutoResetEvent(false);
    public void Call()
    {
        var thread = new Thread(CheckTheThread)
        {
            IsBackground = true,
        };

        thread.Start();

        Console.ReadLine();

        resetEvent.Set();
    }

    void CheckTheThread()
    {
        Console.WriteLine("Entering in to the Thread check method.....");
        resetEvent.WaitOne();
        Console.WriteLine("Closing the Thread check method.....");
        Console.ReadLine();
    }
}
