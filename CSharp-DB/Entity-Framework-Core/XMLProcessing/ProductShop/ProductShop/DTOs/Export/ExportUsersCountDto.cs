namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    public class ExportUsersCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserDto[] Users { get; set; }
    }
}
