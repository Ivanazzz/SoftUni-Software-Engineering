namespace Theatre.DataProcessor.ExportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Actor")]
    public class ExportCastDto
    {
        [XmlAttribute("FullName")]
        [Required]
        public string FullName { get; set; } = null!;

        [XmlAttribute("MainCharacter")]
        [Required]
        public string MainCharacter { get; set; } = null!;
    }
}
