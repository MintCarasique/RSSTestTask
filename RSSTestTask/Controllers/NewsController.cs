using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RSSTestTask.Models;
using RSSTestTask.Shared;

namespace RSSTestTask.Controllers
{
    [Authorize]
    public class NewsController : ApiController
    {
        private NewsContext db = new NewsContext();

        private void UpdateNews()
        {
            var receivedNews = RSSParser.GetNews("https://dev.by/rss");
            var currentNews = db.NewsSet.ToList();

            var updatedNews = receivedNews.ExceptBy(currentNews, func => func.Date);
            if (updatedNews.Count() != 0)
            {
                db.NewsSet.AddRange(updatedNews);
                db.SaveChanges();
            };
        }

        // GET: api/News
        public IQueryable<News> GetNewsSet()
        {
            UpdateNews();

            return db.NewsSet.OrderByDescending(exp =>exp.Date).Include(q => q.Comments);
        }

        // GET: api/News/5
        [ResponseType(typeof(NewsPage))]
        public async Task<IHttpActionResult> GetNewsPage(int id)
        {
            int maxRows = 5;

            var newsPage = new NewsPage();

            UpdateNews();

            newsPage = await GetPageAsync(id, maxRows, db);

            newsPage.CollectionSize = await GetCollectionSizeAsync(db);

            double pageAmount = (double)(newsPage.CollectionSize / Convert.ToDecimal(maxRows));



            newsPage.PageAmount = (int)Math.Ceiling(pageAmount);
            return Ok(newsPage);
        }

        private Task<NewsPage> GetPageAsync(int id, int maxRows, NewsContext db)
        {
            var newsPage = new NewsPage();
            return Task.Run(() =>
             {
                 newsPage.PageOfNews = db.NewsSet
                 .OrderByDescending(exp => exp.Date)
                 .Include(q => q.Comments)
                 .Skip((id - 1) * maxRows)
                 .Take(maxRows).ToList();
                 return newsPage;
             });
        }

        private Task<int> GetCollectionSizeAsync(NewsContext db)
        {
            return Task.Run(() =>
            {
                return db.NewsSet.Count();
            });
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        private bool NewsExists(int id)
        {
            return db.NewsSet.Count(e => e.Id == id) > 0;
        }

    }
}