using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSTestTask.Models
{
    /// <summary>
    /// News model, represents one news item
    /// </summary>
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// html body, which contains text description, picture link and link to source page
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// date of news publication
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// list of comments, associated with current news
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
    }
}