using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using LinqToTwitter;

namespace TwitterStatus
{
    public class Twitter
    {
        public static void tweet(String what)
        {
            XmlNodeList nodes = prepareXML();

            var auth = new SingleUserAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = nodes.Item(0).InnerText,
                    ConsumerSecret = nodes.Item(1).InnerText,
                    OAuthToken = nodes.Item(2).InnerText,
                    AccessToken = nodes.Item(3).InnerText,
                }
            };

            var service = new TwitterContext(auth);
            var tweet = service.UpdateStatus(what.Trim());
        }

        private static XmlNodeList prepareXML()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"assets\authentication.xml");

            XmlNode first = xml.LastChild;
            XmlNodeList list = first.ChildNodes;
            XmlNode node = list.Item(Statics.FIRST_NODE);

            return node.ChildNodes;
        }
    }
}
