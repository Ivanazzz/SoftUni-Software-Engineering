namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlElement("ProjectName")]
        public string Name { get; set; } = null!;

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; } = null!;

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlArray("Tasks")]
        public ExportTaskForProjectDto[] Tasks { get; set; }
    }
}
