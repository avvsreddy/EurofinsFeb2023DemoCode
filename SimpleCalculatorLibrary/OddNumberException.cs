using System;

namespace SimpleCalculatorLibrary
{
    public class OddNumberException : ApplicationException
    {
        public OddNumberException(string msg = null, Exception innerEx = null) : base(msg, innerEx) { }

    }
}
