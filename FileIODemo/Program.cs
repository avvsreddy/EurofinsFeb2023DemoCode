using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileIODemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // File Handling

            //Get all Files
            string[] files = Directory.GetFiles(@"E:\");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }



        }

        private static void GetDrives()
        {
            // get all drives
            // 
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void Deserialize()
        {
            //Serialize();
            BinaryFormatter binary = new BinaryFormatter();
            Stream stream = File.Open(@"e:\contacts.dat", FileMode.Open);
            Contact c = new Contact();
            c = (Contact)binary.Deserialize(stream);
            Console.WriteLine(c.Name);
            stream.Close();
        }

        private static void Serialize()
        {
            // save as binary

            // store contact info into file
            Contact c = new Contact { ID = 111, Name = "Sachin", EmailID = "sachin@bcci.org", Location = "Mumbai", Mobile = "34234234" };
            // text format - structured data
            //string csvData = $"{c.ID},{c.Name},{c.Location},{c.EmailID},{c.Mobile}";
            Stream stream = File.Create(@"e:\contacts.dat");
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stream, c);
            //StreamWriter sw = new StreamWriter("e:\\contacts.txt", true);
            //sw.WriteLine(csvData);
            stream.Close();
        }

        private static void ReadContacts()
        {
            //ReadContacts
            StreamReader reader = new StreamReader("e:\\contacts.txt");
            List<Contact> contacts = new List<Contact>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // convert line into contact obj
                //111,sachin,sdfsdf,sdfsdf,sdfsdf,sdfsdf
                string[] data = line.Split(',');
                Contact c = new Contact();
                c.ID = int.Parse(data[0]);
                c.Name = data[1];
                c.Location = data[2];
                c.EmailID = data[3];
                c.Mobile = data[4];
                contacts.Add(c);

            }
            reader.Close();
            //display the list of contacts
            foreach (var c in contacts)
            {
                System.Console.WriteLine($"{c.Name}\t{c.Mobile}");
            }
        }

        private static void SaveContact()
        {
            // store contact info into file
            Contact c = new Contact { ID = 111, Name = "Sachin", EmailID = "sachin@bcci.org", Location = "Mumbai", Mobile = "34234234" };
            // text format - structured data
            string csvData = $"{c.ID},{c.Name},{c.Location},{c.EmailID},{c.Mobile}";
            StreamWriter sw = new StreamWriter("e:\\contacts.txt", true);
            sw.WriteLine(csvData);
            sw.Close();
        }

        private static void ReadLine()
        {
            // read from file
            StreamReader reader = new StreamReader("e:\\sample.txt");
            // read line by line
            //string allLines = reader.ReadToEnd();
            while (!reader.EndOfStream)
            {
                string line1 = reader.ReadLine();
                System.Console.WriteLine(line1);
            }
            //string line2 = reader.ReadLine();
            //System.Console.WriteLine(line2);

            // close
            reader.Close();
        }

        private static void ReadAll()
        {
            //Save();
            // read from file
            StreamReader reader = new StreamReader("e:\\sample.txt");
            // read all data atonce
            string allLines = reader.ReadToEnd();
            System.Console.WriteLine(allLines);
            // close
            reader.Close();
        }

        private static void Save()
        {
            // save some info into a file
            string someData = "Some other data";
            System.IO.StreamWriter sw = new System.IO.StreamWriter("e:\\sample.txt", true);
            try
            {

                sw.WriteLine(someData);

                //sdfsdfsdf
                //sdfsfsd
                //sdfsdfsdf
            }
            finally
            {
                sw.Close();
            }
        }
    }
    [Serializable]
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
    }
}
