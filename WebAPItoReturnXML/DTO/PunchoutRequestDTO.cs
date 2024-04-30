using System.Xml.Serialization;

namespace WebAPItoReturnXML.DTO
{
    [Serializable()]
    [XmlRoot(ElementName = "cXML")]
    public class PunchoutRequestDTO
    {

        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }

        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }

        [XmlAttribute(AttributeName = "payloadID")]
        public string PayloadID { get; set; }

        [XmlAttribute(AttributeName = "xml:lang")]
        public string Lang { get; set; }

        [XmlAttribute(AttributeName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "From")]
        public From From { get; set; }

        [XmlElement(ElementName = "To")]
        public To To { get; set; }

        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "Request")]
    public class Request
    {

        [XmlElement(ElementName = "PunchOutSetupRequest")]
        public PunchOutSetupRequest PunchOutSetupRequest { get; set; }

        [XmlAttribute(AttributeName = "deploymentMode")]
        public string DeploymentMode { get; set; }
    }

   

    [Serializable()] 
    [XmlRoot(ElementName = "Credential")]
    public class Credential
    {
        [XmlElement(ElementName = "Identity")]
        public string Identity { get; set; }

        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }

        [XmlElement(ElementName = "SharedSecret")]
        public string SharedSecret { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "From")]
    public class From
    {

        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "To")]
    public class To
    {

        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "Sender")]
    public class Sender
    {

        [XmlElement(ElementName = "Credential")]
        public Credential Credential { get; set; }

        [XmlElement(ElementName = "UserAgent")]
        public string UserAgent { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "PunchOutSetupRequest")]
    public class PunchOutSetupRequest
    {

        [XmlElement(ElementName = "BuyerCookie")]
        public string BuyerCookie { get; set; }

        [XmlElement(ElementName = "BrowserFormPost")]
        public BrowserFormPost BrowserFormPost { get; set; }

        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
    }

    [Serializable()] 
    [XmlRoot(ElementName = "BrowserFormPost")]
    public class BrowserFormPost
    {

        [XmlElement(ElementName = "URL")]
        public string URL { get; set; }
    }
}
