namespace OOCode1
{
    internal class Program
    {
        //Customer customer = new Customer(); // HAS-A
        static void Main(string[] args)
        {
            Customer customer = new Customer(); // Uses // consumer
            customer.Id = 1;
            customer.name = "Test";
            customer.age = 300;
            customer.SetAge(25);
            int a = customer.GetAge();

        }


    }

    class Customer // Author
    {
        int id; // field

        // Property
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        //public void SetId(int id)
        //{
        //    this.id = id;
        //}
        //public int GetId()
        //{
        //    return id;
        //}
        string name;//field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //public void SetName(string name)
        //{
        //    this.name= name;
        //}
        //public string GetName()
        //{
        //    return name;
        //}
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (age < 18 || age > 60)
                {
                    age = 18;
                }
                age = value;
            }
        }
        //public void SetAge(int age)
        //{
        //    if(age < 18 || age > 60) 
        //    {
        //        age = 18;
        //    }
        //    this.age = age;
        //}
        //public int GetAge() 
        //{
        //    return age;
        //}

    }
}
