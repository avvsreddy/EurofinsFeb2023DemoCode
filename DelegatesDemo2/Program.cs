using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client 1
            //ProcessManager.ShowProcrssList();
            // client 2
            FilterDelegate filter = new FilterDelegate(FilterByName);
            ProcessManager.ShowProcrssList(filter);
            //client 3
            //ProcessManager.ShowProcrssList(23234234234);
            //ProcessManager.ShowProcrssList();
        }
        // client 2
        public static bool FilterByName(Process process)
        {
            return process.ProcessName.StartsWith("S");
        }
        //client 3
        public static bool FilterByMemSize(Process process)
        {
            return process.WorkingSet64 >= 50 * 1024 * 1024;
        }
    }

    public delegate bool FilterDelegate(Process p);

    class ProcessManager
    {

        public static void ShowProcrssList(FilterDelegate filter)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (filter(process))
                    System.Console.WriteLine(process.ProcessName);
            }
        }

    }
}
