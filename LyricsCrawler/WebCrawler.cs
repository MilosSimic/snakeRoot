using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Xml;
using System.IO;
using LyricsCrawler.assets;

namespace LyricsCrawler
{
    public class WebCrawler
    {
        protected HtmlDocument doc;
        protected WebRequest request;
        protected WebResponse response;
        protected XmlDocument xmlDoc;

        public WebCrawler()
        {
            doc = new HtmlDocument();
            xmlDoc = new XmlDocument();
        }

        #region lyrics

        public string[] getLyrics(String author, String songName)
        {

            string[] result = null;

            try
            {
                request = WebRequest.Create(createURL(author, songName));
                response = request.GetResponse();

                String lyrics = "";

                //now do crawling
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    doc.LoadHtml(reader.ReadToEnd());

                    lyrics = doc.DocumentNode.SelectSingleNode(Assets.DIV_NAME).InnerText;

                    foreach (HtmlNode node in doc.DocumentNode.SelectSingleNode(Assets.DIV_LYRICS).ChildNodes)
                    {
                        lyrics += node.InnerText;
                        lyrics += "\n\n";
                    }
                }

                response.Close();

                String parts = "";

                HtmlNode partnode = doc.DocumentNode.SelectSingleNode(Assets.PLUS_INFO);
                foreach (HtmlNode node in partnode.Elements(Assets.P_TAG))
                {
                    parts += node.InnerText + "\n\n";
                }

                result = new string[4];
                result[0] = doc.DocumentNode.SelectSingleNode(Assets.IMAGE_XPATH).Attributes[Assets.SRC_ATTR].Value;
                result[1] = lyrics;
                result[2] = parts;
                result[3] = "\n\nSource:Metro Lyrics";

            }
            catch
            { 
            
            }

            return result;
        }

        private String createURL(String author, String song)
        {

            author = author.Trim().ToLower();
            song = song.Trim().ToLower();

            if (author.Contains(Assets.EMPTY))
            {
                author = author.Replace(Assets.EMPTY, Assets.LINE);
            }

            if (song.Contains(Assets.EMPTY))
            {

                song = song.Replace(Assets.EMPTY, Assets.LINE);
            }

            String search = song + Assets.LINE + Assets.LYRICS + Assets.LINE + author;

            return String.Format(Assets.BASE_URL, search);
        }

        #endregion

        #region volframAlfa info

        public String getInfo(String artist)
        {

            if (artist.Contains(" "))
            {
                artist = artist.Trim().Replace(" ", "%20");
            }

            String link = String.Format(Assets.WOLFRAM_API,artist);
            request = WebRequest.Create(link);
            response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                xmlDoc.LoadXml(reader.ReadToEnd());
                String ret = "";
                XmlNodeList listOfNodes = xmlDoc.SelectNodes(".//pod");

                foreach (XmlNode node in listOfNodes)
                {
                    XmlNodeList xchildren = node.ChildNodes;

                    foreach (XmlNode xnode in xchildren)
                    {

                        ret += xnode.InnerText + "\n";
                    }
                }

                return "<html>\n<head>\n<body>\n" + ret + "</body>\n</head>\n</html>\n";
            }
        }

        #endregion

    }
}
