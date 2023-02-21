using System.Collections.Generic;
using System.Linq;

namespace LambdasDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // find the sum of all even numbers
            //Func<int, bool> filter = new Func<int, bool>(IsEven);
            int evensSum = list.Where(IsEven).Sum();

            evensSum = list.Where(n => n % 2 == 0).Sum();

        }

        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
    }
}
