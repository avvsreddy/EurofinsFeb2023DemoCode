using System.Linq;

namespace OOCode4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SimpleCalculator sc = new SimpleCalculator();

            MyMathApp app = new MyMathApp();
            app.Calculator = new SimpleCalculator();
            app.FindSum(23, 34, 45, 34, 34, 45, 5656);

        }
    }

    interface ICalculator
    {
        int Sum(params int[] numbers);

    }

    class SimpleCalculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int item in numbers)
            {
                total += item;
            }
            System.Console.WriteLine("Simple Calculator");
            return total;
        }
    }
    class SuperCalculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            System.Console.WriteLine("Super Calculator");
            return numbers.Sum();
        }
    }

    class MyMathApp// : ICalculator
    {
        //public int FindSum(int[] numbers) 
        //{
        //    SimpleCalculator sc = new SimpleCalculator();
        //    return sc.Sum(numbers);
        //}
        public ICalculator Calculator { get; set; }
        public int FindSum(params int[] numbers)
        {
            //SimpleCalculator sc = new SimpleCalculator();
            return Calculator.Sum(numbers);
        }
    }
}
