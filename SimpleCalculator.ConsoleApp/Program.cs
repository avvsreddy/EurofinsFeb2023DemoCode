using SimpleCalculator.Business;
using System;

namespace SimpleCalculator.ConsoleApp
{
    internal class Program // UI
    {
        static void Main(string[] args) // UI Logic
        {
            // Accept two ints and find the sum then display

            // accept two ints
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            // find the sum
            //sum = fno + sno;
            sum = Calculator.FindSum(fno, sno);
            // display the result
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }

    }

    //class Calculator // BL
    //{
    //    public static int FindSum(int fno, int sno) // SRP -  BL
    //    {
    //        return fno + sno;
    //    }
    //}
}
