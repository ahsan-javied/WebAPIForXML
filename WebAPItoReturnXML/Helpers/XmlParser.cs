using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace WebAPItoReturnXML.Helpers
{
    public static class XmlParser
    {
        public static XElement ToXElement<T>(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }

        public static T FromXElement<T>(this XElement xElement)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(xElement.CreateReader());
        }

        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var builder = new StringBuilder();
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (XmlWriter writer = XmlWriter.Create(builder,
                    new XmlWriterSettings() { OmitXmlDeclaration = true }))
                {
                    xmlSerializer.Serialize(writer, dataToSerialize);
                }

                


                return builder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        public static string ResponseXML(string xmlText)
        {
            return @"<?xml version=""1.0""?><!DOCTYPE cXML SYSTEM ""http://xml.cxml.org/schemas/cXML/1.1.007/cXML.dtd"">" + xmlText;
        }
    }


}
