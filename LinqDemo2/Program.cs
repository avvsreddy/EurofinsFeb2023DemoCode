using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evens = (from n in numbers
                         where IsEven(n)
                         select n).ToList();

            numbers.Add(10);

            //foreach (var item in evens)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public static bool IsEven(int n)
        {
            Console.WriteLine("In IsEven");
            return (n % 2 == 0);
        }

        public static List<int> GetEvens(List<int> numbers)
        {
            var evens = (from n in numbers
                         where n % 2 == 0
                         select n).ToList(); ;
            return evens;
        }
    }
}
