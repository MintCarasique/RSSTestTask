using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSTestTask.Models
{
    public class NewsPage
    {
        public IEnumerable<News> PageOfNews { get; set; }

        public int PageAmount { get; set; }
    }
}