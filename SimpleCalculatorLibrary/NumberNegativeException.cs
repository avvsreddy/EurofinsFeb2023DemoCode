using System;

namespace SimpleCalculatorLibrary
{
    public class NumberNegativeException : ApplicationException
    {
        public NumberNegativeException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }
}
