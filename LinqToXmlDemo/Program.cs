using System.Linq;
using System.Xml.Linq;

namespace LinqToXmlDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XDocument xml = XDocument.Load("XMLFile1.xml");
            // get all titles which belongs to fantacy

            XElement doc = new XElement("books",

            from book in xml.Descendants("book")
            where book.Element("genre").Value == "Fantasy"
            select new XElement("book",
                            new XElement("id", book.Attribute("id").Value),
                            new XElement("Title", book.Element("title").Value),
                            new XElement("author", book.Element("author").Value)
                            )
            );

            doc.Save("fantatybooks.xml");
            /*
             * <books>
             *      <book>
             *          <id>111</id>
             *          <title>sdfsdf</title>
             *          <author>sdfsdfsdf</author>
             *      </book>
             *      
             *      <book>
             *      </book>
             * </books>
             */

            //foreach (var item in fantacyBooks)
            //{
            //    System.Console.WriteLine(item.Author + " " + item.Title);
            //}
        }
    }

    //class BookTitleAuthor
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}
}
