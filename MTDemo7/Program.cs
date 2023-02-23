using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
        }

        static void M1()
        {
            int pcount = Environment.ProcessorCount;
            ParallelOptions opts = new ParallelOptions();
            opts.MaxDegreeOfParallelism = pcount / 2;

            HashSet<int> list = new HashSet<int>();
            Object obj = new object();
            Parallel.For(1, 100, opts, i =>
            {
                lock (obj)
                {
                    list.Add(Thread.CurrentThread.ManagedThreadId);
                }
                // sdfsdfd
                // sdfsdfsdf
            });
            Console.WriteLine(list.Count);
        }
    }
}
