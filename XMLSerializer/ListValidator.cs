using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace XMLSerializer
{
    public class ListValidator
    {
        public static bool validateXML(String filename)
        {
            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.Schemas = new System.Xml.Schema.XmlSchemaSet();
                xmlSettings.Schemas.Add(null, @"assets\ListSchema.xsd");
                xmlSettings.ValidationType = ValidationType.Schema;
                XmlReader reader = XmlReader.Create(filename, xmlSettings);

                // Parse the file.
                while (reader.Read()) ;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool validateXML(Stream filename)
        {
            try
            {
                XmlReaderSettings xmlSettings = new XmlReaderSettings();
                xmlSettings.Schemas = new System.Xml.Schema.XmlSchemaSet();
                xmlSettings.Schemas.Add(null, @"assets\ListSchema.xsd");
                xmlSettings.ValidationType = ValidationType.Schema;
                XmlReader reader = XmlReader.Create(filename, xmlSettings);

                // Parse the file.
                while (reader.Read()) ;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
