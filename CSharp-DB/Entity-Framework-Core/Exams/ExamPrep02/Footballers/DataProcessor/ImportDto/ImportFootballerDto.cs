namespace Footballers.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Common;

    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.FootballerNameMinLength)]
        [MaxLength(ValidationConstants.FootballerNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; } = null!;

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; } = null!;

        [XmlElement("BestSkillType")]
        [Range(ValidationConstants.FootballerBestSkillTypeMinValue, ValidationConstants.FootballerBestSkillTypeMaxValue)]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Range(ValidationConstants.FootballerPositionTypeMinValue, ValidationConstants.FootballerPositionTypeMaxValue)]
        public int PositionType { get; set; }
    }
}
