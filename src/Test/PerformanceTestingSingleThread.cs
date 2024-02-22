using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test;

internal class PerformanceTestingSingleThread
{
    public void Call()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch = Stopwatch.StartNew();
        EvenNumber();
        OddNumber();
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
