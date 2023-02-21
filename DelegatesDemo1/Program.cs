namespace DelegatesDemo1
{

    //public class MyDelegate : Delegate
    //{

    //}

    public delegate void MyDelegate(string str); // 1. Delegate Declaration

    internal class Program
    {
        static void Main(string[] args)
        {
            //Greeting("Hello from direct");// direct method invocation
            MyDelegate d = new MyDelegate(Greeting); //2. Instatiation and Intialize
            // Subscription
            Program p = new Program();
            d += p.Hi; // subscription
            //d -= Greeting; // unsubscribe
            //3. Invoke
            //d.Invoke("Hello from delegate");
            d("Hello from delegate the other way");
        }
        static void Greeting(string text)
        {
            System.Console.WriteLine($"Greeting: {text}");
        }

        public void Hi(string msg)
        {
            System.Console.WriteLine($"Hi: {msg}");
        }
    }
}
