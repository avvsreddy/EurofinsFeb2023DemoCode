namespace OOCode1
{
    internal class Program
    {
        //Customer customer = new Customer(); // HAS-A
        static void Main(string[] args)
        {
            Customer customer = new Customer(); // Uses // consumer
            customer.Id = 1;
            customer.Name = "Test";
            customer.Age = 300;
            //customer.SetAge(25);
            int a = customer.Age;
            Address addr = new Address { Area = "Brookfields" };
            //customer.Address.Area = "Brookfield";
            customer.Address = addr;


            // Object Initialization Syntax



            //e1.EmpID= 1;
            //e1.Name = "Test";
            //e1.Salary = 50000;
            Employee e2 = new Employee { EmpID = 1 };

            Employee employee = new Employee { EmpID = 1, Name = "test2" };

            Employee e3 = new Employee { Salary = 1000 };
            Employee e4 = new Employee { Name = "test3" };
            Employee e1 = new Employee
            {
                EmpID = 1,
                Name = "test",
                Salary = 60000,
                Address = new Address
                {
                    Area = "Brookfields"
                }
            };


        }


    }

    class Employee
    {
        //int empid;
        public int EmpID { get; set; }
        public string Name { get; set; }
        int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 10000)
                    salary = 10000;
                salary = value;
            }
        }

        public Address Address { get; set; }



        //public Employee(int id,string name,int salary) : this(id,name)
        //{
        //    //EmpID= id;
        //    //Name = name;
        //    Salary = salary;
        //}
        //public Employee(int id)
        //{
        //    EmpID= id;
        //}

        //public Employee(int id,string name):this(id)
        //{
        //   Name= name;
        //}

    }

    class Customer // Author
    {

        public string Type { get; set; }

        //int id; // field
        int backingfield12323121234;
        //int id1;//
        // Property
        public int Id
        {
            get;// { return id; }
            set;// { id = value; }

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

        public Address Address { get; set; }

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

    class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
