using System.Collections.Generic;

namespace RSSTestTask.Models
{
    /// <summary>
    /// Model which represents one page of news
    /// </summary>
    public class NewsPage
    {
        /// <summary>
        /// List of news on one page
        /// </summary>
        public IEnumerable<News> PageOfNews { get; set; }

        /// <summary>
        /// Full amount of pages
        /// </summary>
        public int PageAmount { get; set; }

        /// <summary>
        /// Size of news collection
        /// </summary>
        public int CollectionSize { get; set; }
    }
}