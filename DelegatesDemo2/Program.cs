using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client 1
            ProcessManager.ShowProcrssList(NoFilter);
            ProcessManager.ShowProcrssList(p => true);
            // client 2
            //FilterDelegate filter = new FilterDelegate(FilterByName);
            //ProcessManager.ShowProcrssList(filter);
            //client 3
            //ProcessManager.ShowProcrssList(FilterByMemSize);

            // Anonymous Delegates
            ProcessManager.ShowProcrssList(delegate (Process process)
            {
                return process.WorkingSet64 >= 50 * 1024 * 1024;
            });

            // Lambdas => Light Weight Syntax for Anonymous Delegates
            // Lambda 
            // 1. Lambda Statements
            // 2. Lambda Expressions
            ProcessManager.ShowProcrssList((Process process) =>
                 process.WorkingSet64 >= 50 * 1024 * 1024
            );

            ProcessManager.ShowProcrssList(process =>
                process.WorkingSet64 >= 50 * 1024 * 1024
           );
            // Lambda Expressions
            ProcessManager.ShowProcrssList(x => x.WorkingSet64 >= 50 * 1024 * 1024);


        }

        // client 1
        public static bool NoFilter(Process p)
        {
            return true;
        }
        // client 2
        public static bool FilterByName(Process process)
        {
            //return process.ProcessName.StartsWith("S");
            if (process.ProcessName.StartsWith("S"))
                return true;
            else
                return false;
        }
        //client 3
        //public static bool FilterByMemSize(Process process)
        //{
        //    return process.WorkingSet64 >= 50 * 1024 * 1024;
        //}
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
