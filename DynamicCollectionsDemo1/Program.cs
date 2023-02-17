using System;

namespace DynamicCollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // want to store n number of ints and get back
            DynamicIntArray numbers = new DynamicIntArray();
            DynamicDoubleArray doubles = new DynamicDoubleArray();
            DynamicArray<int> ints = new DynamicArray<int>();
            //numbers.Add(10);
            //numbers.Add(20);
            //numbers.Add(30);
            //numbers.Add(40);

            for (int i = 1; i <= 10000; i++)
            {
                ints.Add(i);
            }

            for (int i = 0; i < ints.Size; i++)
            {
                Console.WriteLine(ints.Get(i));
            }
        }
    }


    class DynamicIntArray
    {
        public int Size
        {
            get { return index; }

        }

        private object[] numbers = new object[10];
        private int index = 0;
        internal void Add(object v)
        {
            // check the empty space
            if (index < numbers.Length)
            {
                numbers[index++] = v;
            }
            else // not empty
            {
                //int[] temp = new int[numbers.Length * 2];
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}
                //Array.Copy(numbers,temp, numbers.Length);
                //numbers = temp;

                Array.Resize(ref numbers, numbers.Length * 2);
                numbers[index++] = v;
            }

        }

        internal int Get(int i)
        {
            return numbers[i];
        }
    }

    class DynamicDoubleArray
    {
        public int Size
        {
            get { return index; }

        }

        private double[] numbers = new double[10];
        private int index = 0;
        internal void Add(double v)
        {
            // check the empty space
            if (index < numbers.Length)
            {
                numbers[index++] = v;
            }
            else // not empty
            {
                //int[] temp = new int[numbers.Length * 2];
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}
                //Array.Copy(numbers,temp, numbers.Length);
                //numbers = temp;

                Array.Resize(ref numbers, numbers.Length * 2);
                numbers[index++] = v;
            }

        }

        internal double Get(int i)
        {
            return numbers[i];
        }
    }

    class DynamicArray<T>
    {
        public int Size
        {
            get { return index; }

        }

        private T[] numbers = new T[10];
        private int index = 0;
        internal void Add(T v)
        {
            // check the empty space
            if (index < numbers.Length)
            {
                numbers[index++] = v;
            }
            else // not empty
            {
                //int[] temp = new int[numbers.Length * 2];
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}
                //Array.Copy(numbers,temp, numbers.Length);
                //numbers = temp;

                Array.Resize(ref numbers, numbers.Length * 2);
                numbers[index++] = v;
            }

        }

        internal T Get(int i)
        {
            return numbers[i];
        }
    }


}
