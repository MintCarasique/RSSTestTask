using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Web;
using System.Xml;
using RSSTestTask.Models;
using System.ServiceModel.Syndication;

namespace RSSTestTask.Shared
{
    public static class RSSParser
    {
        public static List<News> GetNews(string url)
        {
            XmlReader rssDoc = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(rssDoc);
            rssDoc.Close();
            //XmlNodeList rssNodes = rssDoc.SelectNodes("rss/channel/item");
            var responseList = new List<News>();
            foreach (SyndicationItem item in feed.Items)
            {
                string title = item.Title.Text;
                
                DateTime date = item.PublishDate.UtcDateTime;
                
                string description = item.Summary.Text;

                responseList.Add(new News { Title = title, Date = date, Description = description });
            }
            return responseList;
        }
    }
}