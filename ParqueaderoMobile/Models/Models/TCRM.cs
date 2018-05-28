namespace Models.Models
{
    using System;
    using System.Xml.Serialization;

    [Serializable()]
    [XmlRoot(ElementName = "return")]
    public class TCRM
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("unit")]
        public string Unit { get; set; }

        [XmlElement("validityFrom")]
        public DateTime ValidityFrom { get; set; }

        [XmlElement("validityTo")]
        public DateTime ValidityTo { get; set; }

        [XmlElement("value")]
        public double Value { get; set; }

        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
