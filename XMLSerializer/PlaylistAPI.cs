using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace XMLSerializer
{
    public static class PlaylistAPI
    {
        public static void SerializePlaylist(List<string> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }

        public static void DeserializePlaylist(this List<string> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<string>)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(other);
            }
        }
    }
}
