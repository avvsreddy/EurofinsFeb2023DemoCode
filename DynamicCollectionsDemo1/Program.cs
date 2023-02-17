using System;

namespace DynamicCollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // want to store n number of ints and get back
            DynamicIntArray numbers = new DynamicIntArray();
            //numbers.Add(10);
            //numbers.Add(20);
            //numbers.Add(30);
            //numbers.Add(40);

            for (int i = 1; i <= 10000; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Size; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }
        }
    }


    class DynamicIntArray
    {
        public int Size
        {
            get { return index; }

        }

        private int[] numbers = new int[10];
        private int index = 0;
        internal void Add(int v)
        {
            // check the empty space
            if (index < numbers.Length)
            {
                numbers[index++] = v;
            }
            else // not empty
            {
                int[] temp = new int[numbers.Length * 2];
                for (int i = 0; i < numbers.Length; i++)
                {
                    temp[i] = numbers[i];
                }
                numbers = temp;
                numbers[index++] = v;
            }

        }

        internal int Get(int i)
        {
            return numbers[i];
        }
    }
}
