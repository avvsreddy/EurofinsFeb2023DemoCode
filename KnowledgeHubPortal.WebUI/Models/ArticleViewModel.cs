using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ArticleSubmitViewModel
    {

        [Required]
        [MaxLength(100)]
        [MinLength(6)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        public int CatagoryID { get; set; }

    }
}