using System;

namespace ExceptionsDemo1
{
    internal class Program // UI
    {
        static void Main(string[] args)
        {
            // Accept 2 ints, find the sum and display.....

            int fno, sno, sum;
            while (true)
            {
                try
                {
                    System.Console.Write("Enter first number: ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    sno = int.Parse(Console.ReadLine());

                    sum = Calculator.Sum(fno, sno);

                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Enter only numbers");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Enter small numbers");
                }
                //catch (NegativeNumberException ex)
                //{
                //    Console.WriteLine("Enter positive numbers only");
                //}
                catch (Exception ex) // catch all
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }

    /// <summary>
    /// Calculator will be used for finding mathematical calculations
    /// </summary>
    public class Calculator // BLL
    {
        /// <summary>
        /// Finds a sum
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>sum of two ints</returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static int Sum(int a, int b)
        {


            // non zero
            // even numbers
            /*
             * this is multi
             * line
             * comment
             * 
             */
            try
            {
                InputValidator.Validate(a, b);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                // log the ex



                throw ex;
            }
            return a + b;

        }
    }

    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException()
        {

        }

        public NegativeNumberException(string msg) : base(msg)
        {
            //Message = msg;
        }
    }

    public class InputValidator
    {
        /// <summary>
        /// validates the input
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static bool Validate(int a, int b)
        {
            // only +ve
            if (a < 0 || b < 0)
            {
                NegativeNumberException exception = new NegativeNumberException("Enter only positive numbers");
                //exception.Message = "";
                throw exception;
            }
            return true;
        }
    }
}
