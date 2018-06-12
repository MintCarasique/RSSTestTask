using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RSSTestTask.Models
{
    public class NewsDbInitializer : DropCreateDatabaseAlways<NewsContext>
    {
        protected override void Seed(NewsContext context)
        {
            context.NewsSet.Add(new News { date = DateTime.Now, Description = "TestDescription", Title = "TestTitle" });
        }
    }
}