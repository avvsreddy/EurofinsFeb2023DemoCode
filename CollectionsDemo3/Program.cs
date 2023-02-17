using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            //numbers.TrimExcess();
            Console.WriteLine($"Capacity: {numbers.Capacity}");
            Console.WriteLine($"Count: {numbers.Count}");
            int max = numbers.Max();
            int min = numbers.Min();
            double avg = numbers.Average();
            int sum = numbers.Sum();

            // Stacks
            Stack<int> stack = new Stack<int>();
            //add
            stack.Push(10);
            stack.Push(20);

            // read
            int a = stack.Pop();
            int b = stack.Peek(); ;

            // Queue
            Queue<int> queue = new Queue<int>();
            // add
            queue.Enqueue(10);
            queue.Enqueue(20);
            int x = queue.Dequeue();
            x = queue.Peek();

            // Hash Set
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2);
            Console.WriteLine(set.Count);

            // dictionary 
            Dictionary<int, string> results = new Dictionary<int, string>();
            results.Add(111, "Pass");
            results.Add(222, "Fail");
            //results.Add(222, "Pass");

            // read

            string res = results[222];


            Dictionary<int, string> days = new Dictionary<int, string>();
            days.Add(1, "Sunday");
            days.Add(2, "Monday");
            days.Add(3, "Tuesday");

            days.Add(7, "Saturday");

            Console.WriteLine(days[3]);

            Dictionary<int, List<Dictionary<int, string>>> results1 = new Dictionary<int, List<Dictionary<int, string>>>();

            days.ContainsKey(1);

        }
    }
}
