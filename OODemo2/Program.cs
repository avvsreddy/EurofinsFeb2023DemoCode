using System;

namespace OODemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Base class ref variable can hold derived type objects
            IShape s;//= new Shape();
            s = new Triangle();
            s.CalculateArea(10, 10);
        }
    }


    interface IShape
    {
        void Draw();
        //{
        //    Console.WriteLine("Drawing Shape...");
        //}

        double CalculateArea(double width, double height);
        //{
        //    Console.WriteLine("Calculating Shape Area....");
        //    return width * height;
        //}
    }

    class Rectangle : IShape
    {
        public double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Rect area");
            return width * height;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle...");
        }
    }

    class Triangle : IShape
    {
        public double CalculateArea(double width, double height)
        {
            Console.WriteLine("Calculating Triangle Area....");
            return width * height / 2;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Triangle...");
        }
    }
}
