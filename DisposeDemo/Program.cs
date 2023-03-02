using System;

namespace DisposeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BigData b = new BigData())
            {

            }
            //b.Close();
            Console.WriteLine("End of app");
        }
    }

    class BigData : IDisposable
    {
        public BigData()
        {
            Console.WriteLine("Big Memory allocated");
        }

        public void M1() { }
        public void M2() { }

        public void Close()
        {
            Console.WriteLine("closing memory");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing the big data object");
            GC.SuppressFinalize(this);
        }

        ~BigData()
        {
            Console.WriteLine("Big Memory deallocated");
        }
    }
}
