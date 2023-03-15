using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private KnowledgeHubDBContext db = new KnowledgeHubDBContext();
        public void ApproveArticles(List<int> articleIds)
        {
            foreach (var aid in articleIds)
            {
                var articleToApprove = db.Articles.Find(aid);
                if (articleToApprove != null)
                {
                    articleToApprove.IsApproved = true;
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public async Task<List<Article>> GetArticlesForBrowseAsync()
        {
            return await db.Articles.Where(a => a.IsApproved).ToListAsync();
        }

        public List<Article> GetArticlesForBrowseByCatagory(int catagoryId)
        {
            return db.Articles.Where(a => a.IsApproved && a.CatagoryId == catagoryId).ToList();
        }



        public List<Article> GetArticlesForReview()
        {
            return db.Articles.Where(a => !a.IsApproved).ToList();
        }

        public List<Article> GetArticlesForReviewByCatagory(int catagoryId)
        {
            return db.Articles.Where(a => !a.IsApproved && a.CatagoryId == catagoryId).ToList();
        }

        public void RejectArticles(List<int> articleIds)
        {
            foreach (var aid in articleIds)
            {
                var articleToReject = db.Articles.Find(aid);
                db.Articles.Remove(articleToReject);
            }
            db.SaveChanges();
        }

        public void SubmitArticle(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}
