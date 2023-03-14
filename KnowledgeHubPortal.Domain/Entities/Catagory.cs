using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        [Required(ErrorMessage = "Please enter catagory name")]
        [MinLength(5, ErrorMessage = "Provide minimum 5 alphabets...")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
