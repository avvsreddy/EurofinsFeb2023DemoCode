using System;
using System.Collections.Generic;

namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item[] items = new Item[3];

            var i1 = new Item { ItemID = 1, Name = "IPhone", Cost = 76000 };
            var i2 = new Item { ItemID = 2, Name = "Galaxy S22", Cost = 90000 };
            var i3 = new Item { ItemID = 3, Name = "MI 56", Cost = 5000 };
            items[0] = i1;
            items[1] = i2;
            items[2] = i3;
            Array.Sort(items, new ItemNameComparer());

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }



        }
    }

    //IComparer

    class ItemCostComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            Console.WriteLine("using IComparer");
            return x.Cost - y.Cost;

        }
    }

    class ItemNameComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            Console.WriteLine("Using Item name comparer");
            return x.Name.CompareTo(y.Name);

        }
    }


    //IComparable
    class Item : IComparable<Item>
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public int CompareTo(Item other)
        {
            Console.WriteLine("using Icomparable");
            if (this.Cost > other.Cost) return -1;
            if (this.Cost < other.Cost) return 1;
            return 0;
        }

        //public int CompareTo(object obj)
        //{
        //    Item item = obj as Item;
        //    if (this.Cost > item.Cost) return -1;
        //    if (this.Cost < item.Cost) return 1;
        //    return 0;
        //}
    }
}
