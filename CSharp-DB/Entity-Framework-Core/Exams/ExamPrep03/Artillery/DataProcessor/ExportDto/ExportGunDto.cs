namespace Artillery.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Gun")]
    public class ExportGunDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; } = null!;

        [XmlAttribute("GunType")]
        public string GunType { get; set; } = null!;

        [XmlAttribute("GunWeight")]
        public string GunWeight { get; set; } = null!;

        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; } = null!;

        [XmlAttribute("Range")]
        public string Range { get; set; } = null!;

        [XmlArray("Countries")]
        public ExportCountryForGun[] Countries { get; set; }
    }
}
