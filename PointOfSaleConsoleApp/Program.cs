using System;
using System.Configuration;

namespace PointOfSaleConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITaxCalculator tax = new TNTaxCalculator();
            BillingSystem billingSystem = new BillingSystem();
            billingSystem.GenerateBill();

            //CalculatorFactory f1 = CalculatorFactory.Instance;
            //Console.WriteLine($"f1: {f1.GetHashCode()}");
            //CalculatorFactory f2 = CalculatorFactory.Instance;
            //Console.WriteLine($"f2: {f2.GetHashCode()}");

        }
    }


    public class CalculatorFactory
    {

        private CalculatorFactory()
        {

        }

        //private static CalculatorFactory instance = null;

        public static readonly CalculatorFactory Instance = new CalculatorFactory();
        //public static CalculatorFactory GetInstance()
        //{
        //    if (instance == null)
        //        instance = new CalculatorFactory();
        //    return instance;
        //}

        public virtual ITaxCalculator CreateTaxCalculator()
        {
            // read the config file
            string calculatorClassName = ConfigurationManager.AppSettings["TAXCALC"];
            // create the instance - Reflextion
            Type theCalculator = Type.GetType(calculatorClassName);



            ITaxCalculator calc = (ITaxCalculator)Activator.CreateInstance(theCalculator);
            // return
            return calc;



        }
    }

    class BillingSystem
    {
        //private ITaxCalculator taxCalc = null;
        //public BillingSystem(ITaxCalculator tax)
        //{
        //    this.taxCalc = tax;
        //}
        public void GenerateBill()
        {
            // scan and total
            double amount = 6500.90;
            // discount
            double discount = 125.00;
            // offers
            // tax calculation
            //ITaxCalculator taxCalc = new TNTaxCalculator();
            //CalculatorFactory factory = CalculatorFactory.GetInstance();
            ITaxCalculator taxCalc = CalculatorFactory.Instance.CreateTaxCalculator();
            double tax = taxCalc.CalculateTax(amount);
            // print bill
            double totAmt = amount - discount + tax;
            // payment
        }
    }

    public interface ITaxCalculator // Strategy
    {
        double CalculateTax(double amount);
    }

    class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double ct = 125.67;
            double kst = 56.89;
            double es = 50.00;
            double sbt = 23;
            double kkt = 20;
            double tax = ct + kst + es + sbt + kkt;
            Console.WriteLine("Using KA Tax calculator");
            return tax;
        }
    }

    class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double ct = 125.67;
            double tst = 56.89;
            double ecs = 50.00;
            double at = 23;
            double lt = 20;
            double tax = ct + tst + ecs + at + lt;
            Console.WriteLine("Using TN Tax Clauclator");
            return tax;
        }
    }


    class USTaxClaculator
    {
        public float ComputeTax(float amount)
        {
            //sdfsdfsdf
            //asdfsdfsd
            //sdfsdfsdf
            //sdfsdfsd
            Console.WriteLine("Using US Tax Calculator");
            return 124f;
        }
    }


    class USTaxClaculatorAdapter : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            USTaxClaculator calc = new USTaxClaculator();
            return calc.ComputeTax((float)amount);
        }
    }
}
