using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.Domain.Data
{
    public interface IArticlesRepository
    {
        void SubmitArticle(Article article);
        void ApproveArticles(List<int> articleIds);
        void RejectArticles(List<int> articleIds);
        List<Article> GetArticlesForReviewByCatagory(int catagoryId);
        List<Article> GetArticlesForBrowseByCatagory(int catagoryId);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();
    }
}
