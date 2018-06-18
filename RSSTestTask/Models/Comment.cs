using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSTestTask.Models
{
    /// <summary>
    /// Comment data model
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }

        /// <summary>
        /// Text of comment
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Nickname of the comment's author
        /// </summary>
        public string Author { get; set; }
    }
}