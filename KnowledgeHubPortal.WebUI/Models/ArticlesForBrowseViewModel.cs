﻿using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebUI.Models
{
    public class ArticlesForBrowseViewModel
    {

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        [Display(Name = "Catagory")]
        public string CatagoryName { get; set; }

        public string Submiter { get; set; }

        [Display(Name = "When")]
        public string WhenSubmited { get; set; }
    }
}