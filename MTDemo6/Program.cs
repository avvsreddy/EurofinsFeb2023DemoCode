using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MTDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigData data = new BigData();
            //data.Fill();
            //data.Fill();
            Parallel.Invoke(data.Fill, data.Fill);
            System.Console.WriteLine(data.Count);

        }
    }

    public class BigData
    {
        //private Stack<int> stack = new Stack<int>();
        private ConcurrentStack<int> stack = new ConcurrentStack<int>();
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Fill()
        {
            // Fill a million numbers
            for (int i = 1; i <= 1000000; i++)
            {
                //lock (this)
                //{
                //Monitor.Enter(this);
                //sddfsdf
                stack.Push(i);
                //sdfsdf
                //Monitor.Exit(this);
                //}

            }
        }
        public long Count
        {
            get { return stack.Count; }
        }
    }
}
