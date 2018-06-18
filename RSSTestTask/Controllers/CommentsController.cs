using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RSSTestTask.Models;

namespace RSSTestTask.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        private NewsContext db = new NewsContext();

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> GetComment(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // POST: api/Comments/5
        /// <summary>
        /// Add comment under news
        /// </summary>
        /// <param name="id">News ID where comment will be placed</param>
        /// <param name="comment">Comment model</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            News selectedNews = await db.NewsSet.FindAsync(id);
            if (selectedNews == null)
            {
                return NotFound();
            }
            if(selectedNews.Comments == null)
            {
                selectedNews.Comments = new List<Comment>();
            }

            selectedNews.Comments.Add(new Comment {Author = comment.Author, Text = comment.Text });
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        
        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            await db.SaveChangesAsync();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.Id == id) > 0;
        }
    }
}