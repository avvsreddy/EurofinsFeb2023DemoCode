using SimpleCalculator.DataAccess;

namespace SimpleCalculatorLibrary
{



    public class Calculator
    {
        // find the sum of two ints
        // non negative numbers
        // even numbers
        // throws suitable exp if business rules voilated
        // save the result into file
        private ICalculatorRepo repo = null;
        public Calculator(ICalculatorRepo repo)
        {
            this.repo = repo;
        }
        public int Sum(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new NumberNegativeException("Input numbers should be positive");
            if (a % 2 != 0 || b % 2 != 0) throw new OddNumberException("Input numbers should be even");
            int sum = a + b;
            //CalculatorRepo repo = new CalculatorRepo();
            repo.Save($"{a}+{b}={sum}");
            return sum;
        }

        //public int Subtract(int a, int b)
        //{
        //    return a + b;
        //}

    }
}
