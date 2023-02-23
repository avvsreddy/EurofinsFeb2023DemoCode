using System.Threading;
using System.Threading.Tasks;

namespace MTDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            Thread t2 = new Thread(() => { M2(100); });
            //Thread t3 = new Thread(M3);
            //Thread t4 = new Thread(M4);

            Task tt1 = new Task(M1);
            tt1.Start();

            Task ttt1 = Task.Factory.StartNew(M1);


            Task tt2 = new Task(() => { M2(100); });
            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();
            //a
            //b
            //c
            int r = tt3.Result;
            //sdfsdfsdf
            Task<int> tt4 = new Task<int>(() => { return M4(100); });

        }

        static void M1() { }
        static void M2(int i) { }
        static int M3() { return 1; }
        static int M4(int x) { return 0; }

        static void M5() { M2(100); }


    }
}
