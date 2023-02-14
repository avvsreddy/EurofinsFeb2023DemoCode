using System.Collections.Generic;

namespace CompanyOrdersApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            //Customer customer = new Customer();
            RegCustomer regCustomer = new RegCustomer { SplDiscount = 10 };
            Order order = new Order();
            OrderedItem oItem = new OrderedItem { Qty = 1 };
            Item item = new Item { Rate = 100 };
            oItem.Item = item;
            order.OrderedItems.Add(oItem);
            //customer.Orders.Add(order);
            regCustomer.Orders.Add(order);
            //company.Customers.Add(customer);
            company.Customers.Add(regCustomer);

            System.Console.WriteLine($"Total Amount: {company.GetTotalWorthOfOrdersPlaced()}");
        }
    }

    class Company
    {
        public double GetTotalWorthOfOrdersPlaced()
        {
            double total = 0;
            // for each customers
            foreach (Customer customer in Customers)
            {
                // for each Order placed by a customer
                total += customer.GetTotalWorth();
                // check for reg. cust discount if any
                //if (customer is RegCustomer)
                //{
                //    //RegCustomer temp = (RegCustomer)customer; // down casting
                //    RegCustomer temp = customer as RegCustomer;
                //    total -= temp.SplDiscount;
                //}
            }

            return total;
        }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
    class Item
    {
        public double Rate { get; set; }
        public string Description { get; set; }
    }
    class Customer
    {
        public virtual double GetTotalWorth()
        {
            double total = 0;
            // for each order
            foreach (Order order in Orders)
            {
                total += order.GetTotalWorth();
            }
            return total;
        }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
    class RegCustomer : Customer
    {
        public override double GetTotalWorth()
        {
            double total = 0;
            // for each order
            foreach (Order order in Orders)
            {
                total += order.GetTotalWorth();
            }
            return total - SplDiscount;
        }
        public double SplDiscount { get; set; }
    }
    class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

        public double GetTotalWorth()
        {
            // for each ordered item

            double total = 0;
            foreach (OrderedItem orderedItem in OrderedItems)
            {
                total += orderedItem.GetTotalWorth();
            }
            return total;
        }
    }
    class OrderedItem
    {
        public int Qty { get; set; }
        public Item Item { get; set; }

        internal double GetTotalWorth()
        {
            return Qty * Item.Rate;
        }
    }
}
