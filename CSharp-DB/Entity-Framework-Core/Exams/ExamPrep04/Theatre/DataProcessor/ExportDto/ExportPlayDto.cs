namespace Theatre.DataProcessor.ExportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Play")]
    public class ExportPlayDto
    {
        [XmlAttribute("Title")]
        [Required]
        public string Title { get; set; } = null!;

        [XmlAttribute("Duration")]
        [Required]
        public string Duration { get; set; } = null!;

        [XmlAttribute("Rating")]
        [Required]
        public string Rating { get; set; } = null!;

        [XmlAttribute("Genre")]
        [Required]
        public string Genre { get; set; } = null!;

        [XmlArray("Actors")]
        public ExportCastDto[] Casts { get; set; }
    }
}
