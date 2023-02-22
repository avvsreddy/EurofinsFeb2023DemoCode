using System.IO;

namespace SimpleCalculator.DataAccess
{
    public class CalculatorRepo : ICalculatorRepo
    {
        public bool Save(string data)
        {
            // logic to save data into data store
            File.WriteAllText("X:\\calculatorresult.txt", data);
            return true;
        }
    }
}
