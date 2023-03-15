using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }
        public string Submiter { get; set; }

        public bool IsApproved { get; set; }

        public DateTime DateSubmited { get; set; }
    }
}
