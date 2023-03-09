using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo1.Entities
{
    public class Product // poco
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }

        public string Brand { get; set; }

        public string Country { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();

    }

    [Table("tbl_catagories")]
    public class Catagory
    {
        [Key]
        public int catid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        [Column("desc", TypeName = "varchar")]
        public string Description { get; set; }
        [NotMapped]
        public int Profit { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

    }
    //[Table("Suppliers")]
    public class Supplier : Person
    {
        public string GST { get; set; }
        public int Rating { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

        public Address Address { get; set; }

    }
    [ComplexType]
    public class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
    }

    abstract public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // TPC
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
    //[Table("Customers")]
    public class Customer : Person
    {
        public string CustomerType { get; set; }
        public double Discount { get; set; }
    }
}
