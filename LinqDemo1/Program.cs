using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LINQ to Objects
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // extract all even numbers into separate list
            // traditionally
            List<int> evens1 = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                    evens1.Add(number);
            }
            foreach (var item in evens1)
            {
                Console.WriteLine(item);
            }

            // using linq expression

            // sql: select n from numbers where n mod 2 = 0 order by n desc;
            // table: numbers
            // column: n
            var evens2 = from n in numbers
                         where n % 2 == 0
                         orderby n descending
                         select n;

            // using linq extensions

            var evens3 = numbers.Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .Select(n => n);
        }
    }
}
