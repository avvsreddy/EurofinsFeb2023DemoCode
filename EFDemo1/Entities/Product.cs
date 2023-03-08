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
    }
}
