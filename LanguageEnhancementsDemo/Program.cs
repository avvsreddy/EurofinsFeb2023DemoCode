namespace LanguageEnhancementsDemo
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // local variable type inference
            // Anonymous Types
            var p1 = new { ID = 111, Name = "IPhone 14", Rate = 99999 };
            var p2 = new { ID = 222, Name = "IPhone 14 Pro", Rate = 199999 };
            var p3 = new { ID = 111, Name = "IPhone 14", Rate = 99999.90 };
            var p4 = new { ID = 111, Rate = 99999, Name = "IPhone 14" };
            //System.Console.WriteLine(p1.Name);
            //System.Console.WriteLine(p1.Rate);

            // Extension Methods

            string data = "some data";
            data.ToUpper();
            data.Encrypt();
            //data.
            data = SomeClass.Encrypt(data);

            int a = 10;
            a.Encrypt();


        }
    }

    static class SomeClass
    {
        public static string Encrypt(this object data)
        {
            return "@#$@#$FDSDF@#R$@#RWEFDF@#$@#$";
        }
    }


    //class Product
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public double Rate { get; set; }
    //}
}
