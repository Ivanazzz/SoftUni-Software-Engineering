namespace Footballers.DataProcessor.ExportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ExportCoachDto
    {
        [XmlElement("CoachName")]
        [Required]
        public string Name { get; set; } = null!;

        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlArray("Footballers")]
        public ExportFootballerForCoachDto[] Footballers { get; set; }
    }
}
