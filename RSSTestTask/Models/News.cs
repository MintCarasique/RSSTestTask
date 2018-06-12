using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSTestTask.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime date { get; set; }
    }
}