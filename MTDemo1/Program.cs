using System;
using System.Diagnostics;
using System.Threading; // Classic MT
using System.Threading.Tasks;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Running seq...");
            Stopwatch sw = Stopwatch.StartNew();
            M1();
            M2();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine("Using Classic Thread");
            sw = Stopwatch.StartNew();

            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            Thread t2 = new Thread(M2);
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Using TPL-Task");
            sw = Stopwatch.StartNew();
            Task task1 = new Task(M1);
            task1.Start();
            Task task2 = new Task(M2);
            task2.Start();
            task1.Wait();
            task2.Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Using TPL-Parallel");
            sw = Stopwatch.StartNew();
            Parallel.Invoke(M1, M2);
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.WriteLine("Using TPL-Parallel-For");
            sw = Stopwatch.StartNew();
            Parallel.Invoke(M11, M22);
            Console.WriteLine(sw.ElapsedMilliseconds);

        }
        static void M1()
        {
            Console.WriteLine($"M1: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }

        static void M2()
        {
            Console.WriteLine($"M2: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }

        static void M11()
        {
            Console.WriteLine($"M11: {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++) // seq for
            Parallel.For(1, 11, i =>
            {
                Thread.Sleep(500);
            });
        }

        static void M22()
        {
            Console.WriteLine($"M22: {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            Parallel.For(1, 11, delegate (int i)
            {
                Thread.Sleep(500);
            });
        }
    }
}
