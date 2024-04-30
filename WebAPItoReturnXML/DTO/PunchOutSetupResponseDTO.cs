
using System.Xml.Serialization;

namespace WebAPItoReturnXML.DTO
{
    [Serializable()]
    [XmlRoot(ElementName = "cXML")]
    public class PunchOutSetupResponseDTO
    {

        [XmlElement(ElementName = "Response")]
        public Response Response { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "Status")]
    public class Status
    {

        [XmlAttribute(AttributeName = "code")]
        public int Code { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "StartPage")]
    public class StartPage
    {

        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "PunchOutSetupResponse")]
    public class PunchOutSetupResponse
    {

        [XmlElement(ElementName = "StartPage")]
        public StartPage StartPage { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "Response")]
    public class Response
    {

        [XmlElement(ElementName = "Status")]
        public Status Status { get; set; }

        [XmlElement(ElementName = "PunchOutSetupResponse")]
        public PunchOutSetupResponse PunchOutSetupResponse { get; set; }
    }
}
