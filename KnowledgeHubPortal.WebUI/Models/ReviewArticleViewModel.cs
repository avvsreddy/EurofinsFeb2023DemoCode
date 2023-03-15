using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ReviewArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Catagory { get; set; }
        public string Submiter { get; set; }
        [Display(Name = "When")]
        public string WhenSubmited { get; set; }
    }
}