using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.Domain
{
    public class ArticlesManager : IArticlesManager
    {
        private IArticlesRepository repo = null;

        public ArticlesManager(IArticlesRepository repo)
        {
            this.repo = repo;
        }

        public void ApproveArticles(List<int> articleIds)
        {
            repo.ApproveArticles(articleIds);
        }

        public List<Article> GetArticlesForBrowse()
        {
            return repo.GetArticlesForBrowse();
        }

        public List<Article> GetArticlesForBrowseByCatagory(int catagoryId)
        {
            return repo.GetArticlesForBrowseByCatagory(catagoryId);
        }

        public List<Article> GetArticlesForReview()
        {
            return repo.GetArticlesForReview();
        }

        public List<Article> GetArticlesForReviewByCatagory(int catagoryId)
        {
            return repo.GetArticlesForReviewByCatagory(catagoryId);
        }

        public void RejectArticles(List<int> articleIds)
        {
            repo.RejectArticles(articleIds);
        }

        public void SubmitArticle(Article article)
        {
            repo.SubmitArticle(article);
        }
    }
}
