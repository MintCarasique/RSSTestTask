using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using RSSTestTask.Models;

namespace RSSTestTask.Shared
{
    public static class RSSParser
    {
        public static List<News> GetNews(string url)
        {
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.Load(url);
            XmlNodeList rssNodes = rssDoc.SelectNodes("rss/channel/item");
            var responseList = new List<News>();
            foreach(XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string date = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                responseList.Add(new News { Title = title, Date = DateTime.Parse(date), Description = description });
            }
            return responseList;
        }
    }
}