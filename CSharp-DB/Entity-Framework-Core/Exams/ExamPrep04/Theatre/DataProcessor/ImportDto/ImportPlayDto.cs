namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [MinLength(ValidationConstants.PlayTitleMinLength)]
        [MaxLength(ValidationConstants.PlayTitleMaxLength)]
        public string Title { get; set; } = null!;

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; } = null!;

        [XmlElement("Raiting")]
        [Range(ValidationConstants.PlayRatingMinValue, ValidationConstants.PlayRatingMaxValue)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; } = null!;

        [XmlElement("Description")]
        [Required]
        [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [XmlElement("Screenwriter")]
        [Required]
        [MinLength(ValidationConstants.PlayScreenwriterMinLength)]
        [MaxLength(ValidationConstants.PlayScreenwriterMaxLength)]
        public string Screenwriter { get; set; } = null!;
    }
}
