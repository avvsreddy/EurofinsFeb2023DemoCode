using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };
            // LINQ to XML

            XDocument xml = XDocument.Load("XMLFile1.xml");

            var shortWords = from w in xml.Descendants("word")
                             where w.Value.Length <= 3
                             select w.Value;

            foreach (var item in shortWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
