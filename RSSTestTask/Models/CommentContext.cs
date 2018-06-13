using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RSSTestTask.Models
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}